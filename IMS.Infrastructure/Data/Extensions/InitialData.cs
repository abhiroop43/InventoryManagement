using IMS.Core.Enums;
using IMS.Core.ValueObjects;

namespace IMS.Infrastructure.Data.Extensions;

public static class InitialData
{
    public static IEnumerable<Inventory> Inventories =>
        new List<Inventory>
        {
            Inventory.Add(
                InventoryId.Of(new Guid("6a7f4f72-cd00-4676-a99a-f718ad40937f")),
                InventoryName.Of("Bicycle Pedals"),
                50,
                QuantityType.Count,
                5.50m
            ),
            Inventory.Add(
                InventoryId.Of(new Guid("b36d926f-1b1d-46ef-bf3e-ac4e60c70ba6")),
                InventoryName.Of("Bicycle Seat"),
                20,
                QuantityType.Count,
                20m
            ),
            Inventory.Add(
                InventoryId.Of(new Guid("eabf36ff-97fe-496d-bb77-8be07b773f54")),
                InventoryName.Of("Bicycle Wheel"),
                40,
                QuantityType.Count,
                30m
            ),
        };

    public static IEnumerable<ApplicationUserRole> ApplicationUserRoles =>
        new List<ApplicationUserRole>
        {
            new()
            {
                Id = ApplicationUserRoleId.Of(new Guid("96942573-933F-4DED-8552-9F3569CA8C6B")),
                RoleCode = "ADMIN",
                RoleName = "Administrator",
            },
        };

    public static IEnumerable<ApplicationUser> ApplicationUsers
    {
        get
        {
            var genesisUser = ApplicationUser.Create(
                ApplicationUserId.Of(new Guid("51DE1EB4-F545-4163-87FB-D2511BEF8F26")),
                "abhiroop.santra@gmail.com",
                "00000000-0000-0000-2805-6271ffcad78f",
                "Abhiroop Santra"
            );
            genesisUser.AddUserToRoles(
                [
                    new UserRoleMapping
                    {
                        Id = UserRoleMappingId.Of(new Guid("B39209DD-11F5-4973-8EA7-A6C79164E215")),
                        UserId = ApplicationUserId.Of(
                            new Guid("51DE1EB4-F545-4163-87FB-D2511BEF8F26")
                        ),
                        RoleId = ApplicationUserRoleId.Of(
                            new Guid("96942573-933F-4DED-8552-9F3569CA8C6B")
                        ),
                    },
                ],
                ["ADMIN"]
            );

            return new List<ApplicationUser> { genesisUser };
        }
    }
}
