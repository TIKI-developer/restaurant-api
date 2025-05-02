namespace Restaurant.Domain.Entities
{
    public class Admin : User
    {
        public override List<UserPermission> Permissions => [UserPermission.Admin, UserPermission.Client];
    }
}
