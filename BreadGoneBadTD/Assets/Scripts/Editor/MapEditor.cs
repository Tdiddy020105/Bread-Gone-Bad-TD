using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Map))]
public class MapEditor : Editor
{

    #region SerializedProperties

    SerializedProperty width;
    SerializedProperty height;

    SerializedProperty placeholderTile;
    SerializedProperty grassTile;
    SerializedProperty gravelTile;

    #endregion

    private void OnEnable()
    {
        width = serializedObject.FindProperty("width");
        height = serializedObject.FindProperty("height");

        placeholderTile = serializedObject.FindProperty("placeholderTile");
        grassTile = serializedObject.FindProperty("grassTile");
        gravelTile = serializedObject.FindProperty("gravelTile");
    }

    public override void OnInspectorGUI()
    {
        Map myMap = (Map)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(width);
        EditorGUILayout.PropertyField(height);

        //This button generates a grid with the given 'width' and 'height' parameters if there are no object with type 'Tile' in the scene.
        if (GUILayout.Button("Generate Grid"))
        {
            if (GameObject.FindGameObjectsWithTag("Tile").Length == 0)
            {
                myMap.GenerateGrid();
            }
        }

        //This button immediately destroys ALL objects with a 'Tile' tag.
        if (GUILayout.Button("Destroy All Tiles"))
        {
            myMap.DestroyGrid();
        }

        EditorGUILayout.Space(5);

        EditorGUILayout.PropertyField(placeholderTile);
        EditorGUILayout.PropertyField(grassTile);
        EditorGUILayout.PropertyField(gravelTile);

        //While this button is selected you can change any clicked tile to a GrassTile.
        if (GUILayout.Button("Select Grass Tiles"))
        {
            //Implement GrassTile Converter here.
            throw new NotImplementedException();
        }

        ////While this button is selected you can change any clicked tile to a GravelTile.
        if (GUILayout.Button("Select Gravel Tiles"))
        {
            //Implement GravelTile Converter here.
            throw new NotImplementedException();
        }

        serializedObject.ApplyModifiedProperties();
    }
}