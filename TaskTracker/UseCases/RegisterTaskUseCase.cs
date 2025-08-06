using System.Text.Json;
using TaskTracker.Infraestructure;
using TaskTracker.Models;

namespace TaskTracker.UseCases;

public class RegisterTaskUseCase
{
    private readonly HandleFileRepository handleFileRepository = new HandleFileRepository();

    public void execute(string description)
    {
        var jsonString = handleFileRepository.ReadFile();
        
        List<TaskModel> tasks = JsonSerializer.Deserialize<List<TaskModel>>(jsonString) ?? new List<TaskModel>();
        
        tasks.Add(new TaskModel()
        {
            Id = tasks.LastOrDefault()?.Id + 1 ?? 1,
            Status = 0,
            Title = description,
            CreatedAt = DateTime.Now,
            UpdateAt = DateTime.Now,
        });
        
        tasks = tasks.OrderBy(x => x.Id).ToList();
        
        handleFileRepository.WriteFile(JsonSerializer.Serialize(tasks));
        
        Console.WriteLine("Task registered successfully!");
    }
}