using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Db.Migrations
{
    public partial class addImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "SubCategoryMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "BrandMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Brand = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Pincode = table.Column<string>(nullable: true),
                    ContactPerson1 = table.Column<string>(nullable: true),
                    Mobile1 = table.Column<string>(nullable: true),
                    ContactPerson2 = table.Column<string>(nullable: true),
                    Mobile2 = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceMaster");

            migrationBuilder.DropTable(
                name: "SupplierMaster");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "SubCategoryMaster");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "BrandMaster");
        }
    }
}
