using System.Text.Json;

namespace TaskTracker.Infraestructure;

public class HandleFileRepository
{
    string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Documents/TaskTracker.json";

    public void WriteFile(string content)
    {
        File.WriteAllText(path, content);
    }

    public string ReadFile()
    {
        return File.ReadAllText(path, System.Text.Encoding.UTF8);
    }
}