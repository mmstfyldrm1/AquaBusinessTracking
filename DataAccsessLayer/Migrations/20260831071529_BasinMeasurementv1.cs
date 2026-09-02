using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class BasinMeasurementv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Db_BasinMeasurement",
                newName: "RecId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Db_BasinMeasurement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Db_BasinMeasurement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Db_BasinMeasurement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Db_BasinMeasurement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "InUse",
                table: "Db_BasinMeasurement",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Db_BasinMeasurement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_BasinMeasurement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Db_BasinMeasurement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Db_BasinMeasurement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Db_BasinMeasurement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Db_BasinMeasurement_AppUserId",
                table: "Db_BasinMeasurement",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BasinMeasurement_DepartmentId",
                table: "Db_BasinMeasurement",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BasinMeasurement_ShiftId",
                table: "Db_BasinMeasurement",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BasinMeasurement_AspNetUsers_AppUserId",
                table: "Db_BasinMeasurement",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BasinMeasurement_Db_Department_DepartmentId",
                table: "Db_BasinMeasurement",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BasinMeasurement_Db_Shift_ShiftId",
                table: "Db_BasinMeasurement",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_BasinMeasurement_AspNetUsers_AppUserId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_BasinMeasurement_Db_Department_DepartmentId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_BasinMeasurement_Db_Shift_ShiftId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropIndex(
                name: "IX_Db_BasinMeasurement_AppUserId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropIndex(
                name: "IX_Db_BasinMeasurement_DepartmentId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropIndex(
                name: "IX_Db_BasinMeasurement_ShiftId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "InUse",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Db_BasinMeasurement");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Db_BasinMeasurement");

            migrationBuilder.RenameColumn(
                name: "RecId",
                table: "Db_BasinMeasurement",
                newName: "Id");
        }
    }
}
