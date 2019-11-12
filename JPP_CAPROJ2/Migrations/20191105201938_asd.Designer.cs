﻿// <auto-generated />
using System;
using JPP_CAPROJ2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JPP_CAPROJ2.Migrations
{
    [DbContext(typeof(JPPDbContext))]
    [Migration("20191105201938_asd")]
    partial class asd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.Cart", b =>
                {
                    b.Property<int>("CartKey")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserName");

                    b.HasKey("CartKey");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsRead");

                    b.Property<string>("Message");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rate");

                    b.Property<DateTime>("Sent");

                    b.HasKey("FeedbackId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Read");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.OrderedProducts", b =>
                {
                    b.Property<int>("OrderedProductsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price");

                    b.Property<int>("ProductID");

                    b.Property<string>("ProductName");

                    b.Property<int>("Quantity");

                    b.Property<int>("TransactionID");

                    b.Property<bool>("isRead");

                    b.HasKey("OrderedProductsID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.Product", b =>
                {
                    b.Property<int>("ProductKey")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<string>("Message");

                    b.Property<string>("OtherImage1");

                    b.Property<string>("OtherImage2");

                    b.Property<string>("OtherImage3");

                    b.Property<string>("OtherImage4");

                    b.Property<double>("Price");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<int>("Stocks");

                    b.Property<bool>("isRead");

                    b.HasKey("ProductKey");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.Quotations", b =>
                {
                    b.Property<int>("QuotationPK")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price");

                    b.Property<string>("QuotationName");

                    b.Property<string>("ServiceName");

                    b.HasKey("QuotationPK");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName");

                    b.Property<string>("AccountNumber");

                    b.Property<string>("Address");

                    b.Property<string>("AssignedBy");

                    b.Property<DateTime>("AvailableDate");

                    b.Property<string>("Description");

                    b.Property<string>("ImageName");

                    b.Property<bool>("IsPaid");

                    b.Property<float>("Price");

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ServiceId");

                    b.Property<string>("Status");

                    b.Property<string>("UserName");

                    b.Property<bool>("isRead");

                    b.HasKey("RequestId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("End");

                    b.Property<string>("Materials")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Price");

                    b.Property<DateTime>("Start");

                    b.Property<int>("Workers");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.Transaction", b =>
                {
                    b.Property<int>("TransactionKey")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAccount");

                    b.Property<string>("BankName");

                    b.Property<DateTime?>("DateTimeStamps");

                    b.Property<DateTime?>("DeliveryDate");

                    b.Property<string>("DeliveryStatus");

                    b.Property<string>("ImageString");

                    b.Property<string>("ListOfProductsId");

                    b.Property<string>("PaymentStatus");

                    b.Property<string>("PaymentTerms");

                    b.Property<double>("TotalPrice");

                    b.Property<string>("UserName");

                    b.Property<string>("WhoCanModify");

                    b.Property<bool>("isRead");

                    b.HasKey("TransactionKey");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("JPP_CAPROJ2.Data.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfTask");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isRead");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
