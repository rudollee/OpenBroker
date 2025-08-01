namespace OpenBroker.Extensions;

public static class DateExtension
{
    private static readonly string _date8Txt = "yyyyMMdd";
	private static readonly string _dateTimeTxt863 = "yyyyMMddHHmmssfff";
	private static readonly string _dateTimeTxt866 = "yyyyMMddHHmmssffffff";

    /// <summary>
    /// convert to today to krx trading day
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateOnly ToKrxTradingDay(this DateTime dateTime) => 
        DateOnly.FromDateTime(dateTime.AddDays(dateTime.DayOfWeek switch
		{
			DayOfWeek.Saturday => -1,
			DayOfWeek.Sunday => -2,
			DayOfWeek.Monday => dateTime.Hour < 16 ? -3 : 0,
			_ => dateTime.Hour < 9 ? -1 : 0
		}));

	/// <summary>
	/// Convert dateString to Date
	/// </summary>
	/// <param name="dateTxt8">8-digit dateString</param>
	/// <returns></returns>
	public static DateOnly ToDate(this string dateTxt8)
    {
        int year = Convert.ToInt32(dateTxt8[..4]);
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
    /// <param name="datetimeTxt86"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this string datetimeTxt86)
    {
        if (datetimeTxt86.Length == 6) datetimeTxt86 = DateTime.Now.ToKrxTradingDay().ToDate8Txt() + datetimeTxt86;
        else if (datetimeTxt86.Length == 8) datetimeTxt86 = datetimeTxt86.PadRight(14, '0');

        if (datetimeTxt86.Length != 14) return DateTime.Now;

        int year = Convert.ToInt32(datetimeTxt86.Substring(0, 4));
        int month = Convert.ToInt32(datetimeTxt86.Substring(4, 2));
        int day = Convert.ToInt32(datetimeTxt86.Substring(6, 2));

        if (datetimeTxt86.Length < 14) return new DateTime(year, month, day);

        var hour = Convert.ToInt32(datetimeTxt86.Substring(8, 2));
        var minute = Convert.ToInt32(datetimeTxt86.Substring(10, 2));
        var second = Convert.ToInt32(datetimeTxt86.Substring(12, 2));

        return new DateTime(year, month, day).Add(new TimeSpan(hour, minute, second));
    }

    /// <summary>
    /// convert string to DateTime with Milliseconds
    /// </summary>
    /// <param name="datetimeTxt863"></param>
    /// <returns></returns>
    public static DateTime ToDateTimeM(this string datetimeTxt863)
    {
        if (datetimeTxt863.Length < 9) datetimeTxt863 = DateTime.Now.ToKrxTradingDay().ToDate8Txt() + datetimeTxt863.PadRight(9, '0');
        if (datetimeTxt863.Length != 17) return DateTime.Now;

        return DateTime.ParseExact(datetimeTxt863[..17], _dateTimeTxt863, null);
	}

    public static DateTime ToDateTimeMicro(this string datetimeTxt866) =>
        DateTime.ParseExact(datetimeTxt866[..20], _dateTimeTxt866, null);

	public static int ToOrdinalDay(this DateOnly date, DayOfWeek dayOfWeek, int order)
	{
		var firstDay = date.AddDays(-date.Day + 1);
		var formulaToAdd = (int)dayOfWeek - (int)firstDay.DayOfWeek + 7 * (order - ((int)firstDay.DayOfWeek > (int)dayOfWeek ? 0 : 1));
		var d = firstDay.AddDays(formulaToAdd);
		return d.Month == date.Month ? d.Day : 0;
	}

	public static DateOnly ToOrdinalDate(this DateOnly date, DayOfWeek dayOfWeek, int order)
    {
        int day = date.ToOrdinalDay(dayOfWeek, order);
        return DateOnly.Parse($"{date.Year}-{date.Month}-{day}");
	}

    public static string ToDate8Txt(this DateOnly date) => date.ToString(_date8Txt);

    public static string ToDate8Txt(this DateTime date) => date.ToString(_date8Txt);
}
