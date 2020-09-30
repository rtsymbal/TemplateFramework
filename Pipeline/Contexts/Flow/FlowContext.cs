using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace TemplateFramework.Pipeline.Contexts.Flow
{
    public abstract class FlowContext : IExecutionContext
    {
        private readonly List<Type> _types = new List<Type>();

        public abstract FlowPrefix FlowPrefix { get; }

        public void AddContextBindings(IKernel kernel)
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.FullName.StartsWith("ShopAutotests"))
                .SelectMany(a => a.GetTypes())
                .Where(t =>
                    t.Name.StartsWith(FlowPrefix.ToString()) &&
                    typeof(IStep).IsAssignableFrom(t) &&
                    !t.IsAbstract && !t.IsInterface)
                .ToList();

            foreach (var type in types)
            {
                kernel.Bind(type.BaseType).To(type);
                _types.Add(type.BaseType);
            }
        }

        public void RemoveContextBindings(IKernel kernel)
        {
            foreach (var registeredType in _types)
            {
                kernel.Unbind(registeredType);
            }
        }

    }
}
