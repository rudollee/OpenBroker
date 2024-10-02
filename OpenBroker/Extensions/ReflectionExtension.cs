namespace OpenBroker.Extensions;
public static class ReflectionExtension
{
	public static object? GetPropValue(this object? obj, string name)
	{
		if (obj is null) return null;

		foreach (var part in name.Split('.'))
		{
			var info = obj?.GetType().GetProperty(part);
			if (info is null) return null;
			
			obj = info.GetValue(obj, null);
		}

		return obj;
	}

	public static T? GetPropValue<T>(this object obj, string name)
	{
		var retval = GetPropValue(obj, name);
		if (retval is null) { return default(T?); }

		return (T)retval;
	}
}
