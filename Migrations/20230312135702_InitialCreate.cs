using Microsoft.EntityFrameworkCore.Migrations;

namespace Water_Bill.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "real_Estate_Type",
                columns: table => new
                {
                    Rreal_Estate_Types_Code = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    Rreal_Estate_Types_Name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_real_Estate_Type", x => x.Rreal_Estate_Types_Code);
                });

            migrationBuilder.CreateTable(
                name: "subscriber",
                columns: table => new
                {
                    Subscriber_File_Id = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Subscriber_File_Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Subscriber_File_City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Subscriber_File_Area = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Subscriber_File_Mobile = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Subscriber_File_Reasons = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriber", x => x.Subscriber_File_Id);
                });

            migrationBuilder.CreateTable(
                name: "subscription",
                columns: table => new
                {
                    Subscription_File_No = table.Column<string>(type: "char(10)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subscription_File_Subscriber_CodeId = table.Column<string>(type: "char(10)", nullable: false),
                    Subscription_File_Rreal_Estate_Types_CodeID = table.Column<string>(type: "char(2)", nullable: true),
                    Subscription_File_Unit_No = table.Column<int>(type: "int", nullable: false),
                    Subscription_File_Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    Subscription_File_Last_Reading_Meter = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Subscription_File_Reasons = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription", x => x.Subscription_File_No);
                    table.ForeignKey(
                        name: "FK_subscription_real_Estate_Type_Subscription_File_Rreal_Estate_Types_CodeID",
                        column: x => x.Subscription_File_Rreal_Estate_Types_CodeID,
                        principalTable: "real_Estate_Type",
                        principalColumn: "Rreal_Estate_Types_Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subscription_subscriber_Subscription_File_Subscriber_CodeId",
                        column: x => x.Subscription_File_Subscriber_CodeId,
                        principalTable: "subscriber",
                        principalColumn: "Subscriber_File_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subscription_Subscription_File_Rreal_Estate_Types_CodeID",
                table: "subscription",
                column: "Subscription_File_Rreal_Estate_Types_CodeID");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_Subscription_File_Subscriber_CodeId",
                table: "subscription",
                column: "Subscription_File_Subscriber_CodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscription");

            migrationBuilder.DropTable(
                name: "real_Estate_Type");

            migrationBuilder.DropTable(
                name: "subscriber");
        }
    }
}
