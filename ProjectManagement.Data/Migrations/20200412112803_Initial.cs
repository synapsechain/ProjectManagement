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
                    State = table.Column<int>(nullable: false),
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
                    State = table.Column<int>(nullable: false),
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
                    { 1, "dc45a0f2-d338-4679-9316-bb32c546e66a", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(870), "generated project 1", null, new DateTime(2020, 4, 12, 14, 28, 3, 75, DateTimeKind.Local).AddTicks(1230), 0 },
                    { 2, "d0f1595e-4058-4a8b-aa19-4dcf5588c260", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1860), "generated project 2", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1833), 0 },
                    { 3, "0924499c-0e42-49cd-9761-719480cc73ca", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1887), "generated project 3", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1884), 0 },
                    { 4, "67353727-5573-4364-8694-74c5e4115c30", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1893), "generated project 4", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1891), 0 },
                    { 5, "d3a1bf3b-2bfb-4f35-8df4-2308932ae791", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1899), "generated project 5", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1897), 0 },
                    { 6, "66763c95-aa06-4bbb-a57e-045339325e1a", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1906), "generated project 6", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1904), 0 },
                    { 7, "7afbd710-d02e-4e51-abac-f26b6b0b8282", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1912), "generated project 7", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1910), 0 },
                    { 8, "25367359-d07a-444f-8806-b426aec3c168", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1929), "generated project 8", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1927), 0 },
                    { 9, "9c30f0cf-9764-4b2d-88a9-e43d07620093", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1936), "generated project 9", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1934), 0 },
                    { 10, "50912d51-3592-4ef3-97ea-474dc4936bfa", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1942), "generated project 10", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1940), 0 },
                    { 11, "9b1aa5af-cdbb-4411-bd22-7bc4c209ca9d", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1949), "generated project 11", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1946), 0 },
                    { 12, "6b8a6885-1e6f-4c9c-8eaa-b3e1e5eb468a", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1955), "generated project 12", null, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1953), 0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(3214), "task 1", null, 1, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(2810), 0 },
                    { 10, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4034), "task 10", null, 10, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4032), 0 },
                    { 9, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4029), "task 9", null, 9, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4027), 0 },
                    { 8, "some description for task 8", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4024), "task 8", null, 8, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4022), 0 },
                    { 7, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4017), "task 7", null, 7, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4015), 0 },
                    { 6, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4012), "task 6", null, 6, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4010), 0 },
                    { 5, "some description for task 5", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4007), "task 5", null, 5, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4005), 0 },
                    { 4, "some description for task 4", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(3988), "task 4", null, 4, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(3980), 0 },
                    { 30, "some description for task 30", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4144), "task 30", null, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4142), 0 },
                    { 29, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4137), "task 29", null, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4135), 0 },
                    { 28, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4133), "task 28", null, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4130), 0 },
                    { 27, "some description for task 27", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4128), "task 27", null, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4126), 0 },
                    { 11, "some description for task 11", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4041), "task 11", null, 11, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4038), 0 },
                    { 26, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4122), "task 26", null, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4119), 0 },
                    { 3, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(3636), "task 3", null, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(3634), 0 },
                    { 2, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(3625), "task 2", null, 2, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(3609), 0 },
                    { 25, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4117), "task 25", null, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4115), 0 },
                    { 12, "some description for task 12", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4047), "task 12", null, 12, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4045), 0 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 21, "28efd369-c698-49fc-95fc-f01956e0210d", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2016), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2014), 0 },
                    { 20, "8c92244f-276d-42bf-b25f-87df40e6d4b2", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2010), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2007), 0 },
                    { 19, "1ff51c15-3711-429f-8cae-3ba8f9f677b9", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2003), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2001), 0 },
                    { 18, "4efd4e68-ae38-4fdd-922b-580f8f2e6764", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1997), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1995), 0 },
                    { 17, "063a42db-52a0-48a0-87e3-f790a53092bc", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1990), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1988), 0 },
                    { 16, "879fcdf5-110b-4c6c-9655-ec9f1aa5bf9a", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1984), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1981), 0 },
                    { 15, "d9dc27bb-b46a-4e88-919b-35f7d331ab47", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1975), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1973), 0 },
                    { 14, "a13f5700-5448-41be-8cdf-0eeea5983ee4", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1969), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1966), 0 },
                    { 13, "397ba183-29af-4538-bfcc-664d77c4bddb", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1962), "nested project", 3, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(1959), 0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 31, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4149), "task 31", 1, 1, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4147), 0 },
                    { 34, "some description for task 34", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4166), "task 34", 3, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4164), 0 },
                    { 21, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4094), "task 21", null, 21, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4092), 0 },
                    { 20, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4090), "task 20", null, 20, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4087), 0 },
                    { 19, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4085), "task 19", null, 19, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4082), 0 },
                    { 18, "some description for task 18", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4080), "task 18", null, 18, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4078), 0 },
                    { 35, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4171), "task 35", 3, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4169), 0 },
                    { 36, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4176), "task 36", 3, 3, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4174), 0 },
                    { 16, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4069), "task 16", null, 16, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4066), 0 },
                    { 15, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4064), "task 15", null, 15, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4061), 0 },
                    { 14, "some description for task 14", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4059), "task 14", null, 14, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4056), 0 },
                    { 13, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4052), "task 13", null, 13, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4050), 0 },
                    { 33, "some description for task 33", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4160), "task 33", 1, 1, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4158), 0 },
                    { 32, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4154), "task 32", 1, 1, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4151), 0 },
                    { 17, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4074), "task 17", null, 17, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4071), 0 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Code", "FinishDate", "Name", "ParentProjectId", "StartDate", "State" },
                values: new object[,]
                {
                    { 23, "eaf26458-3960-4961-98ae-52a1ae62f12c", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2029), "nested project", 18, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2027), 0 },
                    { 24, "420d6355-cbba-4314-8396-4924ee13d28a", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2037), "nested project", 18, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2035), 0 },
                    { 22, "1f7c980a-ba4f-4f35-8103-e9d00d9765da", new DateTime(2020, 4, 15, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2023), "nested project", 18, new DateTime(2020, 4, 12, 14, 28, 3, 77, DateTimeKind.Local).AddTicks(2020), 0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 22, null, new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4099), "task 22", null, 22, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4097), 0 });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 23, "some description for task 23", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4105), "task 23", null, 23, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4103), 0 });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "Description", "FinishDate", "Name", "ParentProjectTaskId", "ProjectId", "StartDate", "State" },
                values: new object[] { 24, "some description for task 24", new DateTime(2020, 4, 15, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4112), "task 24", null, 24, new DateTime(2020, 4, 12, 14, 28, 3, 79, DateTimeKind.Local).AddTicks(4110), 0 });

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
