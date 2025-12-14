using OpenBroker.Models;

namespace OpenBroker.Extensions;

public static class KrxExtension
{
	public static string ToKrxInstrumentCode(this string symbol) => symbol.Length switch
	{
		> 4 => symbol.Substring(1, 2),
		_ => string.Empty,
	};
	
	public static decimal ToUpTick(this decimal price)
		=> price switch
		{
			< 2000 => 1,
			< 5000 => 5,
			< 20000 => 10,
			< 50000 => 50,
			< 200000 => 100,
			< 500000 => 500,
			_ => 1000,
		};

	public static decimal ToDownTick(this decimal price)
		=> price switch
		{
			> 500000 => 1000,
			> 200000 => 500,
			> 50000 => 100,
			> 20000 => 50,
			> 5000 => 10,
			> 2000 => 5,
			_ => 1,
		};

	public static decimal ToUpTickPrice(this decimal price, bool needsOnlyNormalizing = false)
	{
		var uptick = price.ToUpTick();
		var di = 1 / uptick;
		decimal normalizedPrice = Math.Ceiling(price * di) / di;

		return normalizedPrice + (needsOnlyNormalizing ? 0 : uptick);
	}

	public static decimal ToDownTickPrice(this decimal price, bool needsOnlyNormalizing = false)
	{
		var downtick = price.ToDownTick();
		var di = 1 / downtick;
		decimal normalizedPrice = Math.Floor(price * di) / di;

		return normalizedPrice - (needsOnlyNormalizing ? 0 : downtick);
	}

	public static DateOnly ToKrxExpiry(this DateOnly date, bool quarterly = false)
	{
		var monthAdding = quarterly && date.Month % 3 > 0 ? -(date.Month % 3) : 0;
		var dateFin = date.AddMonths(monthAdding).ToOrdinalDate(DayOfWeek.Thursday, 2);
		return dateFin.AddMonths(date > dateFin ? (quarterly ? 3 : 1) : 0);
	}

	public static DateOnly ToKrxExpiry(this DateOnly date, string instrumentCode)
	{
		if (instrumentCode != "75") return date.ToKrxExpiry();

		var dateFin = date.ToOrdinalDate(DayOfWeek.Monday, 3);
		return dateFin.AddMonths(date > dateFin ? 1 : 0);
	}

	public static DateOnly ToKrxExpiry(this string expiryCode, int cycle = 0)
	{
		int getYear(string yearString)
		{
			char y = Convert.ToChar(yearString);
			if (y > 'W') return 1996 - cycle * 30;
			if (y < '0') return 1996 + cycle * 30;
			
			int seq = y switch
			{
				> 'U' => y - 58,
				> 'O' => y - 57,
				> 'I' => y - 56,
				>= 'A' => y - 55,
				> '5' => y - 54,
				> '0' => y - 44,
				'0' => 4,
				_ => 0
			};

			return 1996 + seq - cycle * 30; ;
		}

		int month = expiryCode[1..] switch
		{
			"A" => 10,
			"B" => 11,
			"C" => 12,
			_ => int.Parse(expiryCode[1..])
		};

		return DateOnly.ParseExact($"{getYear(expiryCode[..1])}{month.ToString().PadLeft(2, '0')}01", "yyyyMMdd");
	}

	public static string ToKrxExpiryCode(this DateOnly date, bool quarterly = false)
	{
		int minValue = new DateOnly(1995, 12, 14).DayNumber;
		int maxValue = new DateOnly(2025, 12, 11).DayNumber;
		int cycle = date.DayNumber <= minValue ? -1 : date.DayNumber > maxValue ? 1 : 0;

		var expiry = date.ToKrxExpiry(quarterly);
		var monthCode = expiry.Month.ToString().Replace("10", "A").Replace("11", "B").Replace("12", "C");
		return $"{expiry.Year.ToKrxYearCode(cycle)}{monthCode}";
	}

	public static string ToKrxExpiryCode(this DateTime dateTime, bool quarterly = false) =>
		DateOnly.FromDateTime(dateTime).ToKrxExpiryCode(quarterly);

	public static string ToKrxExpiryCode(this DateOnly date, string instrumentCode)
	{
		if (instrumentCode != "75") return date.ToKrxExpiryCode();

		int minValue = new DateOnly(1995, 12, 18).DayNumber;
		int maxValue = new DateOnly(2025, 12, 15).DayNumber;
		int cycle = date.DayNumber <= minValue ? -1 : date.DayNumber > maxValue ? 1 : 0;

		var expiry = date.ToKrxExpiry(instrumentCode);
		var monthCode = expiry.Month.ToString().Replace("10", "A").Replace("11", "B").Replace("12", "C");
		return $"{expiry.Year.ToKrxYearCode(cycle)}{monthCode}";
	}

	public static string ToKrxExpiryCode(this DateTime dateTime, string instrumentCode) =>
		DateOnly.FromDateTime(dateTime).ToKrxExpiryCode(instrumentCode);

	public static string ToKrxYearCode(this int year, int cycle)
	{
		int seq = ((year - 1996 - cycle * 30) % 30);

		char c = seq switch
		{
			< 4 => (char)(seq + 54),
			< 10 => (char)(seq + 44),
			< 18 => (char)(seq + 55),
			< 23 => (char)(seq + 56),
			< 28 => (char)(seq + 57),
			< 30 => (char)(seq + 58),
			_ => '?'
		};

		return c.ToString();
	}

	public static InstrumentType ToKrxInstrumentTypeCode(this string symbol) =>
		symbol[..1] switch
		{
			"A"  => InstrumentType.Futures,
			"B" => InstrumentType.Call,
			"C" => InstrumentType.Put,
			"D" => InstrumentType.FuturesSpread,
			"1" => InstrumentType.Futures,
			"2" => InstrumentType.Call,
			"3" => InstrumentType.Put,
			"4" => InstrumentType.FuturesSpread,
			_ => InstrumentType.Spot,
		};

	public static string ToKrxInstrumentTypeCode(this DateOnly date, string instrumentCode = "01", InstrumentType typ = InstrumentType.Futures)
	{
		var maxDay = instrumentCode.Equals("01") ? 11 : 15;
		int maxValue = new DateOnly(2025, 12, maxDay).DayNumber;
		int cycle = date.DayNumber > maxValue ? 1 : 0;
		return typ switch
		{
			InstrumentType.Futures => cycle == 1 ? "A" : "1",
			InstrumentType.Call => cycle == 1 ? "B" : "2",
			InstrumentType.Put => cycle == 1 ? "C" : "3",
			InstrumentType.FuturesSpread => cycle == 1 ? "D" : "4",
			_ => string.Empty
		};
	}

	public static decimal ToKrxMultiple(this string symbol) => symbol.ToKrxInstrumentCode() switch
	{
		"01" => 250_000,
		"05" => 50_000,
		"06" => 10_000,
		"08" => 50_000,
		"09" => 250_000,
		"AF" => 250_000,
		"65" => 1_000_000,
		"66" => 1_000_000,
		"67" => 1_000_000,
		"70" => 1_000_000,
		"75" => 10_000,
		"76" => 1_000_000,
		"77" => 10_000,
		"78" => 10_0000,
		_ => 10
	};
}
