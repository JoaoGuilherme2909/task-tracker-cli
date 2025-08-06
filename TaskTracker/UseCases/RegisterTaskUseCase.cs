using TaskTracker.DTOs;
using TaskTracker.Infraestructure;

namespace TaskTracker.UseCases;

public class RegisterTaskUseCase
{
    private readonly HandleFileRepository handleFileRepository = new HandleFileRepository();

    public void execute()
    {
        
    }

    public void validate(CreateTaskDto createTaskDto)
    {
        
    }
}