using WebApi_Minimal.Domain.Services;
using WebApi_Minimal.Domain.Services.Interfaces;

namespace WebApiPasswordTest
{
    [TestClass]
    public class PasswordManagerTests
    {
        //----------------------------------------------------------------------------------
        //Testes:
        //  00- Null
        //  01- Vazio
        //  02- Nove ou mais caracteres
        //  03- Ao menos 1 dígito
        //  04- Ao menos 1 letra minúscula
        //  05- Ao menos 1 letra maiúscula
        //  06- Ao menos 1 caractere especial
        //  07- Considere como especial os seguintes caracteres: !@#$%^&*()-+
        //  08- Não possuir caracteres repetidos dentro do conjunto
        //----------------------------------------------------------------------------------

        public TestContext TestContext { get; set; }

        //Não colocar ready only em UnitTests
        private IPasswordManager _passwordManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _passwordManager = new PasswordManager();
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void NullPassword()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = null;

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsFalse(result);

            //testContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()} ");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void EmptyPassword()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsFalse(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void IncorrectPasswordLenght()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "aa";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------

            Assert.IsFalse(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void PasswordWithNoDigit()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "abcdefghij";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsFalse(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void PasswordWithNoUpperCase()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "a90bnhkl56";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsFalse(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void PasswordWithNoLowerCase()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "ADB78MJKLF4";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsFalse(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void PasswordWithNoSpecialChar()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "Ab4jk78Tff3";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsFalse(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void PasswordWithWrongSpecialChar()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "asdfgt5Thkk8r[";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsFalse(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Negative test")]
        public void PasswordWithRepetedChar()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "aabb55yfdfl88aaa";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsFalse(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Positive test")]
        public void PasswordIsCorrect()
        {
            //ARRANGE --------------------------------------------------------
            string testPassword = "AcZp7*bar";

            //ACT ------------------------------------------------------------
            var result = _passwordManager.CheckPassword(testPassword);

            //ASSERT-----------------------------------------------------------
            Assert.IsTrue(result);
            TestContext.WriteLine($"Input: {testPassword.ToString()} |  Expected: False | Result: {result.ToString()}");
        }
    }
}