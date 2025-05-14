using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisQuartel.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inclusãodasregrasdeexclusãodaschaves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_militar_Batalhoes_BatalhaoId",
                table: "militar");

            migrationBuilder.DropForeignKey(
                name: "FK_militar_Patentes_id_patente",
                table: "militar");

            migrationBuilder.AddForeignKey(
                name: "FK_militar_Batalhoes_BatalhaoId",
                table: "militar",
                column: "BatalhaoId",
                principalTable: "Batalhoes",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_militar_Patentes_id_patente",
                table: "militar",
                column: "id_patente",
                principalTable: "Patentes",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_militar_Batalhoes_BatalhaoId",
                table: "militar");

            migrationBuilder.DropForeignKey(
                name: "FK_militar_Patentes_id_patente",
                table: "militar");

            migrationBuilder.AddForeignKey(
                name: "FK_militar_Batalhoes_BatalhaoId",
                table: "militar",
                column: "BatalhaoId",
                principalTable: "Batalhoes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_militar_Patentes_id_patente",
                table: "militar",
                column: "id_patente",
                principalTable: "Patentes",
                principalColumn: "id");
        }
    }
}
