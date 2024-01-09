namespace OpenBroker.Extensions;

public static class DateExtension
{
    /// <summary>
    /// Convert dateString to Date
    /// </summary>
    /// <param name="dateTxt8">8-digit dateString</param>
    /// <returns></returns>
    public static DateOnly ToDate(this string dateTxt8)
    {
        int year = Convert.ToInt32(dateTxt8.Substring(0, 4));
        int month = Convert.ToInt32(dateTxt8.Substring(4, 2));
        int day = Convert.ToInt32(dateTxt8.Substring(6, 2));

        return new DateOnly(year, month, day);
    }

    /// <summary>
    /// Convert timeString to time
    /// </summary>
    /// <param name="timeTxt">6-digit of time format string: e.g.. 15:10:11</param>
    /// <returns></returns>
    public static TimeOnly ToTime(this string timeTxt)
    {
        var hour = Convert.ToInt32(timeTxt.Substring(0, 2));
        var minute = Convert.ToInt32(timeTxt.Substring(2, 2));
        var second = Convert.ToInt32(timeTxt.Substring(4, 2));

        return new TimeOnly(hour, minute, second);
    }

    /// <summary>
    /// convert 8-digit dateString & 6-digit timeString to DateTime
    /// </summary>
    /// <param name="dateTxt8"></param>
    /// <param name="timeTxt"></param>
    /// <returns></returns>
    public static DateTime ToDate(this string dateTxt8, string timeTxt) =>
        dateTxt8.ToDate().ToDateTime(timeTxt.ToTime());

    /// <summary>
    /// convert datetimeString to DateTime
    /// </summary>
    /// <param name="datetimeTxt14"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this string datetimeTxt14)
    {
        int year = Convert.ToInt32(datetimeTxt14.Substring(0, 4));
        int month = Convert.ToInt32(datetimeTxt14.Substring(4, 2));
        int day = Convert.ToInt32(datetimeTxt14.Substring(6, 2));

        var hour = Convert.ToInt32(datetimeTxt14.Substring(8, 2));
        var minute = Convert.ToInt32(datetimeTxt14.Substring(10, 2));
        var second = Convert.ToInt32(datetimeTxt14.Substring(12, 2));

        return new DateTime(year, month, day).Add(new TimeSpan(hour, minute, second));
    }
}
