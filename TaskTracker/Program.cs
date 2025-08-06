using TaskTracker.UseCases;

namespace TaskTracker;

class Program
{
    public static void Main(string[] args)
    {
        var arg = args[0];
        
        if (arg is "add")
        {
            new RegisterTaskUseCase().execute(args[1]);
        }
    }
}