using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class udpateNullableColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Department_DepID",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Subjects_SubId",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Student_StudId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubId",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudId",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmetSubjects_DepID",
                table: "DepartmetSubjects");

            migrationBuilder.DropColumn(
                name: "StdSubjID",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "DeptSubID",
                table: "DepartmetSubjects");

            migrationBuilder.RenameTable(
                name: "StudentSubjects",
                newName: "StudentSubject");

            migrationBuilder.RenameTable(
                name: "DepartmetSubjects",
                newName: "DepartmetSubject");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_SubId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_SubId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmetSubjects_SubId",
                table: "DepartmetSubject",
                newName: "IX_DepartmetSubject_SubId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period",
                table: "Subjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<decimal>(
                name: "grade",
                table: "StudentSubject",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "Pk_StudId_SubId",
                table: "StudentSubject",
                columns: new[] { "StudId", "SubId" });

            migrationBuilder.AddPrimaryKey(
                name: "Pk_DepID_SubId",
                table: "DepartmetSubject",
                columns: new[] { "DepID", "SubId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubject_Department_DepID",
                table: "DepartmetSubject",
                column: "DepID",
                principalTable: "Department",
                principalColumn: "DepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubject_Subjects_SubId",
                table: "DepartmetSubject",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Student_StudId",
                table: "StudentSubject",
                column: "StudId",
                principalTable: "Student",
                principalColumn: "StudId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubId",
                table: "StudentSubject",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubject_Department_DepID",
                table: "DepartmetSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubject_Subjects_SubId",
                table: "DepartmetSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Student_StudId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubId",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "Pk_StudId_SubId",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "Pk_DepID_SubId",
                table: "DepartmetSubject");

            migrationBuilder.DropColumn(
                name: "grade",
                table: "StudentSubject");

            migrationBuilder.RenameTable(
                name: "StudentSubject",
                newName: "StudentSubjects");

            migrationBuilder.RenameTable(
                name: "DepartmetSubject",
                newName: "DepartmetSubjects");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_SubId",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_SubId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmetSubject_SubId",
                table: "DepartmetSubjects",
                newName: "IX_DepartmetSubjects_SubId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period",
                table: "Subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StdSubjID",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DeptSubID",
                table: "DepartmetSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects",
                column: "StdSubjID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects",
                column: "DeptSubID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudId",
                table: "StudentSubjects",
                column: "StudId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubjects_DepID",
                table: "DepartmetSubjects",
                column: "DepID");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Department_DepID",
                table: "DepartmetSubjects",
                column: "DepID",
                principalTable: "Department",
                principalColumn: "DepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Subjects_SubId",
                table: "DepartmetSubjects",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Student_StudId",
                table: "StudentSubjects",
                column: "StudId",
                principalTable: "Student",
                principalColumn: "StudId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubId",
                table: "StudentSubjects",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
