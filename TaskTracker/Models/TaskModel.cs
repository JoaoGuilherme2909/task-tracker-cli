namespace TaskTracker.Models;

public class TaskModel
{
    public int Id {get; set;}
    public string Title {get; set;} = String.Empty;
    public Status Status { get; set; }
    public DateTime CreatedAt {get; set;}
    public DateTime UpdateAt {get; set;}
}