using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Map))]
public class MapEditor : Editor
{

    #region SerializedProperties

    SerializedProperty width;
    SerializedProperty height;

    #endregion

    private void OnEnable()
    {
        width = serializedObject.FindProperty("width");
        height = serializedObject.FindProperty("height");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(width);
        EditorGUILayout.PropertyField(height);

        serializedObject.ApplyModifiedProperties();

        //Map myMap = (Map)target;

        //myMap.width = EditorGUILayout.IntField("Width", myMap.width);
        //myMap.height = EditorGUILayout.IntField("Height", myMap.height);
    }
}