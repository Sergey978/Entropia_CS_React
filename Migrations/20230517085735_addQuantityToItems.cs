using Microsoft.EntityFrameworkCore.Migrations;

namespace SignupVerTutor.Migrations
{
    public partial class addQuantityToItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UserStandartItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CustomItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UserStandartItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CustomItems");
        }
    }
}
