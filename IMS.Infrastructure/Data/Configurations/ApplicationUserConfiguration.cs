namespace IMS.Infrastructure.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasConversion(user => user.Value, val => ApplicationUserId.Of(val));

        builder.HasMany(u => u.UserRoles).WithOne().HasForeignKey(r => r.UserId);

        builder.ComplexProperty(
            u => u.UserPreferences,
            prefBuilder =>
            {
                prefBuilder.Property(p => p.IsDarkModeEnabled).HasDefaultValue(false);
            }
        );
    }
}
