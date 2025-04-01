namespace OpenBroker.Extensions;

public static class KrxExtension
{
	public static string ToKrxProductCode(this string symbol) => symbol.Length switch
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

		return normalizedPrice += needsOnlyNormalizing ? 0 : uptick;
	}

	public static decimal ToDownTickPrice(this decimal price, bool needsOnlyNormalizing = false)
	{
		var downtick = price.ToDownTick();
		var di = 1 / downtick;
		decimal normalizedPrice = Math.Floor(price * di) / di;

		return normalizedPrice -= needsOnlyNormalizing ? 0 : downtick;
	}

	public static DateOnly ToKrxExpiry(this DateOnly date, bool quarterly = false)
	{
		var monthAdding = quarterly && date.Month % 3 > 0 ? -(date.Month % 3) : 0;
		var dateFin = date.AddMonths(monthAdding).ToOrdinalDate(DayOfWeek.Thursday, 2);
		return dateFin.AddMonths(date > dateFin ? (quarterly ? 3 : 1) : 0);
	}

	public static string ToKrxExpiryCode(this DateOnly date, bool quarterly = false)
	{
		string getYearCode(int year)
		{
			int seq = ((year - 1996) % 30);

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

		var expiry = date.ToKrxExpiry(quarterly);
		var monthCode = expiry.Month.ToString().Replace("10", "A").Replace("11", "B").Replace("12", "C");
		return $"{getYearCode(expiry.Year)}{monthCode}";
	}
}
