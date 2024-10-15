namespace Restaurant.Domain.User
{
    public class AdminModel : UserModel
    {
        public override UserRole Role => UserRole.Admin;
    }
}
