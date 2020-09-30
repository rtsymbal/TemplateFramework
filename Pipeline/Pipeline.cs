using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TemplateFramework.Pipeline
{
    public class Pipeline
    {
        public void Run<T>(T step) where T : IStep
        {
            BeforeExecution(step);
            try
            {
                step.Execute();

                AfterExecution(step);
            }
            catch (Exception e)
            {
                AfterExecution(step, e);

                throw;
            }
        }

        private void BeforeExecution(IStep step)
        {
            // Log
            VerifyFieldsAndProperties(step);
        }


        private void AfterExecution(IStep step, Exception exception = null)
        {
            // Log
        }

        private static void VerifyFieldsAndProperties(IStep step)
        {
            foreach (var property in step.GetType().GetProperties())
            {
                var attribute = property.GetCustomAttribute<RequiredAttribute>();
                if (attribute != null && !attribute.IsValid(property.GetValue(step)))
                {
                    throw new ArgumentNullException($"'{property.Name}' property should be defined");
                }
            }
        }
    }
}
