using System.Text.RegularExpressions;
using WebApi_Minimal.Domain.Services.Interfaces;

namespace WebApi_Minimal.Domain.Services
{
    public class PasswordManager : IPasswordManager
    {
        public bool CheckPassword(string password)
        {
            // Para uma senha ser válida ela deve atender as seguintes regras:

            if (string.IsNullOrEmpty(password))
                return false;

            // - Nove ou mais caracteres
            if (password.Length < 9)
                return false;

            int chars = 0;

            // - Ao menos 1 dígito
            chars = password.Length - Regex.Replace(password, "[0-9]", "").Length;
            if (chars == 0)
                return false;

            // - Ao menos 1 letra maiúscula
            chars = password.Length - Regex.Replace(password, "[A-Z]", "").Length;
            if (chars == 0)
                return false;

            // - Ao menos 1 letra minúscula
            chars = password.Length - Regex.Replace(password, "[a-z]", "").Length;
            if (chars == 0)
                return false;

            // - Não possuir caracteres repetidos dentro do conjunto
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");
            if (regex.IsMatch(password))
                return false;

            // - Ao menos 1 caractere especial dentro de "!@#$%^&*()-+"
            char[] aPattern = "!@#$%^&*()-+".ToCharArray();
            if (password.IndexOfAny(aPattern) <= 0)
                return false;

            return true;
        }
    }
}