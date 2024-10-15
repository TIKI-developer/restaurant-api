namespace Restaurant.Domain.User
{
    public class ClientModel : UserModel
    {
        public override UserRole Role => UserRole.Client;
    }
}
