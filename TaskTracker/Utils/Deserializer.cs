using System;
using System.Text.Json;
using System.Threading.Tasks;
using TaskTracker.Models;
namespace TaskTracker.Utils;

public static class Deserializer<T> where T : new()
{
    public static T Deserialize(string json)
    {
        if (json.Equals(string.Empty))
        {
            return new T();
        }
        else
        {
            return JsonSerializer.Deserialize<T>(json) ?? new T();
        }
    }
}
