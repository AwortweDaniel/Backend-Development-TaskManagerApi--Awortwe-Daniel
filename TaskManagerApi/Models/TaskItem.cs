namespace TaskManagerApi.Models;

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TaskItemStatus Status { get; set; } = TaskItemStatus.Pending;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
