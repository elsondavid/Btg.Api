using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Btg.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAtributosClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                schema: "dbo",
                table: "Clients",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Andress",
                schema: "dbo",
                table: "Clients",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Andress",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "Clients");
        }
    }
}
