using System;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.UnityPickers
{
	public class StringPicker : ValuePicker<string>
	{
		public static void Button(
			string buttonText,
			Func<IEnumerable<string>> valuesCollector,
			Action<string> callback,
			bool showNow = false,
			params GUILayoutOption[] options)
		{
			Button(
				GetWindow<StringPicker>,
				buttonText,
				valuesCollector,
				callback,
				showNow,
				options
			);
		}

		public static void Button(
			Rect rect,
			string buttonText,
			Func<IEnumerable<string>> valuesCollector,
			Action<string> callback,
			bool showNow = false,
			GUIStyle style = null)
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