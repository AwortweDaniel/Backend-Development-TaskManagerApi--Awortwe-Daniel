using TaskManagerApi.Models;
namespace TaskManagerApi.Dtos;

public class TaskResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskItemStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }

    public static TaskResponseDto FromEntity(TaskItem task) => new()
    {
        Id = task.Id,
        Title = task.Title,
        Description = task.Description,
        Status = task.Status,
        CreatedDate = task.CreatedDate,
    };
}
