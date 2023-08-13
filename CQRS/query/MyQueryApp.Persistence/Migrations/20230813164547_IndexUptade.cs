using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyQueryApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IndexUptade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonQueryModels_Id_Name_SurName",
                table: "PersonQueryModels");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQueryModels_Id_Name_SurName_IdInMainTable",
                table: "PersonQueryModels",
                columns: new[] { "Id", "Name", "SurName", "IdInMainTable" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonQueryModels_Id_Name_SurName_IdInMainTable",
                table: "PersonQueryModels");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQueryModels_Id_Name_SurName",
                table: "PersonQueryModels",
                columns: new[] { "Id", "Name", "SurName" });
        }
    }
}
