using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("061d8be5-2c5a-4f10-a49b-152d4e8f0a7a"), "Hard" },
                    { new Guid("1deaf916-3f75-495b-9a7b-3cd0681cd4ba"), "Easy" },
                    { new Guid("1edb5943-90cb-4461-8d11-9664fb8bd1e9"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("0721538d-3198-4507-ac74-27ae4f5f53ee"), "AKL", "Auckland", "akl.jpg" },
                    { new Guid("280efda4-22be-4d4b-87f8-78770ab2e3fe"), "NSN", "Nelson", "nsn.jpg" },
                    { new Guid("648f72ae-6b69-4c66-aa75-02952f84a7e4"), "BOP", "Bay of Plenty", "bop.jpg" },
                    { new Guid("6a7ff25a-1813-4def-bd1c-4e9b8648a19d"), "WGN", "Wellington", "wgn.jpg" },
                    { new Guid("c2cb7c45-072a-4dcc-8abc-b7ef65e53abb"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("061d8be5-2c5a-4f10-a49b-152d4e8f0a7a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1deaf916-3f75-495b-9a7b-3cd0681cd4ba"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1edb5943-90cb-4461-8d11-9664fb8bd1e9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0721538d-3198-4507-ac74-27ae4f5f53ee"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("280efda4-22be-4d4b-87f8-78770ab2e3fe"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("648f72ae-6b69-4c66-aa75-02952f84a7e4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6a7ff25a-1813-4def-bd1c-4e9b8648a19d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c2cb7c45-072a-4dcc-8abc-b7ef65e53abb"));
        }
    }
}
