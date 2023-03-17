﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using water_bill;

namespace Water_Bill.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230312135702_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("water_bill.Models.Rreal_Estate_Types", b =>
                {
                    b.Property<string>("Rreal_Estate_Types_Code")
                        .HasMaxLength(2)
                        .HasColumnType("char(2)");

                    b.Property<string>("Rreal_Estate_Types_Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Rreal_Estate_Types_Code");

                    b.ToTable("real_Estate_Type");
                });

            modelBuilder.Entity("water_bill.Models.Subscriber_File", b =>
                {
                    b.Property<string>("Subscriber_File_Id")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)");

                    b.Property<string>("Subscriber_File_Area")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Subscriber_File_City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Subscriber_File_Mobile")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Subscriber_File_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Subscriber_File_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Subscriber_File_Id");

                    b.ToTable("subscriber");
                });

            modelBuilder.Entity("water_bill.Models.Subscription_File", b =>
                {
                    b.Property<string>("Subscription_File_No")
                        .HasColumnType("char(10)");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Subscription_File_Is_There_Sanitation")
                        .HasColumnType("bit");

                    b.Property<int>("Subscription_File_Last_Reading_Meter")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Subscription_File_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Subscription_File_Rreal_Estate_Types_CodeID")
                        .HasColumnType("char(2)");

                    b.Property<string>("Subscription_File_Subscriber_CodeId")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<int>("Subscription_File_Unit_No")
                        .HasColumnType("int");

                    b.HasKey("Subscription_File_No");

                    b.HasIndex("Subscription_File_Rreal_Estate_Types_CodeID");

                    b.HasIndex("Subscription_File_Subscriber_CodeId");

                    b.ToTable("subscription");
                });

            modelBuilder.Entity("water_bill.Models.Subscription_File", b =>
                {
                    b.HasOne("water_bill.Models.Rreal_Estate_Types", "Subscription_File_Rreal_Estate_Types_Code")
                        .WithMany("subscription")
                        .HasForeignKey("Subscription_File_Rreal_Estate_Types_CodeID");

                    b.HasOne("water_bill.Models.Subscriber_File", "Subscription_File_Subscriber_Code")
                        .WithMany("Subscription")
                        .HasForeignKey("Subscription_File_Subscriber_CodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription_File_Rreal_Estate_Types_Code");

                    b.Navigation("Subscription_File_Subscriber_Code");
                });

            modelBuilder.Entity("water_bill.Models.Rreal_Estate_Types", b =>
                {
                    b.Navigation("subscription");
                });

            modelBuilder.Entity("water_bill.Models.Subscriber_File", b =>
                {
                    b.Navigation("Subscription");
                });
#pragma warning restore 612, 618
        }
    }
}
