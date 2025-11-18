using System.Globalization;

namespace Mehr.SharedKernel.Dates;

public static class DateConvetor
{
    public static string PersianDate(this DateTime gregorianDate)
    {
        var pc = new PersianCalendar();

        int year = pc.GetYear(gregorianDate);
        int month = pc.GetMonth(gregorianDate);
        int day = pc.GetDayOfMonth(gregorianDate);

        return $"{year}/{month.ToString("00")}/{day.ToString("00")}";
    }
}
