using System.ComponentModel.DataAnnotations;
using TaskManagerApi.Models;

namespace TaskManagerApi.Dtos;

public class TaskCreateDto : IValidatableObject
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; } = string.Empty;

    [EnumDataType(typeof(TaskItemStatus))]
    public TaskItemStatus Status { get; set; } = TaskItemStatus.Pending;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Title) || Title.Trim().Length < 3)
            yield return new ValidationResult("Title must contain at least 3 non-space characters.", new[] { nameof(Title) });
    }
}
