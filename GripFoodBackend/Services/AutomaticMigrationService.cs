using GripFoodEntities;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace GripFoodBackend.Services
{
    public partial class AutomaticMigrationService
    {
        private readonly GripFoodDbContext _db;
        private readonly IOpenIddictApplicationManager _appManager;
        private readonly IOpenIddictScopeManager _scopeManager;

        public AutomaticMigrationService(
            GripFoodDbContext gripfoodDbContext,
            IOpenIddictApplicationManager openIddictApplicationManager,
            IOpenIddictScopeManager openIddictScopeManager
        )
        {
            _db = gripfoodDbContext;
            _appManager = openIddictApplicationManager;
            _scopeManager = openIddictScopeManager;
        }

        public async Task MigrateAsync(CancellationToken cancellationToken)
        {
            await CreateApiServerApp(cancellationToken);
            await CreateApiScope(cancellationToken);
            await CreateCmsApp(cancellationToken);
        }


        private async Task CreateApiServerApp(CancellationToken cancellationToken)
        {
            var exist = await _appManager.FindByClientIdAsync("api-server", cancellationToken);
            if (exist != null)
            {
                return;
            }

            await _appManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "api-server",
                DisplayName = "API Server",
                Type = ClientTypes.Confidential,
                ClientSecret = "HelloWorld1!",
                Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.Endpoints.Introspection,
                    Permissions.Endpoints.Revocation,
                    Permissions.GrantTypes.ClientCredentials
                }
            }, cancellationToken);

        }

        private async Task CreateApiScope(CancellationToken cancellationToken)
        {
            var exist = await _scopeManager.FindByNameAsync("api", cancellationToken);
            if (exist != null)
            {
                return;
            }

            await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "api",
                DisplayName = "API Scope",
                Resources =
                {
                    "api-server"
                }
            }, cancellationToken);
        }

        private async Task<string?> CreateCmsApp(CancellationToken cancellationToken)
        {
            var exist = await _appManager.FindByClientIdAsync("cms", cancellationToken);
            if (exist != null)
            {
                return await _appManager.GetIdAsync(exist, cancellationToken);
            }

            var o = await _appManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "cms",
                DisplayName = "CMS (Front-End)",
                RedirectUris = {
                    new Uri("http://localhost:3000/api/auth/callback/oidc"),
                    new Uri("https://oauth.pstmn.io/v1/callback")
                },
                Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.Endpoints.Authorization,
                    Permissions.Endpoints.Revocation,
                    Permissions.ResponseTypes.Code,
                    Permissions.GrantTypes.AuthorizationCode,
                    Permissions.GrantTypes.RefreshToken,
                    Permissions.Scopes.Profile,
                    Permissions.Scopes.Email,
                    Permissions.Scopes.Roles,
                    Permissions.Scopes.Phone,
                    Permissions.Scopes.Address,
                    Permissions.Prefixes.Scope + "api"
                },
                Type = ClientTypes.Public
            }, cancellationToken);

            return await _appManager.GetIdAsync(o, cancellationToken);
        }

    }
}
