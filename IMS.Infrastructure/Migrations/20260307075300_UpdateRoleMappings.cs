using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleMappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRoles_ApplicationUsers_ApplicationUserId",
                schema: "ims",
                table: "ApplicationUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserRoles_ApplicationUserId",
                schema: "ims",
                table: "ApplicationUserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "ims",
                table: "ApplicationUserRoles");

            migrationBuilder.CreateTable(
                name: "UserRoleMappings",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationUserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_ApplicationUserRoles_ApplicationUserRoleId",
                        column: x => x.ApplicationUserRoleId,
                        principalSchema: "ims",
                        principalTable: "ApplicationUserRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_ApplicationUserRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ims",
                        principalTable: "ApplicationUserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "ims",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "ims",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_ApplicationUserId",
                schema: "ims",
                table: "UserRoleMappings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_ApplicationUserRoleId",
                schema: "ims",
                table: "UserRoleMappings",
                column: "ApplicationUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_RoleId",
                schema: "ims",
                table: "UserRoleMappings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_UserId",
                schema: "ims",
                table: "UserRoleMappings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleMappings",
                schema: "ims");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                schema: "ims",
                table: "ApplicationUserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_ApplicationUserId",
                schema: "ims",
                table: "ApplicationUserRoles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRoles_ApplicationUsers_ApplicationUserId",
                schema: "ims",
                table: "ApplicationUserRoles",
                column: "ApplicationUserId",
                principalSchema: "ims",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");
        }
    }
}
