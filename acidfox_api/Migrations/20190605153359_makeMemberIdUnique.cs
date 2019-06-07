using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace acidfox_api.Migrations
{
    public partial class makeMemberIdUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_MemberId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberId",
                table: "Members",
                column: "MemberId",
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "Last_Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_MemberId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberId",
                table: "Members",
                column: "MemberId")
                .Annotation("Npgsql:IndexInclude", new[] { "Last_Name" });
        }
    }
}
