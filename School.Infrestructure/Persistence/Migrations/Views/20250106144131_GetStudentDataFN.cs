using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrestructure.Persistence.Migrations.Views
{
    /// <inheritdoc />
    public partial class GetStudentDataFN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //select * from [dbo].[GetStudentDataFN] (1)

            migrationBuilder.Sql(@"
                                    CREATE or alter  FUNCTION  [dbo].[GetStudentDataFN]
                                    (
                                        @StudId INT -- Input parameter for Student ID
                                    )
                                    RETURNS TABLE
                                    AS
                                    RETURN
                                    (
                                        -- Query the view to get student data for the given StudId
                                        SELECT *
                                        FROM [dbo].[VW_Student]
                                        WHERE StudId = @StudId
                                    );

                            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP function IF EXISTS [dbo].[GetStudentDataFN]");

        }
    }
}
