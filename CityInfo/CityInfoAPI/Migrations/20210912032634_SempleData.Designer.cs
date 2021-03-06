// <auto-generated />
using CityInfoAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityInfoAPI.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20210912032634_SempleData")]
    partial class SempleData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityInfoAPI.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new { Id = 1, Description = "The one with that big park.", Name = "New Yourk City" },
                        new { Id = 2, Description = "The one with the cathedral that was never really finished", Name = "Antwerpy" },
                        new { Id = 3, Description = "The one with that big tower.", Name = "Paris" }
                    );
                });

            modelBuilder.Entity("CityInfoAPI.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterest");

                    b.HasData(
                        new { Id = 5, CityId = 3, Description = "A wrough iron lettuce tower on the camp de mars", Name = "Eifel Tower" },
                        new { Id = 6, CityId = 3, Description = "The world's largest meseum.", Name = "The Louvre" },
                        new { Id = 2, CityId = 1, Description = "The most visited building in US.", Name = "Empire State Building" },
                        new { Id = 1, CityId = 1, Description = "The most visited park in US.", Name = "Central Park" },
                        new { Id = 4, CityId = 2, Description = "The finest example of railway", Name = "Antwerp Central Station" },
                        new { Id = 3, CityId = 2, Description = "A gothic cathedral.", Name = "Cathedral of Our Lady" }
                    );
                });

            modelBuilder.Entity("CityInfoAPI.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfoAPI.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
