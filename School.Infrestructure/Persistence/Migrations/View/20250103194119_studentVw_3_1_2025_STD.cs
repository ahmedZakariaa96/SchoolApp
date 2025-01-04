using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Infrestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class studentVw_3_1_2025_STD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                            create or alter  view [dbo].[VW_Student]
                            as 
                            select S.*, D.Name as DepartmentName  from Student S inner join Department D on S.DepId=D.DepId
                            GO
                       ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS [dbo].[VW_Student]");
        }
    }
}
