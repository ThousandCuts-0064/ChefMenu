using System.Diagnostics;
using App = ChefMenu.Application.Core.Results;
using Http = Microsoft.AspNetCore.Http.HttpResults;
using IAppResult = ChefMenu.Application.Core.Results.IResult;
using IHttpResult = Microsoft.AspNetCore.Http.IResult;

namespace ChefMenu.Api.Extensions;

public static class ResultsExtensions
{
    public static Http.Results<TOut1, TOut2> MapToHttpResults<TIn1, TIn2, TOut1, TOut2>(
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
}