namespace IMS.Infrastructure.Data.Configurations;

public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasConversion(role => role.Value, val => ApplicationUserRoleId.Of(val));

        builder.HasMany(r => r.UsersInRole).WithOne().HasForeignKey(r => r.RoleId);
    }
}
