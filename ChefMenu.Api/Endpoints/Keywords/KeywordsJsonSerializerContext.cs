using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Keywords.Post;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Keywords.Commands.Create.Results;

namespace ChefMenu.Api.Endpoints.Keywords;

[JsonSerializable(typeof(PostKeywordRequest))]
[JsonSerializable(typeof(KeywordCreatedResult))]
[JsonSerializable(typeof(KeywordNameAlreadyExists))]
internal partial class KeywordsJsonSerializerContext : ApiJsonSerializerContext;
