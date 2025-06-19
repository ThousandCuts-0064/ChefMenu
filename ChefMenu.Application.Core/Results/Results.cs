using System.Diagnostics;

namespace ChefMenu.Application.Core.Results;

public class Results<T1, T2> : INestedResult
    where T1 : class, IResult
    where T2 : class, IResult
{
    public IResult Result { get; }

    private Results(IResult result) => Result = result;

    public TResult Map<TResult>(
        Func<T1, TResult> map1,
        Func<T2, TResult> map2)
    {
        return Result switch
        {
            T1 t1 => map1(t1),
            T2 t2 => map2(t2),
            _ => throw new UnreachableException()
        };
    }

    public static implicit operator Results<T1, T2>(T1 result) => new(result);
    public static implicit operator Results<T1, T2>(T2 result) => new(result);
}

public class Results<T1, T2, T3> : INestedResult
    where T1 : class, IResult
    where T2 : class, IResult
    where T3 : class, IResult
{
    public IResult Result { get; }

    private Results(IResult result) => Result = result;

    public TResult Map<TResult>(
        Func<T1, TResult> map1,
        Func<T2, TResult> map2,
        Func<T3, TResult> map3)
    {
        return Result switch
        {
            T1 t1 => map1(t1),
            T2 t2 => map2(t2),
            T3 t3 => map3(t3),
            _ => throw new UnreachableException()
        };
    }

    public static implicit operator Results<T1, T2, T3>(T1 result) => new(result);
    public static implicit operator Results<T1, T2, T3>(T2 result) => new(result);
    public static implicit operator Results<T1, T2, T3>(T3 result) => new(result);
}

public class Results<T1, T2, T3, T4> : INestedResult
    where T1 : class, IResult
    where T2 : class, IResult
    where T3 : class, IResult
    where T4 : class, IResult
{
    public IResult Result { get; }

    private Results(IResult result) => Result = result;

    public TResult Map<TResult>(
        Func<T1, TResult> map1,
        Func<T2, TResult> map2,
        Func<T3, TResult> map3,
        Func<T4, TResult> map4)
    {
        return Result switch
        {
            T1 t1 => map1(t1),
            T2 t2 => map2(t2),
            T3 t3 => map3(t3),
            T4 t4 => map4(t4),
            _ => throw new UnreachableException()
        };
    }

    public static implicit operator Results<T1, T2, T3, T4>(T1 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4>(T2 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4>(T3 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4>(T4 result) => new(result);
}

public class Results<T1, T2, T3, T4, T5> : INestedResult
    where T1 : class, IResult
    where T2 : class, IResult
    where T3 : class, IResult
    where T4 : class, IResult
    where T5 : class, IResult
{
    public IResult Result { get; }

    private Results(IResult result) => Result = result;

    public TResult Map<TResult>(
        Func<T1, TResult> map1,
        Func<T2, TResult> map2,
        Func<T3, TResult> map3,
        Func<T4, TResult> map4,
        Func<T5, TResult> map5)
    {
        return Result switch
        {
            T1 t1 => map1(t1),
            T2 t2 => map2(t2),
            T3 t3 => map3(t3),
            T4 t4 => map4(t4),
            T5 t5 => map5(t5),
            _ => throw new UnreachableException()
        };
    }

    public static implicit operator Results<T1, T2, T3, T4, T5>(T1 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5>(T2 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5>(T3 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5>(T4 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5>(T5 result) => new(result);
}

public class Results<T1, T2, T3, T4, T5, T6> : INestedResult
    where T1 : class, IResult
    where T2 : class, IResult
    where T3 : class, IResult
    where T4 : class, IResult
    where T5 : class, IResult
    where T6 : class, IResult
{
    public IResult Result { get; }

    private Results(IResult result) => Result = result;

    public TResult Map<TResult>(
        Func<T1, TResult> map1,
        Func<T2, TResult> map2,
        Func<T3, TResult> map3,
        Func<T4, TResult> map4,
        Func<T5, TResult> map5,
        Func<T6, TResult> map6)
    {
        return Result switch
        {
            T1 t1 => map1(t1),
            T2 t2 => map2(t2),
            T3 t3 => map3(t3),
            T4 t4 => map4(t4),
            T5 t5 => map5(t5),
            T6 t6 => map6(t6),
            _ => throw new UnreachableException()
        };
    }

    public static implicit operator Results<T1, T2, T3, T4, T5, T6>(T1 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5, T6>(T2 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5, T6>(T3 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5, T6>(T4 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5, T6>(T5 result) => new(result);
    public static implicit operator Results<T1, T2, T3, T4, T5, T6>(T6 result) => new(result);
}