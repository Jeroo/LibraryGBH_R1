﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using LibraryGBH.Data;

namespace LibraryGBH.Data.Migrations
{
    [DbContext(typeof(LibraryGBHDataContext))]
    [Migration("20180901225258_Update008")]
    partial class Update008
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<string>", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Individuos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IndividuoId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnName("Apellidos");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deferred")
                        .HasColumnName("DeleteFlag");

                    b.Property<string>("Nombre")
                        .HasColumnName("Nombre");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<long?>("TicketId");

                    b.Property<long?>("TicketsId");

                    b.Property<Guid>("UpdatedById");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TicketsId");

                    b.ToTable("Individuos");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Inventario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InventarioId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CantidadEnStock")
                        .HasColumnName("CantidadEnStock");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deferred")
                        .HasColumnName("DeleteFlag");

                    b.Property<DateTime>("FechaReposicion")
                        .HasColumnName("FechaReposicion");

                    b.Property<long?>("ProductoId");

                    b.Property<long?>("ProductosTiendaId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UpdatedById");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UsuarioReposicion")
                        .HasColumnName("UsuarioReposicion");

                    b.HasKey("Id");

                    b.HasIndex("ProductosTiendaId");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Ordenes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrdenId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deferred")
                        .HasColumnName("DeleteFlag");

                    b.Property<int>("Envio")
                        .HasColumnName("Envio");

                    b.Property<int>("Impuesto")
                        .HasColumnName("Impuesto");

                    b.Property<DateTime>("OrdenDate")
                        .HasColumnName("OrdenDate");

                    b.Property<string>("PayPalReference")
                        .HasColumnName("PayPalReference");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("Subtotal")
                        .HasColumnName("Subtotal");

                    b.Property<int>("Total")
                        .HasColumnName("Total");

                    b.Property<Guid>("UpdatedById");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.ProductosPool", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductoPoolId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deferred")
                        .HasColumnName("DeleteFlag");

                    b.Property<string>("Descripcion")
                        .HasColumnName("Descripcion");

                    b.Property<string>("Nombre")
                        .HasColumnName("Nombre");

                    b.Property<long?>("ProductoId");

                    b.Property<long?>("ProductosTiendaId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UpdatedById");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("img")
                        .HasColumnName("img");

                    b.HasKey("Id");

                    b.HasIndex("ProductosTiendaId");

                    b.ToTable("ProductosPool");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.ProductosTienda", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductoId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoProducto")
                        .HasColumnName("CodigoProducto");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deferred")
                        .HasColumnName("DeleteFlag");

                    b.Property<long?>("OrdenId");

                    b.Property<long?>("OrdenesId");

                    b.Property<double>("Precio")
                        .HasColumnName("Precio");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UpdatedById");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrdenesId");

                    b.ToTable("ProductosTienda");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Tickets", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TicketId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CompraDate")
                        .HasColumnName("CompraDate");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deferred")
                        .HasColumnName("DeleteFlag");

                    b.Property<string>("PaypalReference")
                        .HasColumnName("PaypalReference");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UpdatedById");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserId");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deferred")
                        .HasColumnName("DeleteFlag");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("NormalizedUserName");

                    b.Property<string>("PasswordHash")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UpdatedById");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Ventas", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VentaId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CantidadVendidas")
                        .HasColumnName("CantidadVendidas");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deferred")
                        .HasColumnName("DeleteFlag");

                    b.Property<DateTime?>("FechaVenta")
                        .HasColumnName("FechaVenta");

                    b.Property<long?>("ProductoId");

                    b.Property<long?>("ProductosTiendaId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UpdatedById");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UsuarioComprador")
                        .HasColumnName("UsuarioComprador");

                    b.HasKey("Id");

                    b.HasIndex("ProductosTiendaId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Individuos", b =>
                {
                    b.HasOne("LibraryGBH.Business.Entities.Tickets", "Tickets")
                        .WithMany("Individuos")
                        .HasForeignKey("TicketsId");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Inventario", b =>
                {
                    b.HasOne("LibraryGBH.Business.Entities.ProductosTienda", "ProductosTienda")
                        .WithMany()
                        .HasForeignKey("ProductosTiendaId");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.ProductosPool", b =>
                {
                    b.HasOne("LibraryGBH.Business.Entities.ProductosTienda", "ProductosTienda")
                        .WithMany("ProductosPool")
                        .HasForeignKey("ProductosTiendaId");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.ProductosTienda", b =>
                {
                    b.HasOne("LibraryGBH.Business.Entities.Ordenes", "Ordenes")
                        .WithMany("ProductosTienda")
                        .HasForeignKey("OrdenesId");
                });

            modelBuilder.Entity("LibraryGBH.Business.Entities.Ventas", b =>
                {
                    b.HasOne("LibraryGBH.Business.Entities.ProductosTienda", "ProductosTienda")
                        .WithMany("Ventas")
                        .HasForeignKey("ProductosTiendaId");
                });
#pragma warning restore 612, 618
        }
    }
}
