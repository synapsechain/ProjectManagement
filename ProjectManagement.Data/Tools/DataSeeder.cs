using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Entities;

namespace ProjectManagement.Data.Tools
{
    public static class DataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(GenerateProjects());
            modelBuilder.Entity<ProjectTask>().HasData(GenerateTasks());
        }

        public static IEnumerable<Project> GenerateProjects()
        {
            var projects = new List<Project>(Enumerable.Range(1, 12)
                .Select(x => new Project()
                {
                    Name = $"generated project {x}",
                    ProjectId = x,
                }));

            projects.AddRange(Enumerable.Range(projects.Count + 1, 9)
                .Select(x => new Project()
                {
                    Name = "nested project",
                    ParentProjectId = 3,
                    ProjectId = x,
                }));

            projects.AddRange(Enumerable.Range(projects.Count + 1, 3)
                .Select(x => new Project()
                {
                    Name = "nested project",
                    ParentProjectId = 18,
                    ProjectId = x,
                }));

            projects.ForEach(x =>
            {
                x.StartDate = DateTime.Now;
                x.FinishDate = DateTime.Now.AddDays(3);
                x.Code = Guid.NewGuid().ToString();
            });

            return projects;
        }

        public static IEnumerable<ProjectTask> GenerateTasks()
        {
            var rnd = new Random(DateTime.Now.Ticks.GetHashCode());

            var tasks = new List<ProjectTask>(Enumerable.Range(1, 24)
                .Select(x => new ProjectTask()
                {
                    Name = $"task {x}",
                    ProjectTaskId = x,
                    ProjectId = x,
                }));

            tasks.AddRange(Enumerable.Range(tasks.Count + 1, 6)
                .Select(x => new ProjectTask()
                {
                    Name = $"task {x}",
                    ProjectTaskId = x,
                    ProjectId = 3,
                }));

            tasks.AddRange(Enumerable.Range(tasks.Count + 1, 3)
                .Select(x => new ProjectTask()
                {
                    Name = $"task {x}",
                    ProjectTaskId = x,
                    ProjectId = 1,
                    ParentProjectTaskId = 1
                }));

            tasks.AddRange(Enumerable.Range(tasks.Count + 1, 3)
                .Select(x => new ProjectTask()
                {
                    Name = $"task {x}",
                    ProjectTaskId = x,
                    ProjectId = 3,
                    ParentProjectTaskId = 3
                }));

            tasks.ForEach(x =>
            {
                //30% of tasks will have description
                x.Description = rnd.Next(0, 9) < 3 ? $"some description for task {x.ProjectTaskId}" : null;
                x.StartDate = DateTime.Now;
                x.FinishDate = DateTime.Now.AddDays(3);
            });

            return tasks;
        }
    }
}
