﻿// <auto-generated />
using System;
using IForgor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IForgor.Infrastructure.Migrations
{
    [DbContext(typeof(IforgorDbContext))]
    partial class IforgorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IForgor.Domain.DeskAggregate.Desk", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Desks", (string)null);
                });

            modelBuilder.Entity("IForgor.Domain.DeskAggregate.Desk", b =>
                {
                    b.OwnsMany("IForgor.Domain.FieldAggregate.ValueObjects.FieldId", "FieldIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("DeskId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("FieldId");

                            b1.HasKey("Id");

                            b1.HasIndex("DeskId");

                            b1.ToTable("DeskFieldIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DeskId");
                        });

                    b.OwnsMany("IForgor.Domain.ProjectAggregate.ValueObjects.ProjectId", "ProjectIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("DeskId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ProjectId");

                            b1.HasKey("Id");

                            b1.HasIndex("DeskId");

                            b1.ToTable("DeskProjectIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DeskId");
                        });

                    b.OwnsMany("IForgor.Domain.StudySubjectAggregate.ValueObjects.StudySubjectId", "StudySubjectIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("DeskId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("StudySubjectId");

                            b1.HasKey("Id");

                            b1.HasIndex("DeskId");

                            b1.ToTable("DeskStudySubjectsIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DeskId");
                        });

                    b.Navigation("FieldIds");

                    b.Navigation("ProjectIds");

                    b.Navigation("StudySubjectIds");
                });
#pragma warning restore 612, 618
        }
    }
}
