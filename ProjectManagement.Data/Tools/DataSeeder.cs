using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Entities;

namespace ProjectManagement.Data.Tools
{
    public static class DataSeeder
    {
        private static readonly Random random = new Random(DateTime.Now.Ticks.GetHashCode());

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(GenerateProjects());
            modelBuilder.Entity<ProjectTask>().HasData(GenerateTasks());
        }

        public static IEnumerable<Project> GenerateProjects()
        {
            var projects = new List<Project>(Enumerable.Range(1, 12).Select(x => NewProject(x)));
            
            projects.AddRange(Enumerable.Range(projects.Count + 1, 9).Select(x => NewProject(x, 3)));
            projects.AddRange(Enumerable.Range(projects.Count + 1, 3).Select(x => NewProject(x, 18)));
            
            return projects;
        }

        public static IEnumerable<ProjectTask> GenerateTasks()
        {
            var rnd = new Random(DateTime.Now.Ticks.GetHashCode());

            var tasks = new List<ProjectTask>(Enumerable.Range(1, 24).Select(x => NewTask(x, x)));

            tasks.AddRange(Enumerable.Range(tasks.Count + 1, 6).Select(x => NewTask(x, 3)));
            tasks.AddRange(Enumerable.Range(tasks.Count + 1, 3).Select(x => NewTask(x, 1, 1)));
            tasks.AddRange(Enumerable.Range(tasks.Count + 1, 3).Select(x => NewTask(x, 3, 3)));

            return tasks;
        }

        public static Project NewProject(int id) => NewProject(id, null);
        public static Project NewProject(int id, int? parentId)
        {
            var project = new Project
            {
                ProjectId = id,
                Name = $"proj {id}",
                Code = Guid.NewGuid().ToString(),
                ParentProjectId = parentId,
                State = ItemState.Planned,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(3)
            };

            if (parentId.HasValue)
                project.Name += $" with parent {parentId}";

            return project;
        }

        public static ProjectTask NewTask(int id, int projectId) => NewTask(id, projectId, null);
        public static ProjectTask NewTask(int id, int projectId, int? parentTaskId)
        {
            var project = new ProjectTask
            {
                ProjectTaskId = id,
                Name = $"task {id} for project {projectId}",
                ProjectId = projectId,
                State = ItemState.Planned,
                //30% of tasks would have description
                Description = random.Next(0, 9) < 3 ? $"some description for task {id}" : null,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(3),
                ParentProjectTaskId = parentTaskId
            };

            if (parentTaskId.HasValue)
                project.Name += $" with parent task {parentTaskId}";

            return project;
        }
    }
}
