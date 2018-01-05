using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityPickers.Utility;

namespace Editor.UnityPickers
{
	[CustomPropertyDrawer(typeof(Enum), true)]
	public class EnumPickerDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			Rect fieldRect;
			if (!string.IsNullOrEmpty(label.text))
			{
				var labelRect = new Rect(
					position.x,
					position.y,
					EditorGUIUtility.labelWidth,
					position.height
				);
				fieldRect = new Rect(
					position.x + EditorGUIUtility.labelWidth,
					position.y,
					position.width - EditorGUIUtility.labelWidth,
					position.height
				);
				EditorGUI.LabelField(labelRect, label);
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
				style: EditorStyles.popup
			);
		}
	}
}