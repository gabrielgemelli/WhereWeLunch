using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using System;

namespace WhereWeLunch.Migrations
{
    [DbContext(typeof(EntitiesContext))]
    partial class EntitiesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhereWeLunch.Models.HungryProfessional", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("WhereWeLunch.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("WhereWeLunch.Models.Vote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HungryProfessionalID");

                    b.Property<int>("RestaurantID");

                    b.Property<DateTime>("VotedOn");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("WhereWeLunch.Models.Vote", b =>
                {
                    b.HasOne("WhereWeLunch.Models.HungryProfessional")
                        .WithMany()
                        .HasForeignKey("HungryProfessionalID");

                    b.HasOne("WhereWeLunch.Models.Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID");
                });
        }
    }
}
