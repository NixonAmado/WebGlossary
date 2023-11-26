namespace API.Helpers;

public class Authorization
{
    public enum Roles
        {
            Administrator,
            User
        }
        public const Roles rol_default = Roles.User;
}
