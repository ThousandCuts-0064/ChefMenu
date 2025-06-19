using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace ChefMenu.Application.Services.Passwords;

public sealed class PasswordHasherOptions
{
    [Required]
    public required string Secret { get; set; }
}

[OptionsValidator]
public partial class PasswordHasherOptionsValidator : IValidateOptions<PasswordHasherOptions>;