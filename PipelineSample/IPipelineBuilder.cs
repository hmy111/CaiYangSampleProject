namespace PipelineSample;

/// <summary>
/// 中间件管道构造器
/// </summary>
/// <typeparam name="TContext">上下文信息，用来在各个中间件间共享传递信息</typeparam>
public interface IPipelineBuilder<TContext>
{
    /// <summary>
    /// 把执行方法加入管道
    /// </summary>
    /// <param name="middleware">中间件执行方法</param>
    /// <remarks>
    /// 假设有3个步骤， A ， B， C
    /// 那么 参数middleware给后续调用的代表就是
    /// Func_C_B 参数为C, B
    /// Func_C_B_A 参数为 Func_C_B, A
    /// </remarks>>
    /// <returns></returns>
    IPipelineBuilder<TContext> Use(Func<Action<TContext>, Action<TContext>> middleware);
    Action<TContext> Build();
}

public class PipelineBuilder<TContext> : IPipelineBuilder<TContext>
{
    private readonly Action<TContext> _completeFunc;
    private readonly IList<Func<Action<TContext>, Action<TContext>>> _pipelines = new List<Func<Action<TContext>, Action<TContext>>>();

    public PipelineBuilder(Action<TContext> completeFunc)
    {
        _completeFunc = completeFunc;
    }

    public IPipelineBuilder<TContext> Use(Func<Action<TContext>, Action<TContext>> middleware)
    {
        _pipelines.Add(middleware);
        return this;
    }

    public static PipelineBuilder<TContext> New(Action<TContext> completeFunc)
    {
        return new PipelineBuilder<TContext>(completeFunc);
    }

    // 假设
    public Action<TContext> Build()
    {
        var request = _completeFunc;
        foreach (var pipeline in _pipelines.Reverse())
        {
            request = pipeline(request);
        }
        return request;
    }
}