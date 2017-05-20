using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using System;

namespace WhereWeLunch.Migrations
{
    public partial class CreateVoting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HungryProfessionalUsername = table.Column<string>(nullable: true),
                    SelectedRestaurantId = table.Column<int>(nullable: false),
                    VotedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Vote");
        }
    }
}
