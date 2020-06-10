﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexul.Demo.SqlDbServices;

namespace Nexul.Demo.SqlDbServices.Migrations.NexulDemoDb
{
    [DbContext(typeof(NexulDemoDbContext))]
    [Migration("20200610172133_InitialDemo")]
    partial class InitialDemo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nexul.Demo.Files.File", b =>
                {
                    b.Property<Guid>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("FileBlob")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FileId");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Nexul.Demo.Files.FileImageAlternate", b =>
                {
                    b.Property<Guid>("FileImageAlternateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("FileBlob")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FileImageAlternateId");

                    b.ToTable("FileImageAlternate");
                });

            modelBuilder.Entity("Nexul.Demo.Files.FileImageAlternateMetadata", b =>
                {
                    b.Property<Guid>("FileImageAlternateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(225)")
                        .HasMaxLength(225);

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("FileImageAlternateId");

                    b.ToTable("FileImageAlternateMetadata");
                });

            modelBuilder.Entity("Nexul.Demo.Files.FileMetadata", b =>
                {
                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(225)")
                        .HasMaxLength(225);

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasKey("FileId");

                    b.ToTable("FileMetadata");
                });

            modelBuilder.Entity("Nexul.Demo.Files.FileImageAlternateMetadata", b =>
                {
                    b.HasOne("Nexul.Demo.Files.FileImageAlternate", null)
                        .WithOne("Metadata")
                        .HasForeignKey("Nexul.Demo.Files.FileImageAlternateMetadata", "FileImageAlternateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Nexul.Demo.AuditCreate", "Audit", b1 =>
                        {
                            b1.Property<Guid>("FileImageAlternateMetadataFileImageAlternateId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedUserId")
                                .HasColumnType("nvarchar(40)")
                                .HasMaxLength(40);

                            b1.Property<string>("CreatedUserName")
                                .HasColumnType("nvarchar(120)")
                                .HasMaxLength(120);

                            b1.HasKey("FileImageAlternateMetadataFileImageAlternateId");

                            b1.ToTable("FileImageAlternateMetadata");

                            b1.WithOwner()
                                .HasForeignKey("FileImageAlternateMetadataFileImageAlternateId");
                        });
                });

            modelBuilder.Entity("Nexul.Demo.Files.FileMetadata", b =>
                {
                    b.HasOne("Nexul.Demo.Files.File", null)
                        .WithOne("Metadata")
                        .HasForeignKey("Nexul.Demo.Files.FileMetadata", "FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Nexul.Demo.AuditCreate", "Audit", b1 =>
                        {
                            b1.Property<Guid>("FileMetadataFileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedUserId")
                                .HasColumnType("nvarchar(40)")
                                .HasMaxLength(40);

                            b1.Property<string>("CreatedUserName")
                                .HasColumnType("nvarchar(120)")
                                .HasMaxLength(120);

                            b1.HasKey("FileMetadataFileId");

                            b1.ToTable("FileMetadata");

                            b1.WithOwner()
                                .HasForeignKey("FileMetadataFileId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
