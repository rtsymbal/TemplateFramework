using System;
using System.Collections.Generic;
using Ninject;
using TemplateFramework.Pipeline.Contexts;

namespace TemplateFramework.Pipeline
{
    public class Scope
    {
        private readonly IKernel _kernel;
        private readonly List<IExecutionContext> _contexts;

        public Scope(IKernel kernel)
        {
            _kernel = kernel;
            _contexts = new List<IExecutionContext>();
        }

        public void AddContext(IExecutionContext context)
        {
            context.AddContextBindings(_kernel);
            _contexts.Add(context);
        }

        public void AddContext(IEnumerable<IExecutionContext> contexts)
        {
            foreach (var context in contexts)
            {
                AddContext(context);
            }
        }

        public void Execute(Action action)
        {
            if (_contexts.Count == 0)
            {
                throw new ArgumentException("Any context was not added");
            }

            action.Invoke();
            UnbindContext();
        }

        private void UnbindContext()
        {
            foreach (var executionContext in _contexts)
            {
                executionContext.RemoveContextBindings(_kernel);
            }
        }
    }
}
