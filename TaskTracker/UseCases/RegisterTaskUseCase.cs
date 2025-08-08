using System.Text.Json;
using TaskTracker.Infraestructure;
using TaskTracker.Models;
using TaskTracker.Utils;

namespace TaskTracker.UseCases;

public class RegisterTaskUseCase
{
    private readonly HandleFileRepository _repository;

    public RegisterTaskUseCase(HandleFileRepository handleFileRepository)
    {
        _repository = handleFileRepository;
    }

    public void execute(string description)
    {
        var jsonString = _repository.ReadFile();
        
        var tasks = Deserializer<List<TaskModel>>.Deserialize(jsonString);

        tasks.Add(new TaskModel()
        {
            Id = tasks.LastOrDefault()?.Id + 1 ?? 1,
            Status = 0,
            Title = description,
            CreatedAt = DateTime.Now,
            UpdateAt = DateTime.Now,
        });
        
        tasks = tasks.OrderBy(x => x.Id).ToList();
        
        _repository.WriteFile(JsonSerializer.Serialize(tasks));
        
        Console.WriteLine("Task registered successfully!");
    }
}