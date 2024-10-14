using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishes.Queries.GetDishDetails
{
    public class GetDishDetailsQuery : IRequest<DishDetailsViewModel>
    {
        public required Guid Id { get; set; }
    }
}
