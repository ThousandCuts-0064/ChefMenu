using System.Linq.Expressions;
using ChefMenu.Application.Core.Results;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;

namespace ChefMenu.Application.Features.Categories.Queries.Get.Results;

public sealed class CategoryResult : IResult
{
    public required CategoryId Id { get; init; }
    public required CategoryName Name { get; init; }
    public required DisplayName DisplayName { get; set; }
    public required Description? Description { get; set; }
    public required Uri? ImageUri { get; set; }
    public required CategoryType? Type { get; set; }

    public static Expression<Func<Category, CategoryResult>> FromEntity { get; } = x => new CategoryResult
    {
        Id = x.Id,
        Name = x.Name,
        DisplayName = x.DisplayName,
        Description = x.Description,
        ImageUri = x.ImageUri,
        Type = x.Type
    };
}