using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace MultUsersAuthentication_API.ServicesConfiguration;

public static class Identity
{
    public static IdentityBuilder IdentityConfiguration(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddIdentity<User,IdentityRole>(o =>
                {
                    o.Password.RequireDigit = true;
                    o.Password.RequireLowercase = true;
                    o.Password.RequireNonAlphanumeric = true;
                    o.User.RequireUniqueEmail = true;
                    o.Password.RequireUppercase = true;
                }
            ).AddEntityFrameworkStores<DbContext>()
            .AddDefaultTokenProviders();
    }
}