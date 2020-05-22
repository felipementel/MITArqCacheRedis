using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicacao.Infra.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    dt_cadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2020, 5, 22, 3, 32, 52, 109, DateTimeKind.Local).AddTicks(3449)),
                    nm_sexo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Identificador", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "dt_cadastro", "nm_nome", "nm_sexo" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(3159), "Felipe", "Masculino" },
                    { 16, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4223), "Vinicius", "Masculino" },
                    { 15, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4222), "Amanada", "Feminino" },
                    { 14, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4221), "Marcio", "Masculino" },
                    { 13, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4220), "Luiz", "Masculino" },
                    { 12, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4219), "Maria", "Feminino" },
                    { 11, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4217), "Hugo", "Masculino" },
                    { 10, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4216), "Joao", "Masculino" },
                    { 9, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4214), "Carla", "Feminino" },
                    { 8, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4212), "Manuel", "Masculino" },
                    { 7, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4211), "Jose", "Masculino" },
                    { 6, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4210), "Flavia", "Feminino" },
                    { 5, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4209), "Fernando", "Masculino" },
                    { 4, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4207), "Carlos", "Masculino" },
                    { 3, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4206), "Denise", "Feminino" },
                    { 2, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4186), "Rafael", "Masculino" },
                    { 17, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4225), "Romulo", "Masculino" },
                    { 18, new DateTime(2020, 5, 22, 3, 32, 52, 115, DateTimeKind.Local).AddTicks(4226), "Daniela", "Feminino" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
