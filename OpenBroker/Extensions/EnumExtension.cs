using System.ComponentModel;
using System.Reflection;

namespace OpenBroker.Extensions;
public static class EnumExtension
{
	public static string ToDescription(this Enum source)
	{
		var info = source.GetType().GetField(source.ToString());

		if (info is null) return string.Empty;

		var attribute = info.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

		return attribute is null ? source.ToString() : attribute.Description;
	}
}
