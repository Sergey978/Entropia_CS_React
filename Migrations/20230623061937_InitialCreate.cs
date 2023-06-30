using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SignupVerTutor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        AcceptTerms = table.Column<bool>(type: "bit", nullable: false),
                        Role = table.Column<int>(type: "int", nullable: false),
                        VerificationToken = table.Column<string>(
                            type: "nvarchar(max)",
                            nullable: true
                        ),
                        Verified = table.Column<DateTime>(type: "datetime2", nullable: true),
                        ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ResetTokenExpires = table.Column<DateTime>(
                            type: "datetime2",
                            nullable: true
                        ),
                        PasswordReset = table.Column<DateTime>(type: "datetime2", nullable: true),
                        Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                        Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "StandartItems",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartItems", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "CustomItems",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "5000, 1"),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                        Selected = table.Column<bool>(type: "bit", nullable: false),
                        BeginQuantity = table.Column<int>(type: "int", nullable: false),
                        Markup = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                        PurchasePrice = table.Column<decimal>(
                            type: "decimal(18,2)",
                            nullable: false
                        ),
                        Quantity = table.Column<int>(type: "int", nullable: false),
                        Step = table.Column<int>(type: "int", nullable: false),
                        AccountId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomItems_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        AccountId = table.Column<int>(type: "int", nullable: false),
                        Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                        Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                        CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                        RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ReplacedByToken = table.Column<string>(
                            type: "nvarchar(max)",
                            nullable: true
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "UserStandartItems",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        StandartItemId = table.Column<int>(type: "int", nullable: false),
                        Selected = table.Column<bool>(type: "bit", nullable: false),
                        BeginQuantity = table.Column<int>(type: "int", nullable: false),
                        Quantity = table.Column<int>(type: "int", nullable: false),
                        Markup = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                        PurchasePrice = table.Column<decimal>(
                            type: "decimal(18,2)",
                            nullable: false
                        ),
                        Step = table.Column<int>(type: "int", nullable: false),
                        AccountId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStandartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStandartItems_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_UserStandartItems_StandartItems_StandartItemId",
                        column: x => x.StandartItemId,
                        principalTable: "StandartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_CustomItems_AccountId",
                table: "CustomItems",
                column: "AccountId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserStandartItems_AccountId",
                table: "UserStandartItems",
                column: "AccountId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_UserStandartItems_StandartItemId",
                table: "UserStandartItems",
                column: "StandartItemId"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "CustomItems");

            migrationBuilder.DropTable(name: "RefreshToken");

            migrationBuilder.DropTable(name: "UserStandartItems");

            migrationBuilder.DropTable(name: "Accounts");

            migrationBuilder.DropTable(name: "StandartItems");
        }
    }
}
