using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Water_Bill.Migrations
{
    public partial class addinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Invoices_No = table.Column<string>(type: "char(10)", nullable: false),
                    Invoices_Year = table.Column<string>(type: "char(2)", nullable: true),
                    Invoices_Rreal_Estate_TypesId = table.Column<string>(type: "char(2)", nullable: true),
                    Invoices_Subscription_NoId = table.Column<string>(type: "char(10)", nullable: true),
                    Invoices_Subscriber_NoId = table.Column<string>(type: "char(10)", nullable: true),
                    Invoices_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Invoices_From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Invoices_To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Invoices_Previous_Consumption_Amount = table.Column<int>(type: "int", nullable: false),
                    Invoices_Current_Consumption_Amount = table.Column<int>(type: "int", nullable: false),
                    Invoices_Amount_Consumption = table.Column<int>(type: "int", nullable: false),
                    Invoices_Service_Fee = table.Column<decimal>(type: "Decimal(6,2)", nullable: false),
                    Invoices_Tax_Rate = table.Column<decimal>(type: "Decimal(6,2)", nullable: false),
                    Invoices_Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    Invoices_Consumption_Value = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Invoices_Wastewater_Consumption_Value = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Invoices_Total_Invoice = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Invoices_Tax_Value = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Invoices_Total_Bill = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Invoices_Total_Reasons = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Invoices_No);
                    table.ForeignKey(
                        name: "FK_Invoices_real_Estate_Type_Invoices_Rreal_Estate_TypesId",
                        column: x => x.Invoices_Rreal_Estate_TypesId,
                        principalTable: "real_Estate_Type",
                        principalColumn: "Rreal_Estate_Types_Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_subscriber_Invoices_Subscriber_NoId",
                        column: x => x.Invoices_Subscriber_NoId,
                        principalTable: "subscriber",
                        principalColumn: "Subscriber_File_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_subscription_Invoices_Subscription_NoId",
                        column: x => x.Invoices_Subscription_NoId,
                        principalTable: "subscription",
                        principalColumn: "Subscription_File_No",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "slice_Value",
                keyColumn: "Slice_Values_Code",
                keyValue: "e",
                column: "Slice_Values_Condtion",
                value: 60);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Invoices_Rreal_Estate_TypesId",
                table: "Invoices",
                column: "Invoices_Rreal_Estate_TypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Invoices_Subscriber_NoId",
                table: "Invoices",
                column: "Invoices_Subscriber_NoId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Invoices_Subscription_NoId",
                table: "Invoices",
                column: "Invoices_Subscription_NoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.UpdateData(
                table: "slice_Value",
                keyColumn: "Slice_Values_Code",
                keyValue: "e",
                column: "Slice_Values_Condtion",
                value: 15);
        }
    }
}
