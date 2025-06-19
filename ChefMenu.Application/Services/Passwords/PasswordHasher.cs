using System.Runtime.InteropServices;
using System.Security.Cryptography;
using ChefMenu.Domain.Features.Users.ValueObjects;
using Konscious.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace ChefMenu.Application.Services.Passwords;

internal sealed class PasswordHasher : IPasswordHasher
{
    private const int SaltLength = 16;
    private const int MemorySize = 64 * 1024;
    private const int Iterations = 4;
    private const int ResultLengt = 32;

    private readonly PasswordHasherOptions _options;

    public PasswordHasher(IOptions<PasswordHasherOptions> options) => _options = options.Value;

    public async Task<PasswordHash> HashAsync(Password password)
    {
        var passwordBytes = MemoryMarshal.AsBytes(password.Value.AsSpan()).ToArray();
        var secretBytes = MemoryMarshal.AsBytes(_options.Secret.AsSpan()).ToArray();
        var saltBytes = new byte[SaltLength];

        RandomNumberGenerator.Fill(saltBytes);

        using var argon = new Argon2id(passwordBytes)
        {
            Iterations = Iterations,
            MemorySize = MemorySize,
            DegreeOfParallelism = Environment.ProcessorCount,
            KnownSecret = secretBytes,
            Salt = saltBytes,
        };

        var resultBytes = await argon.GetBytesAsync(ResultLengt);

        return PasswordHash.Create(Convert.ToBase64String([.. resultBytes, .. saltBytes]));
    }

    public async Task<bool> IsCorrectAsync(Password password, PasswordHash passwordHash)
    {
        var passwordBytes = MemoryMarshal.AsBytes(password.Value.AsSpan()).ToArray();
        var secretBytes = MemoryMarshal.AsBytes(_options.Secret.AsSpan()).ToArray();
        var passwordHashBytes = Convert.FromBase64String(passwordHash);
        var saltBytes = passwordHashBytes[^SaltLength..];

        using var argon = new Argon2id(passwordBytes)
        {
            Iterations = Iterations,
            MemorySize = MemorySize,
            DegreeOfParallelism = Environment.ProcessorCount,
            KnownSecret = secretBytes,
            Salt = saltBytes,
        };

        var resultBytes = await argon.GetBytesAsync(ResultLengt);

        return passwordHashBytes.AsSpan()[..^SaltLength].SequenceEqual(resultBytes);
    }
}