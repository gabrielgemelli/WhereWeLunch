using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using System;

namespace WhereWeLunch.Migrations
{
    [DbContext(typeof(EntitiesContext))]
    [Migration("20170515122838_CreateVoting")]
    partial class CreateVoting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhereWeLunch.Models.HungryProfessional", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("WhereWeLunch.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");
                });

            modelBuilder.Entity("WhereWeLunch.Models.Vote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HungryProfessionalUsername");

                    b.Property<int>("SelectedRestaurantId");

                    b.Property<DateTime>("VotedOn");

                    b.HasKey("ID");
                });
        }
    }
}
