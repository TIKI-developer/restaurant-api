namespace Restaurant.Domain
{
    public class Client : User
    {
        public override List<UserPermission> Permissions => [UserPermission.Client];
    }
}
