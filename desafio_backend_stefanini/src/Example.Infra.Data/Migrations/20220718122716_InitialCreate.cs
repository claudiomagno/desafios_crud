using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.DropTable(schema: "dbo", name: "Example");
            migrationBuilder.DropTable(schema: "dbo", name: "Pessoa");
            migrationBuilder.DropTable(schema: "dbo", name: "Cidade");

            migrationBuilder.CreateTable(
                name: "Cidade",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Id_Cidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Cidade_Id_Cidade",
                        column: x => x.Id_Cidade,
                        principalSchema: "dbo",
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_Nome_UF",
                schema: "dbo",
                table: "Cidade",
                columns: new[] { "Nome", "UF" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Cpf",
                schema: "dbo",
                table: "Pessoa",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Id_Cidade",
                schema: "dbo",
                table: "Pessoa",
                column: "Id_Cidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cidade",
                schema: "dbo");
        }
    }
}
