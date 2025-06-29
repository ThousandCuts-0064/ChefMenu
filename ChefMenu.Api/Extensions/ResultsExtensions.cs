using System.Diagnostics;
using App = ChefMenu.Application.Core.Results;
using Http = Microsoft.AspNetCore.Http.HttpResults;
using IAppResult = ChefMenu.Application.Core.Results.IResult;
using IHttpResult = Microsoft.AspNetCore.Http.IResult;

namespace ChefMenu.Api.Extensions;

public static class ResultsExtensions
{
    public static Http.Results<TOut1, TOut2> MapToHttpResults<
        TIn1, TIn2,
        TOut1, TOut2>(
        this App.Results<TIn1, TIn2> results,
        Func<TIn1, TOut1> map1,
        Func<TIn2, TOut2> map2)
        where TIn1 : class, IAppResult
        where TIn2 : class, IAppResult
        where TOut1 : IHttpResult
        where TOut2 : IHttpResult
    {
        return results.Result switch
        {
            TIn1 t1 => map1(t1),
            TIn2 t2 => map2(t2),
            _ => throw new UnreachableException()
        };
    }

    public static Http.Results<TOut1, TOut2, TOut3> MapToHttpResults<
        TIn1, TIn2, TIn3,
        TOut1, TOut2, TOut3>(
        this App.Results<TIn1, TIn2, TIn3> results,
        Func<TIn1, TOut1> map1,
        Func<TIn2, TOut2> map2,
        Func<TIn3, TOut3> map3)
        where TIn1 : class, IAppResult
        where TIn2 : class, IAppResult
        where TIn3 : class, IAppResult
        where TOut1 : IHttpResult
        where TOut2 : IHttpResult
        where TOut3 : IHttpResult
    {
        return results.Result switch
        {
            TIn1 t1 => map1(t1),
            TIn2 t2 => map2(t2),
            TIn3 t3 => map3(t3),
            _ => throw new UnreachableException()
        };
    }

    public static Http.Results<TOut1, TOut2, TOut3, TOut4> MapToHttpResults<
        TIn1, TIn2, TIn3, TIn4,
        TOut1, TOut2, TOut3, TOut4>(
        this App.Results<TIn1, TIn2, TIn3, TIn4> results,
        Func<TIn1, TOut1> map1,
        Func<TIn2, TOut2> map2,
        Func<TIn3, TOut3> map3,
        Func<TIn4, TOut4> map4)
        where TIn1 : class, IAppResult
        where TIn2 : class, IAppResult
        where TIn3 : class, IAppResult
        where TIn4 : class, IAppResult
        where TOut1 : IHttpResult
        where TOut2 : IHttpResult
        where TOut3 : IHttpResult
        where TOut4 : IHttpResult
    {
        return results.Result switch
        {
            TIn1 t1 => map1(t1),
            TIn2 t2 => map2(t2),
            TIn3 t3 => map3(t3),
            TIn4 t4 => map4(t4),
            _ => throw new UnreachableException()
        };
    }

    public static Http.Results<TOut1, TOut2, TOut3, TOut4, TOut5> MapToHttpResults<
        TIn1, TIn2, TIn3, TIn4, TIn5,
        TOut1, TOut2, TOut3, TOut4, TOut5>(
        this App.Results<TIn1, TIn2, TIn3, TIn4, TIn5> results,
        Func<TIn1, TOut1> map1,
        Func<TIn2, TOut2> map2,
        Func<TIn3, TOut3> map3,
        Func<TIn4, TOut4> map4,
        Func<TIn5, TOut5> map5)
        where TIn1 : class, IAppResult
        where TIn2 : class, IAppResult
        where TIn3 : class, IAppResult
        where TIn4 : class, IAppResult
        where TIn5 : class, IAppResult
        where TOut1 : IHttpResult
        where TOut2 : IHttpResult
        where TOut3 : IHttpResult
        where TOut4 : IHttpResult
        where TOut5 : IHttpResult
    {
        return results.Result switch
        {
            TIn1 t1 => map1(t1),
            TIn2 t2 => map2(t2),
            TIn3 t3 => map3(t3),
            TIn4 t4 => map4(t4),
            TIn5 t5 => map5(t5),
            _ => throw new UnreachableException()
        };
    }

    public static Http.Results<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> MapToHttpResults<
        TIn1, TIn2, TIn3, TIn4, TIn5, TIn6,
        TOut1, TOut2, TOut3, TOut4, TOut5, TOut6>(
        this App.Results<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> results,
        Func<TIn1, TOut1> map1,
        Func<TIn2, TOut2> map2,
        Func<TIn3, TOut3> map3,
        Func<TIn4, TOut4> map4,
        Func<TIn5, TOut5> map5,
        Func<TIn6, TOut6> map6)
        where TIn1 : class, IAppResult
        where TIn2 : class, IAppResult
        where TIn3 : class, IAppResult
        where TIn4 : class, IAppResult
        where TIn5 : class, IAppResult
        where TIn6 : class, IAppResult
        where TOut1 : IHttpResult
        where TOut2 : IHttpResult
        where TOut3 : IHttpResult
        where TOut4 : IHttpResult
        where TOut5 : IHttpResult
        where TOut6 : IHttpResult
    {
        return results.Result switch
        {
            TIn1 t1 => map1(t1),
            TIn2 t2 => map2(t2),
            TIn3 t3 => map3(t3),
            TIn4 t4 => map4(t4),
            TIn5 t5 => map5(t5),
            TIn6 t6 => map6(t6),
            _ => throw new UnreachableException()
        };
    }
}