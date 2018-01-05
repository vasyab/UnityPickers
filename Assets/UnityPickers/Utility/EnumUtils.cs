using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityPickers.Utility
{
	public static class EnumUtils
	{
		public static IEnumerable<TEnum> GetValues<TEnum>()
		{
			return typeof(TEnum).IsEnum
				? Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
				: Enumerable.Empty<TEnum>();
		}

		public static IEnumerable<Enum> GetValues(Type enumType)

		{
			return enumType.IsEnum
				? Enum.GetValues(enumType).Cast<Enum>()
				: Enumerable.Empty<Enum>();
		}

		public static int GetMaxValue<TEnum>()
		{
			return Enum.GetValues(typeof(TEnum)).Cast<int>().Max() + 1;
		}
	}
}