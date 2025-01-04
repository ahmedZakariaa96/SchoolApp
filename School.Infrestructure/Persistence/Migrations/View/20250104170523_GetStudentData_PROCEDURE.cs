using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrestructure.Persistence.Migrations.View
{
    /// <inheritdoc />
    public partial class GetStudentData_PROCEDURE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

                                CREATE or alter PROCEDURE [dbo].[GetStudentDataPRC]
                                    @StudId INT -- Input parameter for Student ID
                                AS
                                BEGIN
                                    -- Set NOCOUNT ON to prevent extra result sets from interfering
                                    SET NOCOUNT ON;

                                    -- Query the view to get student data for the given StudId
                                    SELECT *
                                    FROM [dbo].[VW_Student]
                                    WHERE StudId = @StudId;
                                END;
                                GO

                            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS [dbo].[GetStudentDataPRC]");

        }
    }
}
