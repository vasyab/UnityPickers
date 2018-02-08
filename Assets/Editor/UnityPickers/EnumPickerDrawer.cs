using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityPickers.Utility;

namespace UnityPickers
{
	[CustomPropertyDrawer(typeof(Enum), true)]
	public class EnumPickerDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			string controlId = "enum:" + property.propertyPath;

			Rect fieldRect;
			if (!string.IsNullOrEmpty(label.text))
			{
				fieldRect = new Rect(
					position.x + EditorGUIUtility.labelWidth,
					position.y,
					position.width - EditorGUIUtility.labelWidth,
					position.height
				);
			}
			else
			{
				fieldRect = position;
			}

			var type = fieldInfo.FieldType;
			if (type.IsArray)
			{
				type = type.GetElementType();
			}

			var valuesArray = EnumUtils.GetValues(type).ToArray();

			// if you need to change values display order for some types this is the right place
			var displayOrder = EnumUtils.GetValues(type);

			string currentName;
			if (property.enumValueIndex >= 0 && property.enumValueIndex < valuesArray.Length)
			{
				currentName = valuesArray[property.enumValueIndex].ToString();
			}
			else
			{
				currentName = "[Unknown]";
			}

			var evt = Event.current;
			bool showHotKey =
				GUI.GetNameOfFocusedControl() == controlId &&
				evt.type == EventType.KeyDown &&
				evt.keyCode == KeyCode.Return;

			var p = property.Copy();
			EnumPicker.Button(
				fieldRect,
				currentName,
				() => displayOrder,
				e =>
				{
					p.serializedObject.Update();
					p.enumValueIndex = Array.IndexOf(valuesArray, e);
					p.serializedObject.ApplyModifiedProperties();
				},
				showHotKey,
				EditorStyles.popup
			);

			if (showHotKey)
			{
				evt.Use();
			}

			// draw label and focusable control
			GUI.SetNextControlName(controlId);
			EditorGUI.Popup(position, label, 0, new[] { new GUIContent(currentName) });
		}
	}
}