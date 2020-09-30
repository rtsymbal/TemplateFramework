using Ninject;

namespace TemplateFramework.Pipeline.Contexts.User
{
    public class UserContext : IExecutionContext
    {
        public UserContext(Models.User user)
        {
            User = user;
        }

        public Models.User User { get; set; }

        public void AddContextBindings(IKernel kernel)
        {
            kernel.Bind<Models.User>().ToConstant(User);
        }

        public void RemoveContextBindings(IKernel kernel)
        {
            kernel.Unbind<Models.User>();
        }
    }
}
