using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientInformationPortalAPI.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergiesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergiesId);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInformation",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformation", x => x.DiseaseId);
                });

            migrationBuilder.CreateTable(
                name: "NCD",
                columns: table => new
                {
                    NCDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCDName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD", x => x.NCDId);
                });

            migrationBuilder.CreateTable(
                name: "PatientInformation",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    Epilepsy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInformation", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_PatientInformation_DiseaseInformation_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "DiseaseInformation",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies_details",
                columns: table => new
                {
                    Allergies_DetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AllergiesId = table.Column<int>(type: "int", nullable: false),
                    PatientInformationPatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies_details", x => x.Allergies_DetailsId);
                    table.ForeignKey(
                        name: "FK_Allergies_details_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "AllergiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allergies_details_PatientInformation_PatientInformationPatientId",
                        column: x => x.PatientInformationPatientId,
                        principalTable: "PatientInformation",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "NCDDetails",
                columns: table => new
                {
                    NCD_DetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    NCDId = table.Column<int>(type: "int", nullable: false),
                    PatientInformationPatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDDetails", x => x.NCD_DetailsId);
                    table.ForeignKey(
                        name: "FK_NCDDetails_NCD_NCDId",
                        column: x => x.NCDId,
                        principalTable: "NCD",
                        principalColumn: "NCDId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCDDetails_PatientInformation_PatientInformationPatientId",
                        column: x => x.PatientInformationPatientId,
                        principalTable: "PatientInformation",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_details_AllergiesId",
                table: "Allergies_details",
                column: "AllergiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_details_PatientInformationPatientId",
                table: "Allergies_details",
                column: "PatientInformationPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_NCDId",
                table: "NCDDetails",
                column: "NCDId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_PatientInformationPatientId",
                table: "NCDDetails",
                column: "PatientInformationPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInformation_DiseaseId",
                table: "PatientInformation",
                column: "DiseaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies_details");

            migrationBuilder.DropTable(
                name: "NCDDetails");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "NCD");

            migrationBuilder.DropTable(
                name: "PatientInformation");

            migrationBuilder.DropTable(
                name: "DiseaseInformation");
        }
    }
}
