using System.Text.Json;
using TaskTracker.Infraestructure;
using TaskTracker.Models;
using TaskTracker.Utils;

namespace TaskTracker.UseCases;

public class MarkTaskUseCase
{
    private readonly HandleFileRepository _repository;

    public MarkTaskUseCase(HandleFileRepository handleFileRepository)
    {
        _repository = handleFileRepository;
    }

    public void execute(string mark, int id)
    {
        var jsonString = _repository.ReadFile();

        var tasks = Deserializer<List<TaskModel>>.Deserialize(jsonString);

        var task = tasks.FirstOrDefault(i => i.Id == id);

        if (task is null)
        {
            Console.WriteLine("Task not found");
            return;
        }

        if (mark.Equals("mark-in-progress")) task.Status = Status.InProgress;

        if (mark.Equals("mark-done")) task.Status = Status.Done;

        tasks = tasks.OrderBy(x => x.Id).ToList();

        _repository.WriteFile(JsonSerializer.Serialize(tasks));

        Console.WriteLine("List status updated successfully");
    }
}
