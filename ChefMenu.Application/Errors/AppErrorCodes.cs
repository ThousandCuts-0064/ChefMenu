using ChefMenu.Domain.Errors;

namespace ChefMenu.Application.Errors;

using static ErrorSections;
using static AppErrorSections;

public static class AppErrorCodes
{
    public const string UsernameDuplicate = $"{App}{_}{User}{_}{Username}{_}{Duplicate}";
    public const string IncorrectCredentials = $"{App}{_}{User}{_}{Password}{_}{Incorrect}";
}