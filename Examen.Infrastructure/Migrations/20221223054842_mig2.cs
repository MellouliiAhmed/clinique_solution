using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "Patients",
                newName: "NomComplet_Prenom");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Patients",
                newName: "NomComplet_Nom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomComplet_Prenom",
                table: "Patients",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "NomComplet_Nom",
                table: "Patients",
                newName: "Nom");
        }
    }
}
