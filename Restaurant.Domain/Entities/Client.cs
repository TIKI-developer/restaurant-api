namespace Restaurant.Domain.Entities
{
    public class Client : User
    {
        public override List<UserPermission> Permissions => [UserPermission.Client];
    }
}
