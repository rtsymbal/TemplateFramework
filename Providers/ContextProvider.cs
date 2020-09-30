using TemplateFramework.Helpers;
using TemplateFramework.Pipeline.Contexts.User;

namespace TemplateFramework.Providers
{
    public class ContextProvider
    {
        public UserContext Admin => new UserContext(UserFactory.DefaultAdmin());
        public UserContext User => new UserContext(UserFactory.DefaultUser());
    }
}
