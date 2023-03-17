﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using water_bill;

namespace Water_Bill.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230316141701_invoiceyear")]
    partial class invoiceyear
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Water_Bill.Models.Invoices", b =>
                {
                    b.Property<string>("Invoices_No")
                        .HasColumnType("char(10)");

                    b.Property<int>("Invoices_Amount_Consumption")
                        .HasColumnType("int");

                    b.Property<decimal>("Invoices_Consumption_Value")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<int>("Invoices_Current_Consumption_Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Invoices_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Invoices_From")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Invoices_Is_There_Sanitation")
                        .HasColumnType("bit");

                    b.Property<int>("Invoices_Previous_Consumption_Amount")
                        .HasColumnType("int");

                    b.Property<string>("Invoices_Rreal_Estate_TypesId")
                        .HasColumnType("char(2)");

                    b.Property<decimal>("Invoices_Service_Fee")
                        .HasColumnType("Decimal(6,2)");

                    b.Property<string>("Invoices_Subscriber_NoId")
                        .HasColumnType("char(10)");

                    b.Property<string>("Invoices_Subscription_NoId")
                        .HasColumnType("char(10)");

                    b.Property<decimal>("Invoices_Tax_Rate")
                        .HasColumnType("Decimal(6,2)");

                    b.Property<decimal>("Invoices_Tax_Value")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<DateTime>("Invoices_To")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Invoices_Total_Bill")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<decimal>("Invoices_Total_Invoice")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<string>("Invoices_Total_Reasons")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Invoices_Wastewater_Consumption_Value")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<string>("Invoices_Year")
                        .HasColumnType("char(4)");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Invoices_No");

                    b.HasIndex("Invoices_Rreal_Estate_TypesId");

                    b.HasIndex("Invoices_Subscriber_NoId");

                    b.HasIndex("Invoices_Subscription_NoId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Water_Bill.Models.Slice_Values", b =>
                {
                    b.Property<string>("Slice_Values_Code")
                        .HasColumnType("char(1)");

                    b.Property<int>("Slice_Values_Condtion")
                        .HasColumnType("int");

                    b.Property<string>("Slice_Values_Name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Slice_Values_Reasons")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Slice_Values_Sanitation_Price")
                        .HasColumnType("Decimal(6,2)");

                    b.Property<decimal>("Slice_Values_Water_Price")
                        .HasColumnType("Decimal(6,2)");

                    b.HasKey("Slice_Values_Code");

                    b.ToTable("slice_Value");

                    b.HasData(
                        new
                        {
                            Slice_Values_Code = "a",
                            Slice_Values_Condtion = 15,
                            Slice_Values_Name = "اقل من 16 ",
                            Slice_Values_Sanitation_Price = 0.05m,
                            Slice_Values_Water_Price = 0.1m
                        },
                        new
                        {
                            Slice_Values_Code = "b",
                            Slice_Values_Condtion = 30,
                            Slice_Values_Name = " من بين 16 الى 30",
                            Slice_Values_Sanitation_Price = 0.5m,
                            Slice_Values_Water_Price = 1m
                        },
                        new
                        {
                            Slice_Values_Code = "c",
                            Slice_Values_Condtion = 45,
                            Slice_Values_Name = "من بين 31 الى 45",
                            Slice_Values_Sanitation_Price = 1.5m,
                            Slice_Values_Water_Price = 3m
                        },
                        new
                        {
                            Slice_Values_Code = "d",
                            Slice_Values_Condtion = 60,
                            Slice_Values_Name = "من بين 46 الى 60",
                            Slice_Values_Sanitation_Price = 2m,
                            Slice_Values_Water_Price = 4m
                        },
                        new
                        {
                            Slice_Values_Code = "e",
                            Slice_Values_Condtion = 60,
                            Slice_Values_Name = "اكثر من 60",
                            Slice_Values_Sanitation_Price = 3m,
                            Slice_Values_Water_Price = 6m
                        });
                });

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
                        .HasColumnType("varchar(20)");

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
                        .HasColumnType("int");

                    b.Property<string>("Subscription_File_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Subscription_File_Rreal_Estate_Types_CodeID")
                        .HasColumnType("char(2)");

                    b.Property<string>("Subscription_File_Subscriber_CodeId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("char(10)");

                    b.Property<int>("Subscription_File_Unit_No")
                        .HasColumnType("int");

                    b.HasKey("Subscription_File_No");

                    b.HasIndex("Subscription_File_Rreal_Estate_Types_CodeID");

                    b.HasIndex("Subscription_File_Subscriber_CodeId");

                    b.ToTable("subscription");
                });

            modelBuilder.Entity("Water_Bill.Models.Invoices", b =>
                {
                    b.HasOne("water_bill.Models.Rreal_Estate_Types", "Invoices_Rreal_Estate_Types")
                        .WithMany()
                        .HasForeignKey("Invoices_Rreal_Estate_TypesId");

                    b.HasOne("water_bill.Models.Subscriber_File", "Invoices_Subscriber_No")
                        .WithMany()
                        .HasForeignKey("Invoices_Subscriber_NoId");

                    b.HasOne("water_bill.Models.Subscription_File", "Invoices_Subscription_No")
                        .WithMany()
                        .HasForeignKey("Invoices_Subscription_NoId");

                    b.Navigation("Invoices_Rreal_Estate_Types");

                    b.Navigation("Invoices_Subscriber_No");

                    b.Navigation("Invoices_Subscription_No");
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
