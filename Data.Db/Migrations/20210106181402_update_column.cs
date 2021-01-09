using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Db.Migrations
{
    public partial class update_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SubCategoryMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SubCategoryMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "SubCategoryMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SubCategoryMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SubCategoryMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "CategoryMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "CategoryMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CategoryMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CategoryMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "BrandMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BrandMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "BrandMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "BrandMaster",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BrandMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TollFreeNo",
                table: "BrandMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "BrandMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SubCategoryMaster");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SubCategoryMaster");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SubCategoryMaster");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SubCategoryMaster");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SubCategoryMaster");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CategoryMaster");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CategoryMaster");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CategoryMaster");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CategoryMaster");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CategoryMaster");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BrandMaster");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BrandMaster");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BrandMaster");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "BrandMaster");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BrandMaster");

            migrationBuilder.DropColumn(
                name: "TollFreeNo",
                table: "BrandMaster");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "BrandMaster");
        }
    }
}
