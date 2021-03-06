// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedClassLibrary.Data;

#nullable disable

namespace LoanAppMVC.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SharedClassLibrary.Models.BusinessModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BusinessCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("BusinessCode", "Name");

                    b.ToTable("Businesses", (string)null);
                });

            modelBuilder.Entity("SharedClassLibrary.Models.DemographicModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Demographics", (string)null);
                });

            modelBuilder.Entity("SharedClassLibrary.Models.LoanAppModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("APRPercent")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<int>("CreditScore")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateProcessed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<double>("LatePaymentRate")
                        .HasColumnType("float");

                    b.Property<int>("PayBackInMonths")
                        .HasColumnType("int");

                    b.Property<double>("RiskRate")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TotalDebt")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("Amount", "CreditScore");

                    b.ToTable("LoanApps", (string)null);
                });

            modelBuilder.Entity("SharedClassLibrary.Models.BusinessModel", b =>
                {
                    b.HasOne("SharedClassLibrary.Models.DemographicModel", "Owner")
                        .WithMany("Business")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("SharedClassLibrary.Models.LoanAppModel", b =>
                {
                    b.HasOne("SharedClassLibrary.Models.BusinessModel", "Business")
                        .WithMany("LoanApps")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("SharedClassLibrary.Models.BusinessModel", b =>
                {
                    b.Navigation("LoanApps");
                });

            modelBuilder.Entity("SharedClassLibrary.Models.DemographicModel", b =>
                {
                    b.Navigation("Business");
                });
#pragma warning restore 612, 618
        }
    }
}
