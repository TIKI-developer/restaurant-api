using MediatR;


namespace Restaurant.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
