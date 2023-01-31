namespace WebApi_Minimal.Domain.Services.Interfaces
{
    public interface IPasswordManager
    {
        bool CheckPassword(string password);
    }
}