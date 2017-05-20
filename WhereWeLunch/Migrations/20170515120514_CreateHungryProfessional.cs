using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;

namespace WhereWeLunch.Migrations
{
    public partial class CreateHungryProfessional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HungryProfessional",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HungryProfessional", x => x.ID);
                });
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurant",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("HungryProfessional");
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurant",
                nullable: true);
        }
    }
}
