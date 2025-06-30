using ChefMenu.Api.Endpoints.Core;
using Microsoft.AspNetCore.Mvc;
using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Web;

namespace ChefMenu.Api.Endpoints.Ai.Post;

public struct PostAiEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("", async(
            [FromBody] string text,
            IGenerativeModelService ai) =>
        {
            var result = await ai.Model.GenerateContent(new GenerateContentRequest(text));

            return result.Text;
        });
    }
}