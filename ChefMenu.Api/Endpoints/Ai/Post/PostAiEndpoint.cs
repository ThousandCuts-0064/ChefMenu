using ChefMenu.Api.Endpoints.Core;
using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Web;

namespace ChefMenu.Api.Endpoints.Ai.Post;

public struct PostAiEndpoint : IEndpoint
{
    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder.MapPost("", async(IGenerativeModelService ai) =>
        {
            var result = await ai.Model.GenerateContent(new GenerateContentRequest("Tell me a recipe."));

            return result.Text;
        });
    }
}