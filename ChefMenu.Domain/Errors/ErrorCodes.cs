namespace ChefMenu.Domain.Errors;

using static ErrorSections;

public static class ErrorCodes
{
    public const string InvalidUserId = $"{Domain}{_}{User}{_}{Id}{_}{Invalid}";
    public const string InvalidUsername = $"{Domain}{_}{User}{_}{Username}{_}{Invalid}";
    public const string InvalidPassword = $"{Domain}{_}{User}{_}{Password}{_}{Invalid}";
    public const string InvalidEmail = $"{Domain}{_}{User}{_}{Email}{_}{Invalid}";

    public const string InvalidKitchenwareId = $"{Domain}{_}{Kitchenware}{_}{Id}{_}{Invalid}";
    public const string InvalidKitchenwareName = $"{Domain}{_}{Kitchenware}{_}{Name}{_}{Invalid}";

    public const string InvalidKeywordId = $"{Domain}{_}{Keyword}{_}{Id}{_}{Invalid}";
    public const string InvalidKeywordName = $"{Domain}{_}{Keyword}{_}{Name}{_}{Invalid}";

    public const string InvalidCategoryId = $"{Domain}{_}{Category}{_}{Id}{_}{Invalid}";
    public const string InvalidCategoryName = $"{Domain}{_}{Category}{_}{Name}{_}{Invalid}";

    public const string InvalidIngredientId = $"{Domain}{_}{Ingredient}{_}{Id}{_}{Invalid}";
    public const string InvalidIngredientName = $"{Domain}{_}{Ingredient}{_}{Name}{_}{Invalid}";

    public const string InvalidRecipeId = $"{Domain}{_}{Recipe}{_}{Id}{_}{Invalid}";
    public const string InvalidRecipeName = $"{Domain}{_}{Recipe}{_}{Name}{_}{Invalid}";

    public const string InvalidCommentId = $"{Domain}{_}{Comment}{_}{Id}{_}{Invalid}";

    public const string InvalidRecipeCollectionId = $"{Domain}{_}{RecipeCollection}{_}{Id}{_}{Invalid}";
    public const string InvalidRecipeCollectionName = $"{Domain}{_}{RecipeCollection}{_}{Name}{_}{Invalid}";

    public const string InvalidQuantity = $"{Domain}{_}{Shared}{_}{Quantity}{_}{Invalid}";

    public const string InvalidUserFeedbackId = $"{Domain}{_}{UserFeedback}{_}{Id}{_}{Invalid}";

    public const string InvalidSystemActionHistoryId = $"{Domain}{_}{SystemActionHistory}{_}{Id}{_}{Invalid}";

}