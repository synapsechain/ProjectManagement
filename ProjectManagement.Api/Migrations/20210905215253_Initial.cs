using System;
using Microsoft.EntityFrameworkCore.Migrations;
#pragma warning disable 8625

namespace ProjectManagement.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Projects_ParentProjectId",
                        column: x => x.ParentProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ParentTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 1, "114d17ed-4bde-478a-a978-ba917d2cf942", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(5340), "proj 1", null, new DateTime(2021, 9, 6, 0, 52, 53, 368, DateTimeKind.Local).AddTicks(4630), "Planned" },
                    { 2, "a11bce64-23b0-435a-98c2-d44eef6cc905", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6510), "proj 2", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6490), "Planned" },
                    { 3, "5564c612-7da9-40c4-808a-3fb57e1d6c23", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6640), "proj 3", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6640), "Planned" },
                    { 4, "df3eabe7-3d01-46f6-8b00-6231854813c3", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6660), "proj 4", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6650), "Planned" },
                    { 5, "2edc45f4-988d-4123-a5a3-0a33396f0356", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6670), "proj 5", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6660), "Planned" },
                    { 6, "b2fc6aca-30f1-4516-ba22-a8863921dff9", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6680), "proj 6", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6680), "Planned" },
                    { 7, "2af1fdbd-6a2d-4705-af35-25cc746d8468", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6690), "proj 7", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6690), "Planned" },
                    { 8, "be5cec30-e510-4a62-895e-ece9fbcfab6e", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6710), "proj 8", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6700), "Planned" },
                    { 9, "1b682342-5646-4846-a516-0d33e9dca756", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6720), "proj 9", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6710), "Planned" },
                    { 10, "51fec66d-e0e3-4f7f-9bec-d2a8447794e0", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6730), "proj 10", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6730), "Planned" },
                    { 11, "b965af40-c2e9-406f-9f63-d3de42a02d17", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6740), "proj 11", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6740), "Planned" },
                    { 12, "cf6a2ac9-9725-492d-b3af-d73d2f35ae3b", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6750), "proj 12", null, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(6750), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(8420), "task 1 for project 1", null, 1, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(7940), "Planned" },
                    { 10, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9800), "task 10 for project 10", null, 10, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9800), "Planned" },
                    { 9, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9790), "task 9 for project 9", null, 9, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9780), "Planned" },
                    { 8, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9780), "task 8 for project 8", null, 8, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9780), "Planned" },
                    { 7, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9770), "task 7 for project 7", null, 7, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9770), "Planned" },
                    { 6, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9760), "task 6 for project 6", null, 6, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9760), "Planned" },
                    { 5, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9750), "task 5 for project 5", null, 5, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9740), "Planned" },
                    { 4, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9740), "task 4 for project 4", null, 4, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9730), "Planned" },
                    { 36, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(2760), "task 36 for project 3 with parent task 3", 3, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(2760), "Planned" },
                    { 35, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(2740), "task 35 for project 3 with parent task 3", 3, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(2740), "Planned" },
                    { 34, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(2700), "task 34 for project 3 with parent task 3", 3, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(2690), "Planned" },
                    { 30, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(610), "task 30 for project 3", null, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(610), "Planned" },
                    { 29, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(600), "task 29 for project 3", null, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(600), "Planned" },
                    { 28, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(590), "task 28 for project 3", null, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(590), "Planned" },
                    { 27, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(580), "task 27 for project 3", null, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(580), "Planned" },
                    { 11, "some description for task 11", new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9810), "task 11 for project 11", null, 11, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9810), "Planned" },
                    { 26, "some description for task 26", new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(570), "task 26 for project 3", null, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(570), "Planned" },
                    { 3, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9730), "task 3 for project 3", null, 3, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9720), "Planned" },
                    { 2, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9700), "task 2 for project 2", null, 2, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9680), "Planned" },
                    { 33, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(2000), "task 33 for project 1 with parent task 1", 1, 1, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(2000), "Planned" },
                    { 32, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(1920), "task 32 for project 1 with parent task 1", 1, 1, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(1910), "Planned" },
                    { 31, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(1320), "task 31 for project 1 with parent task 1", 1, 1, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(1310), "Planned" },
                    { 25, null, new DateTime(2021, 9, 9, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(540), "task 25 for project 3", null, 3, new DateTime(2021, 9, 6, 0, 52, 53, 380, DateTimeKind.Local).AddTicks(520), "Planned" },
                    { 12, "some description for task 12", new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9820), "task 12 for project 12", null, 12, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9820), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 21, "fa42b22c-faf3-43f2-977a-9b09113ad949", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8680), "proj 21 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8680), "Planned" },
                    { 20, "fa72ca95-3043-4be3-ae34-2356b33e1028", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8670), "proj 20 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8670), "Planned" },
                    { 19, "071fa488-465c-4194-8b10-281d9f30445d", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8660), "proj 19 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8650), "Planned" },
                    { 18, "657a996f-390a-43cc-9c5b-10964386446c", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8640), "proj 18 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8640), "Planned" },
                    { 17, "047a2898-2e69-465c-9ff8-1330b69f0252", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8630), "proj 17 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8620), "Planned" },
                    { 16, "702297c6-c451-471f-8c16-d075f1a9b941", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8610), "proj 16 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8610), "Planned" },
                    { 15, "d10212a4-3633-4298-a7c9-9a12d38cc992", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8600), "proj 15 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8590), "Planned" },
                    { 14, "0a1cc6b2-7244-401a-aef1-213049f4fcd5", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8470), "proj 14 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(8450), "Planned" },
                    { 13, "3b09d51f-f0a4-49ec-8b32-35f32856bcb4", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(7820), "proj 13 with parent 3", 3, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(7800), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 13, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9830), "task 13 for project 13", null, 13, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9830), "Planned" },
                    { 14, "some description for task 14", new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9840), "task 14 for project 14", null, 14, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9840), "Planned" },
                    { 15, "some description for task 15", new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9850), "task 15 for project 15", null, 15, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9850), "Planned" },
                    { 16, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9860), "task 16 for project 16", null, 16, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9860), "Planned" },
                    { 17, "some description for task 17", new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9880), "task 17 for project 17", null, 17, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9870), "Planned" },
                    { 18, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9890), "task 18 for project 18", null, 18, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9880), "Planned" },
                    { 19, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9890), "task 19 for project 19", null, 19, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9890), "Planned" },
                    { 20, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9900), "task 20 for project 20", null, 20, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9900), "Planned" },
                    { 21, "some description for task 21", new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9910), "task 21 for project 21", null, 21, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9910), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 22, "e0e22f58-347a-4054-9674-b675113c7321", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(9470), "proj 22 with parent 18", 18, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(9460), "Planned" },
                    { 23, "144501aa-fe24-4af1-8e5a-d465f6a54c4f", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(9510), "proj 23 with parent 18", 18, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(9510), "Planned" },
                    { 24, "762e6417-671d-4898-8f37-311cad7d6a90", new DateTime(2021, 9, 9, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(9520), "proj 24 with parent 18", 18, new DateTime(2021, 9, 6, 0, 52, 53, 376, DateTimeKind.Local).AddTicks(9520), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 22, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9920), "task 22 for project 22", null, 22, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9920), "Planned" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 23, "some description for task 23", new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9930), "task 23 for project 23", null, 23, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9930), "Planned" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "FinishDate", "Name", "ParentTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 24, null, new DateTime(2021, 9, 9, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9940), "task 24 for project 24", null, 24, new DateTime(2021, 9, 6, 0, 52, 53, 379, DateTimeKind.Local).AddTicks(9940), "Planned" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentProjectId",
                table: "Projects",
                column: "ParentProjectId");

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
