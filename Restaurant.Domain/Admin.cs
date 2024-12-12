namespace Restaurant.Domain
{
    public class Admin : User
    {
        public override List<UserPermission> Permissions => [UserPermission.Admin, UserPermission.Client];
    }
}
