using ImageMagick;
using Ninject;

namespace TemplateFramework.Pipeline
{
    public class StepComposition : PipelineRunner
    {
        [Inject]
        public IKernel InjectedKernel
        {
            get => Kernel;
            set => Kernel = value;
        }

        [Inject]
        public Ninject.Activation.Pipeline InjectedPipeline
        {
            get => Pipeline;
            set => Pipeline = value;
        }
    }
}
