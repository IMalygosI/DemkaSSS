using System;
using System.Collections.Generic;
using DemoTest_12122024_1.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoTest_12122024_1.Context;

public partial class User11068Context : DbContext
{
    public User11068Context()
    {
    }

    public User11068Context(DbContextOptions<User11068Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientService> ClientServices { get; set; }

    public virtual DbSet<DocumentByService> DocumentByServices { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSale> ProductSales { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServicePhoto> ServicePhotos { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagOfClient> TagOfClients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.7.159;Database=user11068;Username=user11068;Password=75072");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("activity_pk");

            entity.ToTable("Activity");

            entity.Property(e => e.ActivityId)
                .ValueGeneratedNever()
                .HasColumnName("activity_id");
            entity.Property(e => e.ActivityName)
                .HasColumnType("character varying")
                .HasColumnName("activity_name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("client_pk");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("client_id");
            entity.Property(e => e.ClientBirthDay).HasColumnName("client_birth_day");
            entity.Property(e => e.ClientEmail)
                .HasMaxLength(255)
                .HasColumnName("client_email");
            entity.Property(e => e.ClientFirstName)
                .HasColumnType("character varying")
                .HasColumnName("client_first_name");
            entity.Property(e => e.ClientGenderCode).HasColumnName("client_gender_code");
            entity.Property(e => e.ClientLastName)
                .HasColumnType("character varying")
                .HasColumnName("client_last_name");
            entity.Property(e => e.ClientPatronymic)
                .HasColumnType("character varying")
                .HasColumnName("client_patronymic");
            entity.Property(e => e.ClientPhone)
                .HasMaxLength(20)
                .HasColumnName("client_phone");
            entity.Property(e => e.ClientPhotoPath)
                .HasMaxLength(1000)
                .HasColumnName("client_photo_path");
            entity.Property(e => e.ClientRegistrationDate).HasColumnName("client_registration_date");

            entity.HasOne(d => d.ClientGenderCodeNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientGenderCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_gender_fk");
        });

        modelBuilder.Entity<ClientService>(entity =>
        {
            entity.HasKey(e => e.ClientserviceId).HasName("clientservice_pk");

            entity.ToTable("ClientService");

            entity.Property(e => e.ClientserviceId)
                .ValueGeneratedNever()
                .HasColumnName("clientservice_id");
            entity.Property(e => e.ClientserviceClientId).HasColumnName("clientservice_client_id");
            entity.Property(e => e.ClientserviceComment).HasColumnName("clientservice_comment");
            entity.Property(e => e.ClientserviceServiceId).HasColumnName("clientservice_service_id");
            entity.Property(e => e.ClientserviceStartTime).HasColumnName("clientservice_start_time");

            entity.HasOne(d => d.ClientserviceClient).WithMany(p => p.ClientServices)
                .HasForeignKey(d => d.ClientserviceClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientservice_client_fk");

            entity.HasOne(d => d.ClientserviceService).WithMany(p => p.ClientServices)
                .HasForeignKey(d => d.ClientserviceServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientservice_service_fk");
        });

        modelBuilder.Entity<DocumentByService>(entity =>
        {
            entity.HasKey(e => e.DocumentByServiceId).HasName("documentbyservice_pk");

            entity.ToTable("DocumentByService");

            entity.Property(e => e.DocumentByServiceId)
                .ValueGeneratedNever()
                .HasColumnName("document_by_service_id");
            entity.Property(e => e.ClientserviceId).HasColumnName("clientservice_id");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(1000)
                .HasColumnName("document_path");

            entity.HasOne(d => d.Clientservice).WithMany(p => p.DocumentByServices)
                .HasForeignKey(d => d.ClientserviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documentbyservice_clientservice_fk");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderCode).HasName("gender_pk");

            entity.ToTable("Gender");

            entity.Property(e => e.GenderCode)
                .ValueGeneratedNever()
                .HasColumnName("gender_code");
            entity.Property(e => e.GenderName)
                .HasColumnType("character varying")
                .HasColumnName("gender_name");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("manufacturer_pk");

            entity.ToTable("Manufacturer");

            entity.Property(e => e.ManufacturerId)
                .ValueGeneratedNever()
                .HasColumnName("manufacturer_id");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(100)
                .HasColumnName("manufacturer_name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_pk");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("product_id");
            entity.Property(e => e.ActiveId).HasColumnName("active_id");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.ProductCost)
                .HasPrecision(19, 3)
                .HasColumnName("product_cost");
            entity.Property(e => e.ProductDescription).HasColumnName("product_description");
            entity.Property(e => e.ProductMainImage)
                .HasColumnType("character varying")
                .HasColumnName("product_main_image");
            entity.Property(e => e.ProductTitle)
                .HasColumnType("character varying")
                .HasColumnName("product_title");

            entity.HasOne(d => d.Active).WithMany(p => p.Products)
                .HasForeignKey(d => d.ActiveId)
                .HasConstraintName("product_activity_fk");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("product_manufacturer_fk");
        });

        modelBuilder.Entity<ProductSale>(entity =>
        {
            entity.HasKey(e => e.ProductSaleId).HasName("productsale_pk");

            entity.ToTable("ProductSale");

            entity.Property(e => e.ProductSaleId)
                .ValueGeneratedNever()
                .HasColumnName("product_sale_id");
            entity.Property(e => e.ClientServiceId).HasColumnName("client_service_id");
            entity.Property(e => e.ProductsaleProductId).HasColumnName("productsale_product_id");
            entity.Property(e => e.ProductsaleQuantity).HasColumnName("productsale_quantity");
            entity.Property(e => e.ProductsaleSaleDate).HasColumnName("productsale_sale_date");

            entity.HasOne(d => d.ClientService).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.ClientServiceId)
                .HasConstraintName("productsale_clientservice_fk");

            entity.HasOne(d => d.ProductsaleProduct).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.ProductsaleProductId)
                .HasConstraintName("productsale_product_fk");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("service_pk");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("service_id");
            entity.Property(e => e.ServiceCost)
                .HasPrecision(19, 4)
                .HasColumnName("service_cost");
            entity.Property(e => e.ServiceDescription).HasColumnName("service_description");
            entity.Property(e => e.ServiceDiscount)
                .HasColumnType("character varying")
                .HasColumnName("service_discount");
            entity.Property(e => e.ServiceDurationinSeconds).HasColumnName("service_durationin_seconds");
            entity.Property(e => e.ServiceMainimagePath)
                .HasMaxLength(1000)
                .HasColumnName("service_mainimage_path");
            entity.Property(e => e.ServiceTitle)
                .HasColumnType("character varying")
                .HasColumnName("service_title");
        });

        modelBuilder.Entity<ServicePhoto>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("servicephoto_pk");

            entity.ToTable("ServicePhoto");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("service_id");
            entity.Property(e => e.ServicePhotoId).HasColumnName("service_photo_id");
            entity.Property(e => e.ServicephotoPhotoPath)
                .HasMaxLength(1000)
                .HasColumnName("servicephoto_photo_path");

            entity.HasOne(d => d.Service).WithOne(p => p.ServicePhoto)
                .HasForeignKey<ServicePhoto>(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicephoto_service_fk");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("tag_pk");

            entity.ToTable("Tag");

            entity.Property(e => e.TagId)
                .ValueGeneratedNever()
                .HasColumnName("tag_id");
            entity.Property(e => e.TagColor)
                .HasMaxLength(6)
                .HasColumnName("tag_color");
            entity.Property(e => e.TagTitle)
                .HasMaxLength(30)
                .HasColumnName("tag_title");
        });

        modelBuilder.Entity<TagOfClient>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("tagofclient_pk");

            entity.ToTable("TagOfClient");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("client_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Client).WithOne(p => p.TagOfClient)
                .HasForeignKey<TagOfClient>(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tagofclient_client_fk");

            entity.HasOne(d => d.Tag).WithMany(p => p.TagOfClients)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tagofclient_tag_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
