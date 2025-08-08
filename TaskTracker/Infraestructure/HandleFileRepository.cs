using System.Text.Json;

namespace TaskTracker.Infraestructure;

public class HandleFileRepository
{
    string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/TaskTracker.json";

    public HandleFileRepository()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
    }

    public void WriteFile(string content)
    {
        File.WriteAllText(path, content);
    }

    public string ReadFile()
    {
        return File.ReadAllText(path, System.Text.Encoding.UTF8);
    }
}