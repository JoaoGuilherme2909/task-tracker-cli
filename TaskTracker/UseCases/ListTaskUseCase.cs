using TaskTracker.Infraestructure;
using TaskTracker.Models;
using TaskTracker.Utils;

namespace TaskTracker.UseCases;

public class ListTaskUseCase
{
    private readonly HandleFileRepository _repository;

    public ListTaskUseCase(HandleFileRepository handleFileRepository)
    {
        _repository = handleFileRepository; 
    }

    public List<TaskModel> execute(string filter)
    {
        var jsonString = _repository.ReadFile();

        var tasks = Deserializer<List<TaskModel>>.Deserialize(jsonString);

        if (filter.Equals(string.Empty))
        {
            return tasks.ToList();
        }

        var result = filter switch
        {
            "todo" => tasks.Where(i => i.Status == Status.Todo),
            "in-progress" => tasks.Where(i => i.Status == Status.InProgress),
            "done" => tasks.Where(i => i.Status == Status.Done)
        };

        return result.ToList();
    }
}
