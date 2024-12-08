using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMAP_FARM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferItems_Offers_OfferId",
                table: "OfferItems");

            migrationBuilder.DropIndex(
                name: "IX_OfferItems_OfferId",
                table: "OfferItems");

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "OfferId",
                table: "OfferItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "OfferItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_OfferId",
                table: "OfferItems",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferItems_Offers_OfferId",
                table: "OfferItems",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
