using System.Globalization;

namespace Mehr.SharedKernel.Dates;

public static class DateConvetor
{
    private static readonly PersianCalendar pc = new PersianCalendar();
    public static string PersianDate(this DateTime gregorianDate)
    {

        int year = pc.GetYear(gregorianDate);
        int month = pc.GetMonth(gregorianDate);
        int day = pc.GetDayOfMonth(gregorianDate);

        return $"{year}/{month.ToString("00")}/{day.ToString("00")}";
    }

    public static DateTime GregorianDateTime(this string persianDate)
    {
        var now = DateTime.Now;

        string[] parts = persianDate.Split('/');
        int year = int.Parse(parts[0]);
        int month = int.Parse(parts[1]);
        int day = int.Parse(parts[2]);

        var gregorianDate = pc.ToDateTime(year, month, day, now.Hour, now.Minute, now.Second, now.Millisecond);

        return gregorianDate;
    }
}
