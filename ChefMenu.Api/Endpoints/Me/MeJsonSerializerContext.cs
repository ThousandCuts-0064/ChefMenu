using System.Text.Json.Serialization;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Me.Queries.Get.Results;

namespace ChefMenu.Api.Endpoints.Me;

[JsonSerializable(typeof(MeResult))]
internal partial class MeJsonSerializerContext : ApiJsonSerializerContext;
