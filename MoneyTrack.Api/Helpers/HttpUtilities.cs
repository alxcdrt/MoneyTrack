using System.Net;
using LanguageExt;
using LanguageExt.Common;

namespace MoneyTrack.Api.Helpers;

public static class HttpUtilities
{
    public static IResult GetResult<T>(this Fin<T> source, Func<T, IResult> successFunc)
    {
        return source.Match(successFunc, GetHttpError);
    }

    private static IResult GetHttpError(Error error)
    {
        return (HttpStatusCode)error.Code switch
        {
            HttpStatusCode.BadRequest => Results.BadRequest(error.Message),
            _ => Results.StatusCode(500) 
        };
    }
}