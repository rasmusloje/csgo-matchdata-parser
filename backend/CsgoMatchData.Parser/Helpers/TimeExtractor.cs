using System.Globalization;

namespace CsgoMatchData.Parser.Helpers;

internal static class TimeExtractor
{
    internal static DateTime ParseTimestampFromActionText(string actionText)
    {
        var dateString = actionText[..10];
        var timeString = actionText.Substring(13, 8);
        var dateTime = DateTime.ParseExact(
            $"{dateString} {timeString}",
            "MM/dd/yyyy HH:mm:ss",
            CultureInfo.InvariantCulture
        );

        return dateTime;
    }
}
