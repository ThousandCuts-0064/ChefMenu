using ChefMenu.Application.Core.Features;
using ChefMenu.Application.Core.Mediators;
using ChefMenu.Application.Features.Keywords.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace ChefMenu.Application.Features.Keywords;

public struct KeywordsFeature : IFeature
{
    public static IServiceCollection Add(IServiceCollection services) => services
        .AddCommand<CreateKeywordCommand, CreateKeywordCommandHandler>();
}