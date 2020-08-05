﻿// <auto-generated />
using System;
using CtrlPlu.Questionnaire.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CtrlPlu.Questionnaire.Infrastructure.Migrations
{
    [DbContext(typeof(QuestionnaireDbContext))]
    [Migration("20200727080926_AddRatingValue2")]
    partial class AddRatingValue2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InputMask")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceHolder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int?>("SectionId1")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.HasIndex("SectionId1");

                    b.ToTable("Field");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.FieldMultiValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId");

                    b.HasIndex("TypeId");

                    b.ToTable("FieldMultiValues");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.FieldOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OptionValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("FieldOptions");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Form");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.RatingValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("FieldId")
                        .HasColumnType("int");

                    b.Property<int>("From")
                        .HasColumnType("int");

                    b.Property<string>("FromLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("To")
                        .HasColumnType("int");

                    b.Property<string>("ToLabel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId")
                        .IsUnique()
                        .HasFilter("[FieldId] IS NOT NULL");

                    b.ToTable("RatingValue");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(2147483647);

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int?>("FieldId1")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("FieldId1");

                    b.ToTable("Submission");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.Field", b =>
                {
                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Section", null)
                        .WithMany("Fields")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId1");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.FieldMultiValues", b =>
                {
                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Submission", null)
                        .WithMany("MultiValues")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Field", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.FieldOptions", b =>
                {
                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Field", null)
                        .WithMany("Options")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.RatingValue", b =>
                {
                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Field", null)
                        .WithOne("Rating")
                        .HasForeignKey("CtrlPlu.Questionnaire.Core.Form.Entities.RatingValue", "FieldId");
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.Section", b =>
                {
                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Form", null)
                        .WithMany("Sections")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CtrlPlu.Questionnaire.Core.Form.Entities.Submission", b =>
                {
                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Field", null)
                        .WithMany("Submission")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CtrlPlu.Questionnaire.Core.Form.Entities.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId1");
                });
#pragma warning restore 612, 618
        }
    }
}
