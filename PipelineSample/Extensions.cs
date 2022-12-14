namespace PipelineSample;

public static class Extensions
{
    public static IPipelineBuilder<TContext> Use<TContext>(this IPipelineBuilder<TContext> builder,
        Action<TContext, Action> action)
    {
        return builder.Use(next => context =>
        {
            // 对应 next(); () => { next(context);}
            action(context, () => { next(context);});
        });
    }
    
    public static IAsyncPipelineBuilder<TContext> Use<TContext>(this IAsyncPipelineBuilder<TContext> builder,  Func<TContext, Func<Task>, Task> func)
    {
        return builder.Use(next =>
            context =>
            {
                return func(context, () => next(context));
            });
    }
}