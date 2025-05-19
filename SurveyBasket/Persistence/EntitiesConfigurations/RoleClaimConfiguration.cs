
namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
    {
        //Default Data
        var permissions = Permissions.GetAllPermissions();
        var adminClaims = new List<IdentityRoleClaim<string>>();

        int id = 1;
        foreach (var permission in permissions)
        {
            adminClaims.Add(new IdentityRoleClaim<string>
            {
                Id = id++,
                ClaimType = Permissions.Type,
                ClaimValue = permission,
                RoleId = DefaultRoles.AdminRoleId
            });
        }

        builder.HasData(adminClaims);
    }
}
