namespace OpenBroker.Extensions;

public static class DecimalExtension
{
	/// <summary>
	/// Scales the decimal value to the specified scale, rounding if necessary.
	/// </summary>
	/// <param name="value">The decimal value to scale.</param>
	/// <param name="scale">The number of decimal places in the return value, from 0 to 28.</param>
	/// <returns></returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public static decimal ScaleTo(this decimal value, int scale)
	{
		if (scale is < 0 or > 28) throw new ArgumentOutOfRangeException(nameof(scale), "The scale must be between 0 and 28, inclusive.");

		decimal rounded = Math.Round(value, scale, MidpointRounding.AwayFromZero);

		int[] bits = decimal.GetBits(rounded);

		bool isNegative = (bits[3] & int.MinValue) != 0;

		return new decimal(bits[0], bits[1], bits[2], isNegative, (byte)scale);
	}
}
