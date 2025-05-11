using System;
using System.IO;
using System.Text.Json;

namespace TimeProcessor
{
    public static class SettingsManager
    {
        public static SettingsModel LoadSettings(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("设置文件未找到", filePath);
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<SettingsModel>(json);
        }

        public static void SaveSettings(string filePath, SettingsModel settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
} 