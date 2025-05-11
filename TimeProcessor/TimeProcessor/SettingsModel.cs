using System.Collections.Generic;

namespace TimeProcessor
{
    public class SettingsModel
    {
        public WorkTimes work_times { get; set; } = new WorkTimes();
        public ValidTimes valid_times { get; set; } = new ValidTimes();
        public FileSettings file_settings { get; set; } = new FileSettings();
        public SystemSettings system_settings { get; set; } = new SystemSettings();
    }

    public class WorkTimes
    {
        public string morning_start { get; set; } = "08:00";
        public string noon_end { get; set; } = "12:00";
        public string afternoon_start { get; set; } = "13:00";
        public string evening_end { get; set; } = "17:00";
    }
    public class ValidTimes
    {
        public TimeRange morning { get; set; } = new TimeRange();
        public TimeRange noon { get; set; } = new TimeRange();
        public TimeRange afternoon { get; set; } = new TimeRange();
        public TimeRange evening { get; set; } = new TimeRange();
    }
    public class TimeRange
    {
        public string start { get; set; } = "";
        public string end { get; set; } = "";
    }
    public class FileSettings
    {
        public bool auto_backup { get; set; } = true;
        public bool confirm_overwrite { get; set; } = true;
    }
    public class SystemSettings
    {
        public bool auto_update { get; set; } = true;
    }
} 