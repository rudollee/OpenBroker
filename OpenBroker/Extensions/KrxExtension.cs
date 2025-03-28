namespace OpenBroker.Extensions;

public static class KrxExtension
{
	public static string ToKrxProductCode(this string symbol) => symbol.Length switch
	{
		> 4 => symbol.Substring(0, 3),
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

}
