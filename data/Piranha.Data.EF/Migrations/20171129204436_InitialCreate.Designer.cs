﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Piranha;
using Piranha.Models;
using System;

namespace Piranha.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20171129204436_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Piranha.Data.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<Guid?>("FolderId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("PublicUrl");

                    b.Property<long>("Size");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Piranha_Media");
                });

            modelBuilder.Entity("Piranha.Data.MediaFolder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("Piranha_MediaFolders");
                });

            modelBuilder.Entity("Piranha.Data.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsHidden");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeywords")
                        .HasMaxLength(128);

                    b.Property<string>("NavigationTitle")
                        .HasMaxLength(128);

                    b.Property<string>("PageTypeId")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<Guid?>("ParentId");

                    b.Property<DateTime?>("Published");

                    b.Property<int>("RedirectType");

                    b.Property<string>("RedirectUrl")
                        .HasMaxLength(256);

                    b.Property<string>("Route")
                        .HasMaxLength(256);

                    b.Property<Guid>("SiteId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("SortOrder");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("PageTypeId");

                    b.HasIndex("ParentId");

                    b.HasIndex("SiteId", "Slug")
                        .IsUnique();

                    b.ToTable("Piranha_Pages");
                });

            modelBuilder.Entity("Piranha.Data.PageField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CLRType")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("FieldId")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<Guid>("PageId");

                    b.Property<string>("RegionId")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("SortOrder");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PageId", "RegionId", "FieldId", "SortOrder");

                    b.ToTable("Piranha_PageFields");
                });

            modelBuilder.Entity("Piranha.Data.PageType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64);

                    b.Property<string>("Body");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastModified");

                    b.HasKey("Id");

                    b.ToTable("Piranha_PageTypes");
                });

            modelBuilder.Entity("Piranha.Data.Param", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.ToTable("Piranha_Params");
                });

            modelBuilder.Entity("Piranha.Data.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<string>("Hostnames")
                        .HasMaxLength(256);

                    b.Property<string>("InternalId")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("IsDefault");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Title")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("InternalId")
                        .IsUnique();

                    b.ToTable("Piranha_Sites");
                });

            modelBuilder.Entity("Piranha.Data.Media", b =>
                {
                    b.HasOne("Piranha.Data.MediaFolder", "Folder")
                        .WithMany("Media")
                        .HasForeignKey("FolderId");
                });

            modelBuilder.Entity("Piranha.Data.Page", b =>
                {
                    b.HasOne("Piranha.Data.PageType", "PageType")
                        .WithMany()
                        .HasForeignKey("PageTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Piranha.Data.Page", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("Piranha.Data.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Piranha.Data.PageField", b =>
                {
                    b.HasOne("Piranha.Data.Page", "Page")
                        .WithMany("Fields")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
