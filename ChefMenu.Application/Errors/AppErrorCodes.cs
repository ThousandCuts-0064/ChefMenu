using ChefMenu.Domain.Errors;

namespace ChefMenu.Application.Errors;

using static ErrorSections;
using static AppErrorSections;

public static class AppErrorCodes
{
    public const string IncorrectPageSize = $"{App}{_}{User}{_}{PageSize}{_}{Incorrect}";

    public const string UserIdNotFound = $"{App}{_}{User}{_}{Id}{_}{NotFound}";
    public const string UserIdCannotBeMe = $"{App}{_}{User}{_}{Id}{_}{CannotBeMe}";
    public const string UsernameDuplicate = $"{App}{_}{User}{_}{Username}{_}{Duplicate}";
    public const string IncorrectCredentials = $"{App}{_}{User}{_}{Credentials}{_}{Incorrect}";
    public const string InsufficientUserRole = $"{App}{_}{User}{_}{UserRole}{_}{Insufficient}";

    public const string CategoryIdNotFound = $"{App}{_}{Category}{_}{Id}{_}{NotFound}";
    public const string CategoryNameDuplicate = $"{App}{_}{Category}{_}{Name}{_}{Duplicate}";

    public const string IngredientIdNotFound = $"{App}{_}{Ingredient}{_}{Id}{_}{NotFound}";
    public const string IngredientNameDuplicate = $"{App}{_}{Ingredient}{_}{Name}{_}{Duplicate}";

    public const string KitchenwareIdNotFound = $"{App}{_}{Kitchenware}{_}{Id}{_}{NotFound}";
    public const string KitchenwareNameDuplicate = $"{App}{_}{Kitchenware}{_}{Name}{_}{Duplicate}";

    public const string KeywordIdNotFound = $"{App}{_}{Keyword}{_}{Id}{_}{NotFound}";
    public const string KeywordNameDuplicate = $"{App}{_}{Keyword}{_}{Name}{_}{Duplicate}";

    public const string RecipeIdNotFound = $"{App}{_}{Recipe}{_}{Id}{_}{NotFound}";
    public const string RecipeNameDuplicate = $"{App}{_}{Recipe}{_}{Name}{_}{Duplicate}";

    public const string RecipeCollectionIdNotFound = $"{App}{_}{RecipeCollection}{_}{Id}{_}{NotFound}";
    public const string RecipeCollectionNameDuplicate = $"{App}{_}{RecipeCollection}{_}{Name}{_}{Duplicate}";
}