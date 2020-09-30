namespace TemplateFramework.Pipeline.Contexts.Flow
{
    public class Flow
    {
        public static IExecutionContext Default()
        {
            return new DefaultFlowContext();
        }

        public static IExecutionContext Fast()
        {
            return new FastFlowContext();
        }
    }
}
