namespace Restaurant.Domain.User.Admin
{
    public class AdminModel : UserModel
    {
        public override UserRole Role => UserRole.Admin;
    }
}
