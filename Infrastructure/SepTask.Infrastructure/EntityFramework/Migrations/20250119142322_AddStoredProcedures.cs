using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SepTask.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAllGame_v1')
            BEGIN
                EXEC('
                    CREATE PROCEDURE sp_GetAllGame_v1
                    AS
                    BEGIN
                        select		g.Id,gen.Name Genre,g.Name,g.Price,g.ReleaseDate 
                        from		Game g
                        inner join  Genre gen on gen.Id=g.GenreId
                    END
                ')
            END

        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAllGame_v1')
            BEGIN
                DROP PROCEDURE sp_GetAllGame_v1
            END
        ");
        }
    }
}
