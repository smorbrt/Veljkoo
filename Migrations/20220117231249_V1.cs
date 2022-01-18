using Microsoft.EntityFrameworkCore.Migrations;

namespace AJMO.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pitanja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListaPitanja = table.Column<string>(type: "nvarchar(666)", maxLength: 666, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ProceneOcene = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Komentari = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Indeks = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zurka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lokacija = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sati = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Zanrovi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zurka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Anketa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProfesorID = table.Column<int>(type: "int", nullable: true),
                    ZurkaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anketa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Anketa_Profesor_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Profesor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anketa_Zurka_ZurkaID",
                        column: x => x.ZurkaID,
                        principalTable: "Zurka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnketaPitanja",
                columns: table => new
                {
                    AnketaPitanjaID = table.Column<int>(type: "int", nullable: false),
                    PitanjaAnketaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnketaPitanja", x => new { x.AnketaPitanjaID, x.PitanjaAnketaID });
                    table.ForeignKey(
                        name: "FK_AnketaPitanja_Anketa_PitanjaAnketaID",
                        column: x => x.PitanjaAnketaID,
                        principalTable: "Anketa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnketaPitanja_Pitanja_AnketaPitanjaID",
                        column: x => x.AnketaPitanjaID,
                        principalTable: "Pitanja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Popunjavanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Popunio = table.Column<bool>(type: "bit", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    AnketaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popunjavanje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Popunjavanje_Anketa_AnketaID",
                        column: x => x.AnketaID,
                        principalTable: "Anketa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Popunjavanje_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anketa_ProfesorID",
                table: "Anketa",
                column: "ProfesorID");

            migrationBuilder.CreateIndex(
                name: "IX_Anketa_ZurkaID",
                table: "Anketa",
                column: "ZurkaID");

            migrationBuilder.CreateIndex(
                name: "IX_AnketaPitanja_PitanjaAnketaID",
                table: "AnketaPitanja",
                column: "PitanjaAnketaID");

            migrationBuilder.CreateIndex(
                name: "IX_Popunjavanje_AnketaID",
                table: "Popunjavanje",
                column: "AnketaID");

            migrationBuilder.CreateIndex(
                name: "IX_Popunjavanje_StudentID",
                table: "Popunjavanje",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnketaPitanja");

            migrationBuilder.DropTable(
                name: "Popunjavanje");

            migrationBuilder.DropTable(
                name: "Pitanja");

            migrationBuilder.DropTable(
                name: "Anketa");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Zurka");
        }
    }
}
