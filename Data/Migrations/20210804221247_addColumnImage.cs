using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetBDLivres.Data.Migrations
{
    public partial class addColumnImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageName",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageName",
                table: "Livres");
        }
    }
}
