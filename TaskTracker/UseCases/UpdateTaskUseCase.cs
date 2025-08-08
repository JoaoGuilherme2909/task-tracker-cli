using System.Text.Json;
using TaskTracker.Infraestructure;
using TaskTracker.Models;
using TaskTracker.Utils;

namespace TaskTracker.UseCases;

public class UpdateTaskUseCase
{
    private readonly HandleFileRepository _repository;

    public UpdateTaskUseCase(HandleFileRepository handleFileRepository)
    {
        _repository = handleFileRepository;
    }

    public void execute(int id, string description)
    {
        var jsonString = _repository.ReadFile();

        var tasks = Deserializer<List<TaskModel>>.Deserialize(jsonString);

        var taskToUpdate = tasks.FirstOrDefault(i => i.Id == id);

        if (taskToUpdate is null)
        {
            Console.WriteLine("Task not found");
            return;
        }

        taskToUpdate.Title = description;

        tasks = tasks.OrderBy(x => x.Id).ToList();

        _repository.WriteFile(JsonSerializer.Serialize(tasks));

        Console.WriteLine("Task update successfully!");
    }
}
