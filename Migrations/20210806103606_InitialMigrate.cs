using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetBDLivres.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livres",
                columns: table => new
                {
                    livreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    annee = table.Column<int>(type: "int", nullable: false),
                    auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livres", x => x.livreId);
                });

            migrationBuilder.CreateTable(
                name: "LivresDesires",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    annee = table.Column<int>(type: "int", nullable: false),
                    auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    utilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivresDesires", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    utilisateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motDePasse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.utilisateurId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livres");

            migrationBuilder.DropTable(
                name: "LivresDesires");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
