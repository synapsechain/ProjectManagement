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
                    { 1, "df3121ce-3231-4c7c-a21a-7989e39f25f1", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(5837), "generated project 1", null, new DateTime(2020, 4, 12, 15, 17, 43, 710, DateTimeKind.Local).AddTicks(5210), "Planned" },
                    { 2, "590033ef-a4fb-4839-9119-b7b1e80d23c2", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6855), "generated project 2", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6836), "Planned" },
                    { 3, "a08ec813-e251-469f-9afd-f0f127833eff", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6880), "generated project 3", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6878), "Planned" },
                    { 4, "46ec523c-4aa5-4d58-bfd7-28a35659d3d9", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6887), "generated project 4", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6885), "Planned" },
                    { 5, "4d6c7f2d-7b70-4ab0-8a87-5a43246967e0", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6894), "generated project 5", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6891), "Planned" },
                    { 6, "a3f707fc-cbe7-48a4-a811-a93d4f7296d4", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6900), "generated project 6", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6898), "Planned" },
                    { 7, "1b60b5e9-c018-4292-bb72-f683a5456b7c", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6917), "generated project 7", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6914), "Planned" },
                    { 8, "7059803f-4eef-437a-a12f-43371fd6c958", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6923), "generated project 8", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6921), "Planned" },
                    { 9, "1cb95080-c640-4f1d-8835-5af6755a48d2", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6930), "generated project 9", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6927), "Planned" },
                    { 10, "ead16532-0424-4616-b2d0-6b54838e8758", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6936), "generated project 10", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6933), "Planned" },
                    { 11, "be622dd8-690f-4e33-9c5d-cd20e36593be", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6942), "generated project 11", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6940), "Planned" },
                    { 12, "fb31eddc-3255-45d1-83ca-7f0f75273070", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6948), "generated project 12", null, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6946), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 1, "some description for task 1", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(8661), "task 1", null, 1, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(8259), "Planned" },
                    { 10, "some description for task 10", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9137), "task 10", null, 10, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9135), "Planned" },
                    { 9, "some description for task 9", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9130), "task 9", null, 9, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9128), "Planned" },
                    { 8, "some description for task 8", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9124), "task 8", null, 8, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9122), "Planned" },
                    { 7, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9117), "task 7", null, 7, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9115), "Planned" },
                    { 6, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9112), "task 6", null, 6, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9110), "Planned" },
                    { 5, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9107), "task 5", null, 5, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9105), "Planned" },
                    { 4, "some description for task 4", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9102), "task 4", null, 4, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9099), "Planned" },
                    { 30, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9246), "task 30", null, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9243), "Planned" },
                    { 29, "some description for task 29", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9241), "task 29", null, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9238), "Planned" },
                    { 28, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9234), "task 28", null, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9232), "Planned" },
                    { 27, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9229), "task 27", null, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9227), "Planned" },
                    { 11, "some description for task 11", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9144), "task 11", null, 11, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9142), "Planned" },
                    { 26, "some description for task 26", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9224), "task 26", null, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9222), "Planned" },
                    { 3, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9083), "task 3", null, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9080), "Planned" },
                    { 2, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9071), "task 2", null, 2, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9055), "Planned" },
                    { 25, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9218), "task 25", null, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9216), "Planned" },
                    { 12, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9149), "task 12", null, 12, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9147), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 21, "aa8cfb49-29e7-4afe-acb0-a3eeb45b6a8f", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7008), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7006), "Planned" },
                    { 20, "40664c32-b327-4700-8d02-4deebb8314da", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7002), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6999), "Planned" },
                    { 19, "e9dd0c2c-1fb8-4875-9c7f-bcfb818a203b", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6996), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6993), "Planned" },
                    { 18, "b7c8d0aa-244c-4dc2-9884-25fc8d96c20c", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6989), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6987), "Planned" },
                    { 17, "87bf42a0-20b0-4f00-8365-cb362c1927ad", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6983), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6980), "Planned" },
                    { 16, "729b744c-fe0b-4666-aa3b-b7208b159b70", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6976), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6974), "Planned" },
                    { 15, "de195284-6ad9-4214-b593-ace66a05eac2", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6970), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6967), "Planned" },
                    { 14, "7de2f47f-58ea-4028-a500-95c1160be413", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6961), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6959), "Planned" },
                    { 13, "a9a129e1-6994-4785-863d-e1c4d2401342", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6955), "nested project", 3, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(6952), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 31, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9250), "task 31", 1, 1, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9248), "Planned" },
                    { 34, "some description for task 34", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9268), "task 34", 3, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9266), "Planned" },
                    { 21, "some description for task 21", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9197), "task 21", null, 21, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9194), "Planned" },
                    { 20, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9190), "task 20", null, 20, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9188), "Planned" },
                    { 19, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9185), "task 19", null, 19, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9183), "Planned" },
                    { 18, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9180), "task 18", null, 18, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9178), "Planned" },
                    { 35, "some description for task 35", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9275), "task 35", 3, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9273), "Planned" },
                    { 36, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9280), "task 36", 3, 3, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9278), "Planned" },
                    { 16, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9171), "task 16", null, 16, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9168), "Planned" },
                    { 15, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9165), "task 15", null, 15, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9163), "Planned" },
                    { 14, "some description for task 14", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9161), "task 14", null, 14, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9158), "Planned" },
                    { 13, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9154), "task 13", null, 13, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9152), "Planned" },
                    { 33, "some description for task 33", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9262), "task 33", 1, 1, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9259), "Planned" },
                    { 32, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9255), "task 32", 1, 1, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9253), "Planned" },
                    { 17, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9175), "task 17", null, 17, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9173), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 23, "3b0a7592-057f-4489-b95f-099c560ae266", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7023), "nested project", 18, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7021), "Planned" },
                    { 24, "d878f922-8f86-44f9-8812-51a5d9a4c2dd", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7029), "nested project", 18, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7027), "Planned" },
                    { 22, "36616c08-c73d-4a05-b642-beb26efe4204", new DateTime(2020, 4, 15, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7015), "nested project", 18, new DateTime(2020, 4, 12, 15, 17, 43, 712, DateTimeKind.Local).AddTicks(7013), "Planned" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 22, "some description for task 22", new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9203), "task 22", null, 22, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9201), "Planned" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 23, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9208), "task 23", null, 23, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9206), "Planned" });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 24, null, new DateTime(2020, 4, 15, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9213), "task 24", null, 24, new DateTime(2020, 4, 12, 15, 17, 43, 714, DateTimeKind.Local).AddTicks(9211), "Planned" });

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
