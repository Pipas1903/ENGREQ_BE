using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMAP_FARM.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryDateToOfferItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryDates",
                table: "OfferItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDates",
                table: "OfferItems");
        }
    }
}
