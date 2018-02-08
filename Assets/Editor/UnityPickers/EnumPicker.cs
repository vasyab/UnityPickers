using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace UnityPickers
{
	public class EnumPicker : ValuePicker<Enum>
	{
		public static void Button(
			[NotNull] string buttonText,
			[NotNull] Func<IEnumerable<Enum>> valuesCollector,
			[NotNull] Action<Enum> callback,
			bool showNow = false,
			[CanBeNull] GUIStyle style = null,
			[NotNull] params GUILayoutOption[] options)
		{
			Button(
				GetWindow<EnumPicker>,
				buttonText,
				valuesCollector,
				callback,
				showNow,
				style,
				options
			);
		}

		public static void Button(
			Rect rect,
			[NotNull] string buttonText,
			[NotNull] Func<IEnumerable<Enum>> valuesCollector,
			[NotNull] Action<Enum> callback,
			bool showNow = false,
			[CanBeNull] GUIStyle style = null)
		{
			Button(
				GetWindow<EnumPicker>,
				rect,
				buttonText,
				valuesCollector,
				callback,
				showNow,
				style
			);
		}
	}
}