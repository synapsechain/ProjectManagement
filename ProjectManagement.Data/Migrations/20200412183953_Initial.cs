using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ParentProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Projects_ParentProjectId",
                        column: x => x.ParentProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    ProjectTaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    ParentProjectTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.ProjectTaskId);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_ProjectTasks_ParentProjectTaskId",
                        column: x => x.ParentProjectTaskId,
                        principalTable: "ProjectTasks",
                        principalColumn: "ProjectTaskId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 1, "fc4c1eaa-576f-4fd8-ba70-e0adc1087271", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(2640), "proj 1", null, new DateTime(2020, 4, 12, 21, 39, 53, 376, DateTimeKind.Local).AddTicks(3476), "Planned" },
                    { 2, "af812c36-6d2e-456e-88bd-e7d7e209332b", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3388), "proj 2", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3370), "Planned" },
                    { 3, "d37255b9-41b1-43e0-ae7c-31fac07a359c", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3462), "proj 3", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3458), "Planned" },
                    { 4, "03645ae7-52bc-447f-b02c-afcd2c0ce805", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3472), "proj 4", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3470), "Planned" },
                    { 5, "5d91de02-a8f0-4b72-b275-40629bc89fc5", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3481), "proj 5", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3478), "Planned" },
                    { 6, "0e2f43fa-a001-4b67-a49c-53f8e78fcb28", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3499), "proj 6", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3497), "Planned" },
                    { 7, "f176f4a6-6aef-4978-a1d4-e006a39baba8", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3508), "proj 7", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3505), "Planned" },
                    { 8, "79f60518-b8d3-4620-b62e-9a208c15478f", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3516), "proj 8", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3514), "Planned" },
                    { 9, "2fd02546-b3af-4b2b-b2ff-707ed02f1cf8", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3524), "proj 9", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3522), "Planned" },
                    { 10, "29ccc235-5463-4330-bda3-023a124f6e40", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3534), "proj 10", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3531), "Planned" },
                    { 11, "e1f6bb89-0cfa-40db-ba82-e4a17906eebe", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3542), "proj 11", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3540), "Planned" },
                    { 12, "7edf9a4b-6b44-42ee-b46f-db1dee4ce35e", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3551), "proj 12", null, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(3548), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(5215), "task 1 for project 1", null, 1, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(4833), "Planned" },
                    { 10, "some description for task 10", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6233), "task 10 for project 10", null, 10, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6231), "Planned" },
                    { 9, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6223), "task 9 for project 9", null, 9, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6220), "Planned" },
                    { 8, "some description for task 8", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6215), "task 8 for project 8", null, 8, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6213), "Planned" },
                    { 7, "some description for task 7", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6206), "task 7 for project 7", null, 7, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6204), "Planned" },
                    { 6, "some description for task 6", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6197), "task 6 for project 6", null, 6, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6195), "Planned" },
                    { 5, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6185), "task 5 for project 5", null, 5, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6183), "Planned" },
                    { 4, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6178), "task 4 for project 4", null, 4, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6175), "Planned" },
                    { 30, "some description for task 30", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6952), "task 30 for project 3", null, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6949), "Planned" },
                    { 29, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6943), "task 29 for project 3", null, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6940), "Planned" },
                    { 28, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6935), "task 28 for project 3", null, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6933), "Planned" },
                    { 27, "some description for task 27", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6928), "task 27 for project 3", null, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6925), "Planned" },
                    { 11, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6241), "task 11 for project 11", null, 11, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6238), "Planned" },
                    { 26, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6918), "task 26 for project 3", null, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6915), "Planned" },
                    { 3, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6170), "task 3 for project 3", null, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6166), "Planned" },
                    { 2, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6148), "task 2 for project 2", null, 2, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6131), "Planned" },
                    { 25, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6894), "task 25 for project 3", null, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6884), "Planned" },
                    { 12, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6248), "task 12 for project 12", null, 12, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6246), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 21, "bc47192d-6c24-48f2-b8af-87beb9ec2398", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4816), "proj 21 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4814), "Planned" },
                    { 20, "0e9841bd-0609-402c-ad58-aa75faa6fa77", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4806), "proj 20 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4804), "Planned" },
                    { 19, "c67a791e-3873-471b-bdf4-3c11cbf3c1fb", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4796), "proj 19 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4794), "Planned" },
                    { 18, "2dffa734-4e16-4443-8c6e-70a6a013c9cd", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4786), "proj 18 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4783), "Planned" },
                    { 17, "c447fdd9-47a0-4393-86bb-7fa64734ec29", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4772), "proj 17 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4769), "Planned" },
                    { 16, "7d17a97f-8741-4164-8b6b-7e6f8f4b2311", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4761), "proj 16 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4759), "Planned" },
                    { 15, "6386b167-5478-4370-aa1b-12e5696d54e2", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4751), "proj 15 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4748), "Planned" },
                    { 14, "292e6f33-2b14-4b4e-a597-37a0bba07626", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4731), "proj 14 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4722), "Planned" },
                    { 13, "7b4d3779-1127-4ee9-9223-1f5cdd428943", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4282), "proj 13 with parent 3", 3, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(4272), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 31, "some description for task 31", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(7523), "task 31 for project 1 with parent task 1", 1, 1, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(7513), "Planned" },
                    { 34, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(8488), "task 34 for project 3 with parent task 3", 3, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(8479), "Planned" },
                    { 21, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6358), "task 21 for project 21", null, 21, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6356), "Planned" },
                    { 20, "some description for task 20", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6351), "task 20 for project 20", null, 20, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6348), "Planned" },
                    { 19, "some description for task 19", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6342), "task 19 for project 19", null, 19, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6339), "Planned" },
                    { 18, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6332), "task 18 for project 18", null, 18, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6330), "Planned" },
                    { 35, "some description for task 35", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(8521), "task 35 for project 3 with parent task 3", 3, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(8518), "Planned" },
                    { 36, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(8531), "task 36 for project 3 with parent task 3", 3, 3, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(8529), "Planned" },
                    { 16, "some description for task 16", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6280), "task 16 for project 16", null, 16, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6277), "Planned" },
                    { 15, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6271), "task 15 for project 15", null, 15, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6268), "Planned" },
                    { 14, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6263), "task 14 for project 14", null, 14, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6261), "Planned" },
                    { 13, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6256), "task 13 for project 13", null, 13, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6253), "Planned" },
                    { 33, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(7945), "task 33 for project 1 with parent task 1", 1, 1, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(7942), "Planned" },
                    { 32, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(7924), "task 32 for project 1 with parent task 1", 1, 1, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(7915), "Planned" },
                    { 17, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6323), "task 17 for project 17", null, 17, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6320), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 23, "b12f1efa-8e5d-4aec-824e-2f85dfa8a9c1", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(5552), "proj 23 with parent 18", 18, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(5549), "Planned" },
                    { 24, "f17ca710-86b1-41f9-9e55-030040c097e0", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(5564), "proj 24 with parent 18", 18, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(5561), "Planned" },
                    { 22, "264357bb-4597-4c58-a8b6-ab11d86098d6", new DateTime(2020, 4, 15, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(5444), "proj 22 with parent 18", 18, new DateTime(2020, 4, 12, 21, 39, 53, 378, DateTimeKind.Local).AddTicks(5434), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 22, "some description for task 22", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6367), "task 22 for project 22", null, 22, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6365), "Planned" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 23, null, new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6375), "task 23 for project 23", null, 23, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6372), "Planned" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 24, "some description for task 24", new DateTime(2020, 4, 15, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6384), "task 24 for project 24", null, 24, new DateTime(2020, 4, 12, 21, 39, 53, 380, DateTimeKind.Local).AddTicks(6381), "Planned" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentProjectId",
                table: "Projects",
                column: "ParentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ParentProjectTaskId",
                table: "ProjectTasks",
                column: "ParentProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
