using TaskManagerApi.Models;


namespace TaskManagerApi.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Tasks.Any())
        {
            return;
        }

        context.Tasks.AddRange(
            new TaskItem
            {
                Title = "Set up the project",
                Description = "Create the repository, folder structure and base configuration.",
                Status = TaskItemStatus.Completed,
                CreatedDate = DateTime.UtcNow.AddDays(-5),
            },
            new TaskItem
            {
                Title = "Implement task endpoints",
                Description = "Add GET, POST, PUT and DELETE endpoints for /api/tasks.",
                Status = TaskItemStatus.InProgress,
                CreatedDate = DateTime.UtcNow.AddDays(-3),
            },
            new TaskItem
            {
                Title = "Write the README",
                Description = "Explain how to set up and run the project.",
                Status = TaskItemStatus.Pending,
                CreatedDate = DateTime.UtcNow.AddDays(-1),
            }
        );

        context.SaveChanges();
    }
}
