using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisQuartel.Api.Migrations
{
    /// <inheritdoc />
    public partial class InclusãodeBatalhaoePatente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Militares",
                table: "Militares");

            migrationBuilder.DropColumn(
                name: "batalhao",
                table: "Militares");

            migrationBuilder.DropColumn(
                name: "patente",
                table: "Militares");

            migrationBuilder.RenameTable(
                name: "Militares",
                newName: "militar");

            migrationBuilder.AddColumn<int>(
                name: "BatalhaoId",
                table: "militar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_patente",
                table: "militar",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_militar",
                table: "militar",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Batalhoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    identificacao = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batalhoes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patentes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    graduacao = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patentes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_militar_BatalhaoId",
                table: "militar",
                column: "BatalhaoId");

            migrationBuilder.CreateIndex(
                name: "IX_militar_id_patente",
                table: "militar",
                column: "id_patente");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_militar_Batalhoes_BatalhaoId",
                table: "militar");

            migrationBuilder.DropForeignKey(
                name: "FK_militar_Patentes_id_patente",
                table: "militar");

            migrationBuilder.DropTable(
                name: "Batalhoes");

            migrationBuilder.DropTable(
                name: "Patentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_militar",
                table: "militar");

            migrationBuilder.DropIndex(
                name: "IX_militar_BatalhaoId",
                table: "militar");

            migrationBuilder.DropIndex(
                name: "IX_militar_id_patente",
                table: "militar");

            migrationBuilder.DropColumn(
                name: "BatalhaoId",
                table: "militar");

            migrationBuilder.DropColumn(
                name: "id_patente",
                table: "militar");

            migrationBuilder.RenameTable(
                name: "militar",
                newName: "Militares");

            migrationBuilder.AddColumn<string>(
                name: "batalhao",
                table: "Militares",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "patente",
                table: "Militares",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Militares",
                table: "Militares",
                column: "id");
        }
    }
}
