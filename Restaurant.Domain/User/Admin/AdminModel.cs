namespace Restaurant.Domain.User.Admin
{
    public class AdminModel : UserModel
    {
        public override List<UserRole> Roles => [UserRole.Admin, UserRole.Client];
    }
}
