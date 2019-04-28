using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogDeDados.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Log",
                newName: "IDLog");

            migrationBuilder.AddColumn<int>(
                name: "IDUsuario",
                table: "Log",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Token = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IDUsuario);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_IDUsuario",
                table: "Log",
                column: "IDUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Usuario_IDUsuario",
                table: "Log",
                column: "IDUsuario",
                principalTable: "Usuario",
                principalColumn: "IDUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Usuario_IDUsuario",
                table: "Log");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Log_IDUsuario",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "IDUsuario",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "IDLog",
                table: "Log",
                newName: "ID");
        }
    }
}
