namespace IMS.Infrastructure.Data.Configurations;

public class UserRoleMappingConfiguration : IEntityTypeConfiguration<UserRoleMapping>
{
    public void Configure(EntityTypeBuilder<UserRoleMapping> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasConversion(role => role.Value, val => UserRoleMappingId.Of(val));

        builder
            .Property(x => x.RoleId)
            .HasConversion(x => x.Value, val => ApplicationUserRoleId.Of(val));

        builder
            .Property(x => x.UserId)
            .HasConversion(x => x.Value, val => ApplicationUserId.Of(val));

        // builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(m => m.UserId);
        // builder.HasOne<ApplicationUserRole>().WithMany().HasForeignKey(m => m.RoleId);
    }
}
