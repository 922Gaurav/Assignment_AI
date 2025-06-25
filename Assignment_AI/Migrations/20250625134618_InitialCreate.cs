using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment_AI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Date", "Description", "Type", "Balance" },
                values: new object[,]
                {
                    { 1, 5000m, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Initial Office Credit", 0, 5000m },
                    { 2, 500m, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Snacks Party", 1, 4500m },
                    { 3, 285m, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Printing Sheets", 1, 4215m },
                    { 4, 3000m, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Misc. Expense", 1, 1215m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
