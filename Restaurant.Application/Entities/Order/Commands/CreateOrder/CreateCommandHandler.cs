using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Models.Cart;
using Restaurant.Domain;

namespace Restaurant.Application.Entities.Order.Commands.Create
{
    public class CreateCommandHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<CreateCommand, Guid>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                    .Users
                    .Include(e => e.Profile)
                    .ThenInclude(e => e.Address)
                    .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.User), request.UserId);

            ICart cart;

            if (request.Cart != null)
            {
                cart = request.Cart;
            }
            else
            {
                var remoteCart = await
                    _dbContext
                        .Carts
                        .Include(c => c.Items)
                        .FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken)
                        ?? throw new NotFoundException(nameof(Domain.Cart), request.UserId);

                cart = _mapper.Map<CartDto>(remoteCart);
            }

            if (cart.Items.Count <= 0)
            {
                throw new Exception("Корзина пустая!");
            }

            if (user.Profile.Address == null && request.Address == null && request.ReceiptMethod == ReceiptMethod.Delivery)
            {
                throw new Exception("Введите адрес доставки!");
            }

            var dishIds = cart.Items.Select(ci => ci.DishId).ToList();

            var dishes = await
                _dbContext
                .Dishes
                .Where(d => dishIds.Contains(d.Id))
                .ToListAsync(cancellationToken);

            float totalCost = CalculateCost(cart, dishes);

            var order = new Domain.Order
            {
                Id = Guid.NewGuid(),
                Code = await GenerateCode(cancellationToken),
                ReceiptAt = request.ReceiptAt,
                ReceiptMethod = request.ReceiptMethod,
                PersonQuantity = request.PersonQuantity,
                Status = OrderStatus.Pending,
                Comment = request.Comment,
                Address = request.Address ?? user.Profile.Address,
                Timestamps = new Timestamps
                {
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                AddChopsticks = request.AddChopsticks,
                AddForks = request.AddForks,
                PaymentMethod = request.PaymentMethod,
                User = user,
                Cost = totalCost
            };

            order.Items = cart.Items.Select(ci => new OrderItem
            {
                Order = order,
                OrderId = order.Id,
                DishId = ci.DishId,
                Dish = dishes.FirstOrDefault(e => e.Id == ci.DishId)!,
                Count = ci.Count
            }).ToList();

            await _dbContext.Orders.AddAsync(order, cancellationToken);

            cart.Items.Clear();

            if (user.Profile.Address == null)
            {
                user.Profile.Address = order.Address;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }

        private static float CalculateCost(ICart cart, List<Domain.Dish> dishes)
        {
            float totalCost = 0;

            foreach (var cartItem in cart.Items)
            {
                var dish = dishes.FirstOrDefault(d => d.Id == cartItem.DishId);
                if (dish != null)
                {
                    totalCost += dish.Price * cartItem.Count;
                }
            }

            return totalCost;
        }

        private async Task<string> GenerateCode(CancellationToken cancellationToken)
        {
            string code;
            var existingCodes = await
                _dbContext
                .Orders
                .Include(e => e.Timestamps)
                .Where(o => o.Timestamps.CreatedAt.Date == DateTime.UtcNow.Date && o.Status != OrderStatus.Completed)
                .Select(o => o.Code)
                .ToListAsync(cancellationToken);

            do
            {
                int randomNumber = Random.Shared.Next(100, 1000);
                char randomLetter = (char)Random.Shared.Next('A', 'Z' + 1);
                code = $"{randomNumber}{randomLetter}";

            } while (existingCodes.Contains(code));

            return code;
        }
    }
}
