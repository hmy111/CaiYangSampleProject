// See https://aka.ms/new-console-template for more information

using PipelineSample;

var requestContext = new RequestContext()
{
    RequestName = "test",
    Hour = 5,
};

var builder = PipelineBuilder<RequestContext>.New(context =>
    {
        // 兜底
        Console.WriteLine($"{context.RequestName} {context.Hour}h apply failed");
    })
    .Use(next => context =>
    {
        if (context.Hour < 3)
        {
            Console.WriteLine("pass 1");
        }
        else
        {
            next(context);
        }
    })
    .Use((context, next) =>
    {
        if (context.Hour < 6)
        {
            Console.WriteLine("pass 2");
        }
        else
        {
            next();
        }
    });

builder.Build().Invoke(requestContext);
Console.Read();

List <Func<Action<RequestContext>, Action<RequestContext>> > funcs = new();
// 理解扩展方法
Func<Action<RequestContext>, Action<RequestContext>> testFunc = next => context =>
{
    Console.WriteLine("your code");
    next(context);
};
funcs.Add(testFunc);

// 简化为
Action<RequestContext, Action> testFunc1 = (context, next) =>
{
    Console.WriteLine("your code");
    next();
};

funcs.Add(next => context => testFunc1(context, () => next(context)));

public class RequestContext
{
    public string RequestName { get; set; } = string.Empty;

    public int Hour { get; set; }
}