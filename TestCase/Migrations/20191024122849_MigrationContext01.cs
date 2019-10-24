using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestCase.Migrations
{
    public partial class MigrationContext01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    Class = table.Column<string>(maxLength: 50, nullable: false),
                    DateRelease = table.Column<DateTime>(nullable: false),
                    RegistrationNumber = table.Column<string>(maxLength: 50, nullable: false),
                    TimeAdd = table.Column<DateTimeOffset>(nullable: true),
                    TimeModified = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    NumberDL = table.Column<string>(maxLength: 50, nullable: false),
                    TimeAdd = table.Column<DateTimeOffset>(nullable: true),
                    TimeModified = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    UsertId = table.Column<Guid>(nullable: false),
                    Information = table.Column<string>(maxLength: 255, nullable: true),
                    TimeStart = table.Column<DateTimeOffset>(nullable: false),
                    TimeEnd = table.Column<DateTimeOffset>(nullable: false),
                    TimeAdd = table.Column<DateTimeOffset>(nullable: true),
                    TimeModified = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UsertId",
                        column: x => x.UsertId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CarId",
                table: "Order",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UsertId",
                table: "Order",
                column: "UsertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
