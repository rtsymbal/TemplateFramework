using TemplateFramework.Models;

namespace TemplateFramework.Helpers
{
    public class UserFactory
    {
        private const string DefaultPassword = "1";

        public static User DefaultAdmin()
        {
            return new User
            {
                Email = "admin@example.com",
                Password = DefaultPassword
            };
        }

        public static User DefaultUser()
        {
            return new User
            {
                Email = "user@example.com",
                Password = DefaultPassword
            };
        }
    }
}
