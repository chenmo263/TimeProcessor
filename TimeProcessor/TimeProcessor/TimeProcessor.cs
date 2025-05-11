using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TimeProcessor
{
    public class TimeProcessor
    {
        // 拆分时间字符串，返回所有HH:mm格式的时间
        public static List<string> SplitAndCleanTimes(string input)
        {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(input)) return result;
            // 匹配所有形如 07:59 的时间
            var matches = System.Text.RegularExpressions.Regex.Matches(input, @"\d{2}:\d{2}");
            foreach (System.Text.RegularExpressions.Match m in matches)
            {
                result.Add(m.Value);
            }
            return result;
        }

        // 分类时间到四个时间点
        public static Dictionary<string, string> CategorizeTimes(List<string> times)
        {
            // 早上上班(8:00前), 中午下班(8:00-12:30), 下午上班(12:30-15:00), 晚上下班(15:00后)
            string morningIn = "", noonOut = "", afternoonIn = "", eveningOut = "";
            var timeMinutes = times.Select(t => (t, ToMinutes(t))).ToList();
            // 早上上班
            var morning = timeMinutes.Where(x => x.Item2 < 12 * 60).ToList();
            if (morning.Any()) morningIn = morning.MinBy(x => x.Item2).t;
            // 中午下班
            var noon = timeMinutes.Where(x => x.Item2 < 12 * 60 + 30).ToList();
            if (noon.Any()) noonOut = noon.MaxBy(x => x.Item2).t;
            // 下午上班
            var afternoon = timeMinutes.Where(x => x.Item2 >= 12 * 60 + 30 && x.Item2 < 15 * 60).ToList();
            if (afternoon.Any()) afternoonIn = afternoon.MinBy(x => x.Item2).t;
            // 晚上下班
            var evening = timeMinutes.Where(x => x.Item2 >= 15 * 60).ToList();
            if (evening.Any()) eveningOut = evening.MaxBy(x => x.Item2).t;
            return new Dictionary<string, string>
            {
                {"早上上班时间", morningIn},
                {"中午下班时间", noonOut},
                {"下午上班时间", afternoonIn},
                {"晚上下班时间", eveningOut}
            };
        }

        // 计算工作时长（小时，按规则四舍五入）
        public static double CalculateWorkHours(Dictionary<string, string> timesDict, Dictionary<string, string> workTimes)
        {
            int? morningIn = ToMinutes(timesDict.GetValueOrDefault("早上上班时间"));
            int? noonOut = ToMinutes(timesDict.GetValueOrDefault("中午下班时间"));
            int? afternoonIn = ToMinutes(timesDict.GetValueOrDefault("下午上班时间"));
            int? eveningOut = ToMinutes(timesDict.GetValueOrDefault("晚上下班时间"));
            int total = 0;
            // 上午
            if (morningIn.HasValue && noonOut.HasValue)
            {
                int start = Math.Max(morningIn.Value, ToMinutes(workTimes["morning_start"]).Value);
                int end = Math.Min(noonOut.Value, ToMinutes(workTimes["noon_end"]).Value);
                if (end > start) total += end - start;
            }
            // 下午
            if (afternoonIn.HasValue && eveningOut.HasValue)
            {
                int start = Math.Max(afternoonIn.Value, ToMinutes(workTimes["afternoon_start"]).Value);
                int end = Math.Min(eveningOut.Value, ToMinutes(workTimes["evening_end"]).Value);
                if (end > start) total += end - start;
            }
            // 转小时，按规则四舍五入
            double hours = total / 60.0;
            double d = hours - Math.Floor(hours);
            if (d < 0.4) return Math.Floor(hours);
            if (d <= 0.6) return Math.Floor(hours) + 0.5;
            return Math.Ceiling(hours);
        }

        // 工具：时间字符串转分钟
        private static int? ToMinutes(string t)
        {
            if (string.IsNullOrWhiteSpace(t)) return null;
            if (TimeSpan.TryParse(t, out var ts))
                return ts.Hours * 60 + ts.Minutes;
            return null;
        }
    }
} 