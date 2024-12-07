using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;
using Restaurant.Domain.Dish;
using Restaurant.Domain.Order;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await
                _dbContext
                    .Users
                    .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken)
                    ?? throw new NotFoundException(nameof(UserModel), request.UserId);

            var cart = await
                _dbContext
                    .Carts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken)
                    ?? throw new NotFoundException(nameof(CartModel), request.UserId);

            if (cart.Items.Count <= 0)
            {
                throw new Exception("Cart is clear");
            }

            var dishIds = cart.Items.Select(ci => ci.DishId).ToList();

            var dishes = await
                _dbContext
                .Dishes
                .Where(d => dishIds.Contains(d.Id))
                .ToListAsync(cancellationToken);

            float totalCost = CalculateCost(cart, dishes);

            var order = new OrderModel
            {
                Id = Guid.NewGuid(),
                Code = await GenerateCode(cancellationToken),
                PersonQuantity = request.PersonQuantity,
                Status = OrderStatus.Pending,
                Address = request.Address,
                CreationDateTime = DateTime.UtcNow,
                AddChopsticks = request.AddChopsticks,
                AddForks = request.AddForks,
                User = user,
                Cost = totalCost
            };

            order.Items = cart.Items.Select(ci => new OrderItem
            {
                Order = order,
                OrderId = order.Id,
                DishId = ci.DishId,
                Dish = ci.Dish,
                Count = ci.Count
            }).ToList();

            await _dbContext.Orders.AddAsync(order, cancellationToken);

            cart.Items.Clear();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }

        private static float CalculateCost(CartModel cart, List<DishModel> dishes)
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
            var existingCodes = await _dbContext.Orders
                .Where(o => o.CreationDateTime.Date == DateTime.UtcNow.Date && o.Status != OrderStatus.Completed)
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
