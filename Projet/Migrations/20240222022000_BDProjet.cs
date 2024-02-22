using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet.Migrations
{
    public partial class BDProjet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "Enfants",
                columns: table => new
                {
                    EnfantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdParent = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnneeProduction = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfants", x => x.EnfantId);
                    table.ForeignKey(
                        name: "FK_Enfants_Parents_IdParent",
                        column: x => x.IdParent,
                        principalTable: "Parents",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentId", "Description", "ImageFileName", "Nom" },
                values: new object[] { 1, "Description du CESSNA", "CESSNA.png", "CESSNA" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentId", "Description", "ImageFileName", "Nom" },
                values: new object[] { 2, "Description du PIPER", "PIPER.png", "PIPER" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentId", "Description", "ImageFileName", "Nom" },
                values: new object[] { 3, "Description du CIRRUS", "CIRRUS.png", "CIRRUS" });

            migrationBuilder.InsertData(
                table: "Enfants",
                columns: new[] { "EnfantId", "AnneeProduction", "Description", "IdParent", "ImageFileName", "Nom", "Prix", "Type" },
                values: new object[,]
                {
                    { 1, 2005, "Avion monomoteur léger.", 1, "cessna 172 1.png", "Cessna 172", 100000m, "Monomoteur" },
                    { 2, 2002, "Avion monomoteur léger.", 1, "cessna 152 2.png", "Cessna 152", 80000m, "Monomoteur" },
                    { 3, 2008, "Avion monomoteur à pistons.", 1, "CESSNA 182 1.png", "Cessna 182", 120000m, "Monomoteur" },
                    { 4, 2015, "Jet d'affaires léger à réaction.", 1, "Carravan.png", "Cessna Citation", 500000m, "Jet" },
                    { 5, 2010, "Avion léger à quatre places.", 2, "Archer 1.png", "Piper Archer", 90000m, "Léger" },
                    { 6, 2007, "Avion monomoteur à ailes hautes.", 2, "CHEROKEE 1.png", "Piper Cherokee", 75000m, "Monomoteur" },
                    { 7, 2009, "Avion léger de sport.", 2, "PIPER PA24.png", "Piper PA24", 80000m, "Léger" },
                    { 8, 2012, "Avion monomoteur léger et rapide.", 2, "piper pa28.png", "Piper PA28", 100000m, "Monomoteur" },
                    { 9, 2018, "Jet d'affaires monoréacteur.", 3, "SR22T 1.png", "Cirrus SR22T", 600000m, "Jet" },
                    { 10, 2015, "Avion monomoteur à pistons de haute performance.", 3, "SR22 1.png", "Cirrus SR22", 300000m, "Monomoteur" },
                    { 11, 2013, "Avion à réaction légère.", 3, "SR20 1.png", "Cirrus SR20", 200000m, "Monomoteur" },
                    { 12, 2020, "Jet monomoteur à réaction de type Vision Jet.", 3, "VISON JET 1.png", "Cirrus Vision Jet", 1000000m, "Jet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_IdParent",
                table: "Enfants",
                column: "IdParent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfants");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
