using Microsoft.EntityFrameworkCore.Migrations;

namespace Water_Bill.Migrations
{
    public partial class invoiceyear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subscriber_File_Mobile",
                table: "subscriber",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Invoices_Year",
                table: "Invoices",
                type: "char(4)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subscriber_File_Mobile",
                table: "subscriber",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Invoices_Year",
                table: "Invoices",
                type: "char(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(4)",
                oldNullable: true);
        }
    }
}
