using System.Globalization;

namespace CsgoMatchData.Parser.Helpers;

public static class TimeExtractor
{
    public static DateTime ParseTimestampFromActionLog(string actionLog)
    {
        var dateString = actionLog[..10];
        var timeString = actionLog.Substring(13, 8);
        var dateTime = DateTime.ParseExact($"{dateString} {timeString}", "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        return dateTime;
    }
}