using Microsoft.AspNetCore.Mvc;
using WebApi_Minimal.Domain.Services.Interfaces;

namespace WebApi_Minimal.Endpoints
{
    public class CheckPasswordPost
    {
        public static string Template => "api/password/check/{password}";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        private readonly IPasswordManager _passwordManager;

        public CheckPasswordPost(IPasswordManager passwordManager)
        {
            _passwordManager = passwordManager;
        }

        public static bool Action(string password, [FromServices] IPasswordManager passwordManager)
        {
            return passwordManager.CheckPassword(password);
        }
    }
}