using Ninject;
using OpenQA.Selenium;
using System;
using TemplateFramework.Base.Extensions;
using TemplateFramework.PageObjects;
using TemplateFramework.Pipeline.Contexts;

namespace TemplateFramework.Pipeline
{

    public class PipelineRunner
    {
        protected IKernel Kernel;
        protected Ninject.Activation.Pipeline Pipeline;

        protected IWebDriver Driver => Kernel.GetDriver();
        protected Pages Pages => Kernel.GetPages();

        protected Scope InScopeOf(IExecutionContext context, params IExecutionContext[] contexts)
        {
            var scope = new Scope(Kernel);
            scope.AddContext(context);

            if (contexts != null) scope.AddContext(contexts);

            return scope;
        }

        protected void Do<T>(Action<T> stepSetupAction = null) where T : IStep
        {
            var step = Kernel.Get<T>();
            stepSetupAction?.Invoke(step);

            Pipeline.Run(step);
        }
    }
}
