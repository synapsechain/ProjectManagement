using System;
using Microsoft.EntityFrameworkCore.Migrations;
#pragma warning disable 8625

namespace ProjectManagement.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentProjectId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Projects_ParentProjectId",
                        column: x => x.ParentProjectId,
                        principalSchema: "system",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    ParentTaskId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "system",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Projects",
                columns: new[] { "Id", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 1L, "43e19839-3e73-4c29-a930-60e4152e8f02", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(1715), "proj 1", null, new DateTime(2021, 9, 6, 23, 4, 53, 949, DateTimeKind.Local).AddTicks(783), "Planned" },
                    { 2L, "0d372061-38d2-4a97-b10d-4b39ba1802f5", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2349), "proj 2", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2331), "Planned" },
                    { 3L, "511fa3e2-1c25-43ec-b7ab-c247d02f0ae6", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2436), "proj 3", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2432), "Planned" },
                    { 4L, "50c554e8-021a-40b6-b5d0-fed9ab1debb1", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2487), "proj 4", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2485), "Planned" },
                    { 5L, "2a71e482-2b01-433d-9591-bfd514e0866d", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2497), "proj 5", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2494), "Planned" },
                    { 6L, "8330cf4c-84c5-4dbc-9f16-635c91bfc61c", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2508), "proj 6", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2506), "Planned" },
                    { 7L, "3bdddefd-6ab2-4ea7-8abd-435ba1719fc2", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2517), "proj 7", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2515), "Planned" },
                    { 8L, "4a7d3a08-6b74-4274-80b6-cbeef852630a", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2525), "proj 8", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2523), "Planned" },
                    { 9L, "f62b6d43-f962-4b04-81bd-e5f0e1ddf33b", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2540), "proj 9", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2537), "Planned" },
                    { 10L, "5aba5cf0-6b48-441d-8ec2-eced0ce30293", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2550), "proj 10", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2547), "Planned" },
                    { 11L, "064d451b-5481-4525-9e4e-034db032592e", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2558), "proj 11", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2556), "Planned" },
                    { 12L, "b26cd88b-d0af-4a72-a17b-b4ed7ca0b6ce", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2566), "proj 12", null, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(2564), "Planned" }
                });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Projects",
                columns: new[] { "Id", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 17L, "f1dc6e4d-6b95-4333-801e-cd292eadb4d7", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3496), "proj 17 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3493), "Planned" },
                    { 13L, "7dff24d4-b5bd-4497-bd7a-883022c4084c", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3152), "proj 13 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3142), "Planned" },
                    { 14L, "98914423-77a8-487c-be2a-c5f5881c6665", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3450), "proj 14 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3442), "Planned" },
                    { 15L, "c0733f10-5983-49b6-8b3a-c8c05abdf9d6", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3470), "proj 15 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3467), "Planned" },
                    { 16L, "a98a93ca-2f6b-423d-bb7e-f3b4a1bb8085", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3481), "proj 16 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3478), "Planned" },
                    { 21L, "963b568c-e212-4c86-8006-c2820bef7efb", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3541), "proj 21 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3539), "Planned" },
                    { 18L, "b3058ab9-89e0-4416-a424-471253b5522e", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3509), "proj 18 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3507), "Planned" },
                    { 19L, "4e4d3d12-453a-45dc-824c-99624cb3c4cf", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3520), "proj 19 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3518), "Planned" },
                    { 20L, "e460c64e-75f1-42c9-a9f3-6859b40910ca", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3531), "proj 20 with parent 3", 3L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(3528), "Planned" }
                });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Tasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 36L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2799), "task 36 for project 3 with parent task 3", 3L, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2796), "Planned" },
                    { 4L, "some description for task 4", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1052), "task 4 for project 4", null, 4L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1049), "Planned" },
                    { 5L, "some description for task 5", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1060), "task 5 for project 5", null, 5L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1058), "Planned" },
                    { 6L, "some description for task 6", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1071), "task 6 for project 6", null, 6L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1068), "Planned" },
                    { 1L, "some description for task 1", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(342), "task 1 for project 1", null, 1L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(71), "Planned" },
                    { 7L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1078), "task 7 for project 7", null, 7L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1076), "Planned" },
                    { 8L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1085), "task 8 for project 8", null, 8L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1083), "Planned" },
                    { 9L, "some description for task 9", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1093), "task 9 for project 9", null, 9L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1091), "Planned" },
                    { 10L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1102), "task 10 for project 10", null, 10L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1099), "Planned" },
                    { 35L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2788), "task 35 for project 3 with parent task 3", 3L, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2785), "Planned" },
                    { 34L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2758), "task 34 for project 3 with parent task 3", 3L, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2749), "Planned" },
                    { 26L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1655), "task 26 for project 3", null, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1652), "Planned" },
                    { 29L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1679), "task 29 for project 3", null, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1677), "Planned" },
                    { 28L, "some description for task 28", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1672), "task 28 for project 3", null, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1670), "Planned" },
                    { 27L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1663), "task 27 for project 3", null, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1661), "Planned" },
                    { 11L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1109), "task 11 for project 11", null, 11L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1107), "Planned" },
                    { 25L, "some description for task 25", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1632), "task 25 for project 3", null, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1623), "Planned" },
                    { 3L, "some description for task 3", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1043), "task 3 for project 3", null, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1040), "Planned" },
                    { 2L, "some description for task 2", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1019), "task 2 for project 2", null, 2L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1003), "Planned" },
                    { 33L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2370), "task 33 for project 1 with parent task 1", 1L, 1L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2368), "Planned" },
                    { 32L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2352), "task 32 for project 1 with parent task 1", 1L, 1L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2344), "Planned" },
                    { 31L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2100), "task 31 for project 1 with parent task 1", 1L, 1L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(2090), "Planned" },
                    { 30L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1687), "task 30 for project 3", null, 3L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1685), "Planned" },
                    { 12L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1115), "task 12 for project 12", null, 12L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1113), "Planned" }
                });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Projects",
                columns: new[] { "Id", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 22L, "a3dea03c-cfe5-4377-a328-003cba08b59f", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(4039), "proj 22 with parent 18", 18L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(4030), "Planned" },
                    { 23L, "d9fc3027-5a2c-425e-ba25-8f70081ac9b8", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(4070), "proj 23 with parent 18", 18L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(4066), "Planned" },
                    { 24L, "db2cf9e6-9512-4f51-bd17-116ffb4fb8fe", new DateTime(2021, 9, 9, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(4082), "proj 24 with parent 18", 18L, new DateTime(2021, 9, 6, 23, 4, 53, 951, DateTimeKind.Local).AddTicks(4079), "Planned" }
                });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Tasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 13L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1122), "task 13 for project 13", null, 13L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1120), "Planned" },
                    { 14L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1129), "task 14 for project 14", null, 14L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1127), "Planned" },
                    { 15L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1179), "task 15 for project 15", null, 15L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1176), "Planned" },
                    { 16L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1187), "task 16 for project 16", null, 16L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1185), "Planned" },
                    { 17L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1194), "task 17 for project 17", null, 17L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1192), "Planned" },
                    { 18L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1202), "task 18 for project 18", null, 18L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1200), "Planned" },
                    { 19L, "some description for task 19", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1211), "task 19 for project 19", null, 19L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1208), "Planned" },
                    { 20L, "some description for task 20", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1219), "task 20 for project 20", null, 20L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1217), "Planned" },
                    { 21L, null, new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1226), "task 21 for project 21", null, 21L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1224), "Planned" }
                });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Tasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 22L, "some description for task 22", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1234), "task 22 for project 22", null, 22L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1232), "Planned" });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Tasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 23L, "some description for task 23", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1243), "task 23 for project 23", null, 23L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1240), "Planned" });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Tasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 24L, "some description for task 24", new DateTime(2021, 9, 9, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1251), "task 24 for project 24", null, 24L, new DateTime(2021, 9, 6, 23, 4, 53, 953, DateTimeKind.Local).AddTicks(1249), "Planned" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentProjectId",
                schema: "system",
                table: "Projects",
                column: "ParentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                schema: "system",
                table: "Tasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "system");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "system");
        }
    }
}
