namespace PipelineSample;

public class Builder
{
    public static IPipelineBuilder<TContext> Create<TContext>(Action<TContext> completeAction)
    {
        return new PipelineBuilder<TContext>(completeAction);
    }

    public static IAsyncPipelineBuilder<TContext> CreateAsync<TContext>(Func<TContext, Task> completeFunc)
    {
        return new AsyncPipelineBuilder<TContext>(completeFunc);
    }
}