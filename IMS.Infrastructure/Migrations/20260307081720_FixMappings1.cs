using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMappings1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_ApplicationUserRoles_ApplicationUserRoleId",
                schema: "ims",
                table: "UserRoleMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_ApplicationUsers_ApplicationUserId",
                schema: "ims",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_ApplicationUserId",
                schema: "ims",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_ApplicationUserRoleId",
                schema: "ims",
                table: "UserRoleMappings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "ims",
                table: "UserRoleMappings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserRoleId",
                schema: "ims",
                table: "UserRoleMappings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                schema: "ims",
                table: "UserRoleMappings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserRoleId",
                schema: "ims",
                table: "UserRoleMappings",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_ApplicationUserRoles_ApplicationUserRoleId",
                schema: "ims",
                table: "UserRoleMappings",
                column: "ApplicationUserRoleId",
                principalSchema: "ims",
                principalTable: "ApplicationUserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_ApplicationUsers_ApplicationUserId",
                schema: "ims",
                table: "UserRoleMappings",
                column: "ApplicationUserId",
                principalSchema: "ims",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");
        }
    }
}
