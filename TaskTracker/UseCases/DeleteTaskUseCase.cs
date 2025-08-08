using System.Text.Json;
using TaskTracker.Infraestructure;
using TaskTracker.Models;
using TaskTracker.Utils;

namespace TaskTracker.UseCases;

public class DeleteTaskUseCase
{
    private readonly HandleFileRepository _repository;

    public DeleteTaskUseCase(HandleFileRepository handleFileRepository)
    {
        _repository = handleFileRepository;
    }

    public void execute(int id)
    {
        var jsonString = _repository.ReadFile();

        var tasks = Deserializer<List<TaskModel>>.Deserialize(jsonString);

        var taskToDelete = tasks.FirstOrDefault(i => i.Id == id);

        if (taskToDelete is null)
        {
            Console.WriteLine("Task not found");
            return;
        }

        tasks.Remove(taskToDelete);

        tasks = tasks.OrderBy(x => x.Id).ToList();

        _repository.WriteFile(JsonSerializer.Serialize(tasks));

        Console.WriteLine("Task successfully deleted");
    }

}
