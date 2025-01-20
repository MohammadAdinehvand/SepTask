using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SepTask.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Create_sp_GetGameById_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetGameById_v1')
            BEGIN
                EXEC('
                    CREATE PROCEDURE sp_GetGameById_v1
                    @Id uniqueidentifier
                    AS
                    BEGIN
                        select * from Game g where g.Id=@Id
                    END
                ')
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

            IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetGameById_v1')
            BEGIN
                DROP PROCEDURE sp_GetGameById_v1
            END
        ");
        }
    }
}
