using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBroker.Extensions;
public static class CmeService
{
	public enum SymbolOfMonth
	{
		F = 1, G, H,

		J, K, M,

		N, Q, U,

		V, X, Z
	}

	public static int GetTheDayOnMonth(DateTime date, int orderOfWeek, DayOfWeek doyOfWeekPicked)
	{
		var firstOfMonth = date.AddDays(-date.Day + 1);
		var needsToSubtract = (int)doyOfWeekPicked > (int)firstOfMonth.DayOfWeek;

		return 7 * (orderOfWeek - (needsToSubtract ? 1 : 0)) - (int)firstOfMonth.DayOfWeek + (int)doyOfWeekPicked + 1;
	}

	public static bool IsBelongToDST(DateTime date)
	{
		if (date.Month > 4 && date.Month < 11)
		{
			return true;
		}
		else if (date.Month == 3 && date.Day >= GetTheDayOnMonth(date, 2, DayOfWeek.Sunday))
		{
			return true;
		}
		else if (date.Month == 11 && date.Day < GetTheDayOnMonth(date, 1, DayOfWeek.Sunday))
		{
			return true;
		}

		return false;
	}

	public static DateTime ToNewYorkTime(this DateTime date, int timezone = 9)
	{
		int hourForward = IsBelongToDST(date) ? timezone -3 : timezone - 4;

		return date.Hour > hourForward ? date : date.AddHours(-date.Hour - 1);
	}

	public static string ToFiscalMonth(this DateTime date)
	{
		return $"{date.Year - 2000}{(SymbolOfMonth)date.Month}";
	}

	public static DateTime ConvertFiscalMonthToDate(string fiscalMonth)
	{
		var month = (int)(SymbolOfMonth)Enum.Parse(typeof(SymbolOfMonth), fiscalMonth.Substring(2, 1));

		return DateTime.Parse($"{2000 + Convert.ToInt32(fiscalMonth.Substring(0, 2))}-{month}-02");
	}
}
