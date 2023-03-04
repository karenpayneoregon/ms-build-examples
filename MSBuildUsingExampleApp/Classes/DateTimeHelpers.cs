using static System.Globalization.DateTimeFormatInfo;

namespace MSBuildUsingExampleApp.Classes;
internal class DateTimeHelpers
{
    public static List<string> MonthNames()
        => CurrentInfo!.MonthNames[..^1].ToList();
}
