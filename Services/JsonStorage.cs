using StudyPlannerWinForms.Models;
using System.Text.Json;

namespace StudyPlannerWinForms.Services;

internal class JsonStorage
{
    public static void Save(string path, AppData data)
    {
        var opts = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(data, opts);
        File.WriteAllText(path, json);
    }

    public static AppData Load(string path)
    {
        if (!File.Exists(path)) return new AppData();

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<AppData>(json) ?? new AppData();
    }
}