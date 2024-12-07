namespace Restaurant.Domain.User.Client
{
    public class ClientModel : UserModel
    {
        public override List<UserRole> Roles => [UserRole.Client];
    }
}
