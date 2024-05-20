using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_departments_DepId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDepId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentDepId",
                table: "Students",
                column: "DepartmentDepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_departments_DepartmentDepId",
                table: "Students",
                column: "DepartmentDepId",
                principalTable: "departments",
                principalColumn: "DepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_departments_DepartmentDepId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentDepId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentDepId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepId",
                table: "Students",
                column: "DepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_departments_DepId",
                table: "Students",
                column: "DepId",
                principalTable: "departments",
                principalColumn: "DepId");
        }
    }
}
