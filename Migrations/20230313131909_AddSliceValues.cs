using Microsoft.EntityFrameworkCore.Migrations;

namespace Water_Bill.Migrations
{
    public partial class AddSliceValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "slice_Value",
                columns: table => new
                {
                    Slice_Values_Code = table.Column<string>(type: "char(1)", nullable: false),
                    Slice_Values_Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    Slice_Values_Condtion = table.Column<int>(type: "int", nullable: false),
                    Slice_Values_Water_Price = table.Column<decimal>(type: "Decimal(6,2)", nullable: false),
                    Slice_Values_Sanitation_Price = table.Column<decimal>(type: "Decimal(6,2)", nullable: false),
                    Slice_Values_Reasons = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slice_Value", x => x.Slice_Values_Code);
                });

            migrationBuilder.InsertData(
                table: "slice_Value",
                columns: new[] { "Slice_Values_Code", "Slice_Values_Condtion", "Slice_Values_Name", "Slice_Values_Reasons", "Slice_Values_Sanitation_Price", "Slice_Values_Water_Price" },
                values: new object[,]
                {
                    { "a", 15, "اقل من 16 ", null, 0.05m, 0.1m },
                    { "b", 30, " من بين 16 الى 30", null, 0.5m, 1m },
                    { "c", 45, "من بين 31 الى 45", null, 1.5m, 3m },
                    { "d", 60, "من بين 46 الى 60", null, 2m, 4m },
                    { "e", 15, "اكثر من 60", null, 3m, 6m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "slice_Value");
        }
    }
}
