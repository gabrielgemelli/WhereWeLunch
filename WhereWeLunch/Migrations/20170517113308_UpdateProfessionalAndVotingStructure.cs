using Microsoft.Data.Entity.Migrations;

namespace WhereWeLunch.Migrations
{
    public partial class UpdateProfessionalAndVotingStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "HungryProfessionalUsername", table: "Vote");
            migrationBuilder.DropColumn(name: "SelectedRestaurantId", table: "Vote");
            migrationBuilder.DropColumn(name: "Username", table: "HungryProfessional");
            migrationBuilder.AddColumn<int>(
                name: "HungryProfessionalID",
                table: "Vote",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                table: "Vote",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurant",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HungryProfessional",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Vote_HungryProfessional_HungryProfessionalID",
                table: "Vote",
                column: "HungryProfessionalID",
                principalTable: "HungryProfessional",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Restaurant_RestaurantID",
                table: "Vote",
                column: "RestaurantID",
                principalTable: "Restaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Vote_HungryProfessional_HungryProfessionalID", table: "Vote");
            migrationBuilder.DropForeignKey(name: "FK_Vote_Restaurant_RestaurantID", table: "Vote");
            migrationBuilder.DropColumn(name: "HungryProfessionalID", table: "Vote");
            migrationBuilder.DropColumn(name: "RestaurantID", table: "Vote");
            migrationBuilder.DropColumn(name: "Email", table: "HungryProfessional");
            migrationBuilder.AddColumn<string>(
                name: "HungryProfessionalUsername",
                table: "Vote",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "SelectedRestaurantId",
                table: "Vote",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurant",
                nullable: false);
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "HungryProfessional",
                nullable: true);
        }
    }
}
