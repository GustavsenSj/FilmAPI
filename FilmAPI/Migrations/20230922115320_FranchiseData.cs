using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmAPI.Migrations
{
    /// <inheritdoc />
    public partial class FranchiseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FranchiseId",
                table: "Franchises",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Franchises",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Franchises",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The Star Wars franchise", "Star Wars" },
                    { 2, "The Star Trek franchise", "Star Trek" }
                });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "FranchiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "FranchiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "FranchiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                column: "FranchiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                column: "FranchiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6,
                column: "FranchiseId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Franchises",
                newName: "FranchiseId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Franchises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Franchises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6,
                column: "FranchiseId",
                value: null);
        }
    }
}
