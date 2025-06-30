using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Kitchenwares.Post;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Kitchenwares.Commands.Create.Results;

namespace ChefMenu.Api.Endpoints.Kitchenwares;

[JsonSerializable(typeof(PostKitchenwaresRequest))]
[JsonSerializable(typeof(KitchenwareCreatedResult))]
[JsonSerializable(typeof(KitchenwareNameAlreadyExists))]
internal partial class KitchenwaresJsonSerializerContext : ApiJsonSerializerContext;
