using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class uniaqunesDepName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_departments_DepID",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_departments_DepartmentDepId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudId",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentDepId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "DepartmentDepId",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "Pk_StudId",
                table: "Student",
                column: "StudId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepId",
                table: "Student",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Name",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Department_DepID",
                table: "DepartmetSubjects",
                column: "DepID",
                principalTable: "Department",
                principalColumn: "DepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DepId",
                table: "Student",
                column: "DepId",
                principalTable: "Department",
                principalColumn: "DepId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Student_StudId",
                table: "StudentSubjects",
                column: "StudId",
                principalTable: "Student",
                principalColumn: "StudId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Department_DepID",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DepId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Student_StudId",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "Pk_StudId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DepId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_Name",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "departments");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDepId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentDepId",
                table: "Students",
                column: "DepartmentDepId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_departments_DepID",
                table: "DepartmetSubjects",
                column: "DepID",
                principalTable: "departments",
                principalColumn: "DepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_departments_DepartmentDepId",
                table: "Students",
                column: "DepartmentDepId",
                principalTable: "departments",
                principalColumn: "DepId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudId",
                table: "StudentSubjects",
                column: "StudId",
                principalTable: "Students",
                principalColumn: "StudId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
