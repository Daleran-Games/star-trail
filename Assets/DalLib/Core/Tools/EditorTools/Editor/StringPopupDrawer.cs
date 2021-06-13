using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DaleranGames
{
    [CustomPropertyDrawer(typeof(StringPopupAttribute))]
    public class StringPopupDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            if (property.propertyType == SerializedPropertyType.String)
            {
                string value = property.stringValue;
                StringPopupAttribute attr = attribute as StringPopupAttribute;
                string[] options = attr.options;

                int index = System.Array.IndexOf(options, value);

                EditorGUI.BeginChangeCheck();

                if (index > -1)
                    index = EditorGUI.Popup(position,label.text, index, options);
                else
                    index = EditorGUI.Popup(position, 0, options);

                if (EditorGUI.EndChangeCheck())
                {
                    property.stringValue = options[index];
                }
            }
            else
            {
                EditorGUI.LabelField(position, label, "Use only with String");
            }

        }
    }
}


