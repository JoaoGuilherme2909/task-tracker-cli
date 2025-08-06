using TaskTracker.Models;

namespace TaskTracker.DTOs;

public class CreateTaskDto
{
    public string Title { get; set; }
    public Status Status {get; set; }
}