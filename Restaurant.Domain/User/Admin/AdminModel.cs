namespace Restaurant.Domain.User.Admin
{
    public class AdminModel : UserModel
    {
        protected override UserRole InitRole => UserRole.Admin;
    }
}
