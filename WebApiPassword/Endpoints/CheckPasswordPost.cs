using WebApi_Minimal.Domain.Services;

namespace WebApi_Minimal.Endpoints
{
    public class CheckPasswordPost
    {
        public static string Template => "api/password/check/{password}";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static bool Action(string password, PasswordManager passwordManager)
        {
            return passwordManager.CheckPassword(password);
        }
    }
}