using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace UnityPickers
{
	public class StringPicker : ValuePicker<string>
	{
		public static void Button(
			[NotNull] string buttonText,
			[NotNull] Func<IEnumerable<string>> valuesCollector,
			[NotNull] Action<string> callback,
			bool showNow = false,
			[CanBeNull] GUIStyle style = null,
			[NotNull] params GUILayoutOption[] options)
		{
			Button(
				GetWindow<StringPicker>,
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
			[NotNull] Func<IEnumerable<string>> valuesCollector,
			[NotNull] Action<string> callback,
			bool showNow = false,
			[CanBeNull] GUIStyle style = null)
		{
			Button(
				GetWindow<StringPicker>,
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