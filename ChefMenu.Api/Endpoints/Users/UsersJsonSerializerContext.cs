using System.Text.Json.Serialization;
using ChefMenu.Api.Endpoints.Users.PatchRole;
using ChefMenu.Api.JsonSerialization.JsonSerializerContexts;
using ChefMenu.Application.Features.Shared.Results;
using ChefMenu.Application.Features.Users.Commands.UpdateRole.Results;
using ChefMenu.Application.Features.Users.Queries.Search.Results;

namespace ChefMenu.Api.Endpoints.Users;

[JsonSerializable(typeof(SearchUsersResult))]
[JsonSerializable(typeof(UserIdNotFoundResult))]
[JsonSerializable(typeof(PatchUsersRoleRequest))]
[JsonSerializable(typeof(UserIdCannotBeMeResult))]
internal sealed partial class UsersJsonSerializerContext : ApiJsonSerializerContext;