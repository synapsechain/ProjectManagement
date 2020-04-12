﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagement.Data.Contexts;

namespace ProjectManagement.Data.Migrations
{
    [DbContext(typeof(DesignTimeProjectManagementContext))]
    partial class DesignTimeProjectManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectManagement.Data.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("ParentProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Code = "df3121ce-3231-4c7c-a21a-7989e39f25f1",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(5837),
                            Name = "generated project 1",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 710, DateTimeKind.Local).AddTicks(5210),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 2,
                            Code = "590033ef-a4fb-4839-9119-b7b1e80d23c2",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6855),
                            Name = "generated project 2",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6836),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 3,
                            Code = "a08ec813-e251-469f-9afd-f0f127833eff",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6880),
                            Name = "generated project 3",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6878),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 4,
                            Code = "46ec523c-4aa5-4d58-bfd7-28a35659d3d9",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6887),
                            Name = "generated project 4",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6885),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 5,
                            Code = "4d6c7f2d-7b70-4ab0-8a87-5a43246967e0",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6894),
                            Name = "generated project 5",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6891),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 6,
                            Code = "a3f707fc-cbe7-48a4-a811-a93d4f7296d4",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6900),
                            Name = "generated project 6",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6898),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 7,
                            Code = "1b60b5e9-c018-4292-bb72-f683a5456b7c",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6917),
                            Name = "generated project 7",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6914),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 8,
                            Code = "7059803f-4eef-437a-a12f-43371fd6c958",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6923),
                            Name = "generated project 8",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6921),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 9,
                            Code = "1cb95080-c640-4f1d-8835-5af6755a48d2",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6930),
                            Name = "generated project 9",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6927),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 10,
                            Code = "ead16532-0424-4616-b2d0-6b54838e8758",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6936),
                            Name = "generated project 10",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6933),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 11,
                            Code = "be622dd8-690f-4e33-9c5d-cd20e36593be",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6942),
                            Name = "generated project 11",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6940),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 12,
                            Code = "fb31eddc-3255-45d1-83ca-7f0f75273070",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6948),
                            Name = "generated project 12",
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6946),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 13,
                            Code = "a9a129e1-6994-4785-863d-e1c4d2401342",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6955),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6952),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 14,
                            Code = "7de2f47f-58ea-4028-a500-95c1160be413",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6961),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6959),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 15,
                            Code = "de195284-6ad9-4214-b593-ace66a05eac2",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6970),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6967),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 16,
                            Code = "729b744c-fe0b-4666-aa3b-b7208b159b70",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6976),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6974),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 17,
                            Code = "87bf42a0-20b0-4f00-8365-cb362c1927ad",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6983),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6980),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 18,
                            Code = "b7c8d0aa-244c-4dc2-9884-25fc8d96c20c",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6989),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6987),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 19,
                            Code = "e9dd0c2c-1fb8-4875-9c7f-bcfb818a203b",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6996),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6993),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 20,
                            Code = "40664c32-b327-4700-8d02-4deebb8314da",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7002),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6999),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 21,
                            Code = "aa8cfb49-29e7-4afe-acb0-a3eeb45b6a8f",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7008),
                            Name = "nested project",
                            ParentProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7006),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 22,
                            Code = "36616c08-c73d-4a05-b642-beb26efe4204",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7015),
                            Name = "nested project",
                            ParentProjectId = 18,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7013),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 23,
                            Code = "3b0a7592-057f-4489-b95f-099c560ae266",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7023),
                            Name = "nested project",
                            ParentProjectId = 18,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7021),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectId = 24,
                            Code = "d878f922-8f86-44f9-8812-51a5d9a4c2dd",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7029),
                            Name = "nested project",
                            ParentProjectId = 18,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7027),
                            State = "Planned"
                        });
                });

            modelBuilder.Entity("ProjectManagement.Data.Entities.ProjectTask", b =>
                {
                    b.Property<int>("ProjectTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentProjectTaskId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectTaskId");

                    b.HasIndex("ParentProjectTaskId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTasks");

                    b.HasData(
                        new
                        {
                            ProjectTaskId = 1,
                            Description = "some description for task 1",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(8661),
                            Name = "task 1",
                            ProjectId = 1,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(8259),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 2,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9071),
                            Name = "task 2",
                            ProjectId = 2,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9055),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 3,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9083),
                            Name = "task 3",
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9080),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 4,
                            Description = "some description for task 4",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9102),
                            Name = "task 4",
                            ProjectId = 4,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9099),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 5,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9107),
                            Name = "task 5",
                            ProjectId = 5,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9105),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 6,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9112),
                            Name = "task 6",
                            ProjectId = 6,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9110),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 7,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9117),
                            Name = "task 7",
                            ProjectId = 7,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9115),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 8,
                            Description = "some description for task 8",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9124),
                            Name = "task 8",
                            ProjectId = 8,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9122),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 9,
                            Description = "some description for task 9",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9130),
                            Name = "task 9",
                            ProjectId = 9,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9128),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 10,
                            Description = "some description for task 10",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9137),
                            Name = "task 10",
                            ProjectId = 10,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9135),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 11,
                            Description = "some description for task 11",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9144),
                            Name = "task 11",
                            ProjectId = 11,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9142),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 12,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9149),
                            Name = "task 12",
                            ProjectId = 12,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9147),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 13,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9154),
                            Name = "task 13",
                            ProjectId = 13,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9152),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 14,
                            Description = "some description for task 14",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9161),
                            Name = "task 14",
                            ProjectId = 14,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9158),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 15,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9165),
                            Name = "task 15",
                            ProjectId = 15,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9163),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 16,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9171),
                            Name = "task 16",
                            ProjectId = 16,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9168),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 17,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9175),
                            Name = "task 17",
                            ProjectId = 17,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9173),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 18,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9180),
                            Name = "task 18",
                            ProjectId = 18,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9178),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 19,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9185),
                            Name = "task 19",
                            ProjectId = 19,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9183),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 20,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9190),
                            Name = "task 20",
                            ProjectId = 20,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9188),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 21,
                            Description = "some description for task 21",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9197),
                            Name = "task 21",
                            ProjectId = 21,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9194),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 22,
                            Description = "some description for task 22",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9203),
                            Name = "task 22",
                            ProjectId = 22,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9201),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 23,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9208),
                            Name = "task 23",
                            ProjectId = 23,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9206),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 24,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9213),
                            Name = "task 24",
                            ProjectId = 24,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9211),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 25,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9218),
                            Name = "task 25",
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9216),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 26,
                            Description = "some description for task 26",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9224),
                            Name = "task 26",
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9222),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 27,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9229),
                            Name = "task 27",
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9227),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 28,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9234),
                            Name = "task 28",
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9232),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 29,
                            Description = "some description for task 29",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9241),
                            Name = "task 29",
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9238),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 30,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9246),
                            Name = "task 30",
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9243),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 31,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9250),
                            Name = "task 31",
                            ParentProjectTaskId = 1,
                            ProjectId = 1,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9248),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 32,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9255),
                            Name = "task 32",
                            ParentProjectTaskId = 1,
                            ProjectId = 1,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9253),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 33,
                            Description = "some description for task 33",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9262),
                            Name = "task 33",
                            ParentProjectTaskId = 1,
                            ProjectId = 1,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9259),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 34,
                            Description = "some description for task 34",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9268),
                            Name = "task 34",
                            ParentProjectTaskId = 3,
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9266),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 35,
                            Description = "some description for task 35",
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9275),
                            Name = "task 35",
                            ParentProjectTaskId = 3,
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9273),
                            State = "Planned"
                        },
                        new
                        {
                            ProjectTaskId = 36,
                            FinishDate = new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9280),
                            Name = "task 36",
                            ParentProjectTaskId = 3,
                            ProjectId = 3,
                            StartDate = new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9278),
                            State = "Planned"
                        });
                });

            modelBuilder.Entity("ProjectManagement.Data.Entities.Project", b =>
                {
                    b.HasOne("ProjectManagement.Data.Entities.Project", "ParentProject")
                        .WithMany("Projects")
                        .HasForeignKey("ParentProjectId");
                });

            modelBuilder.Entity("ProjectManagement.Data.Entities.ProjectTask", b =>
                {
                    b.HasOne("ProjectManagement.Data.Entities.ProjectTask", "ParentProjectTask")
                        .WithMany("Tasks")
                        .HasForeignKey("ParentProjectTaskId");

                    b.HasOne("ProjectManagement.Data.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}