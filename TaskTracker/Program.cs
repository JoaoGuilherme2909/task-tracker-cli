using TaskTracker.Infraestructure;
using TaskTracker.UseCases;

namespace TaskTracker;

class Program
{
    public static void Main(string[] args)
    {
        var arg = args[0];

        var handleFileRepository = new HandleFileRepository();
        
        if (arg is "add")
        {
            string title = args[1];

            new RegisterTaskUseCase(handleFileRepository).execute(title);

        }else if (arg is "list")
        {
            string filter = args[1];

            var list = new ListTaskUseCase(handleFileRepository).execute(args.Length > 1 ? filter : "");
            list.ForEach(i => Console.WriteLine(i.ToString()));
        }else if (arg is "mark-in-progress" || arg is "mark-done")
        {
            var operation = arg;
            var id = int.Parse(args[1]);

            new MarkTaskUseCase(handleFileRepository).execute(operation, id);
        }else if (arg is "delete")
        {
            int id = int.Parse(args[1]);

            new DeleteTaskUseCase(handleFileRepository).execute(id);
        }else if (arg is "update")
        {
            var id = int.Parse(args[1]);
            string title = args[2];

            new UpdateTaskUseCase(handleFileRepository).execute(id, title);
        }
        else
        {
            Console.WriteLine("Select a valid option");
        }
    }
}