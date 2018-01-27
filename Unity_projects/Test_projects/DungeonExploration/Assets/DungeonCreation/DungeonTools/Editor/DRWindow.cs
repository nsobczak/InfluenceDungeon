using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class DRWindow : EditorWindow
{
    static DRWindow curWindow;

    float paramLabelWidth = 150f;
    float paramValueWidth = 25;

    int prefabsCount = 13;

    Dictionary<int, GameObject> targetPrefabs = new Dictionary<int,GameObject>();
    Dictionary<int, float> rotations = new Dictionary<int,float>();
    Dictionary<int, string> rotationsStr = new Dictionary<int,string>();
    Vector2 scrollPosition;


    [MenuItem("Tools/Dungeon Tools/Dungeon Replacer")]
    static void Init()
    {
        curWindow = (DRWindow)EditorWindow.GetWindow(typeof(DRWindow));
        curWindow.titleContent = new GUIContent("DReplacer");
    }

    void OnGUI()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        GUILayout.BeginHorizontal();
        GUILayout.Space(10);
        GUILayout.BeginVertical();
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Prefabs count: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("prefabsCount");
        prefabsCount = (int)GUILayout.HorizontalSlider((float)prefabsCount, 0, 64);
        GUILayout.Label(prefabsCount.ToString(), GUILayout.Width(paramValueWidth));
        GUILayout.EndHorizontal();


        GUILayout.Label("Prefabs for replace process:", EditorStyles.boldLabel);
        
        for (int i = 0; i < prefabsCount; i++ )
        {
            if(!targetPrefabs.ContainsKey(i))
            {
                targetPrefabs.Add(i, null);
            }
            if(!rotations.ContainsKey(i))
            {
                rotations.Add(i, 0.0f);
            }
            if(!rotationsStr.ContainsKey(i))
            {
                rotationsStr.Add(i, "0");
            }

            targetPrefabs[i] = (GameObject)EditorGUILayout.ObjectField("Prefab for Id=" + i.ToString(), targetPrefabs[i], typeof(GameObject), true);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Rotation: ", GUILayout.Width(paramLabelWidth));
            rotationsStr[i] = GUILayout.TextField(rotationsStr[i], 120);
            GUILayout.EndHorizontal();
            GUILayout.Space(10);
        }

        if (GUILayout.Button("Replace", GUILayout.Height(35)))
        {
            ClickReplace();
        }

        GUILayout.EndVertical();
        GUILayout.Space(10);
        GUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
        Repaint();
    }

    void ClickReplace()
    {
        DRCore drCore = ScriptableObject.CreateInstance<DRCore>();
        //распознаем углы для поворота
        foreach(int i in rotationsStr.Keys)
        {
            try
            {
                rotations[i] = (float)System.Convert.ToDouble(rotationsStr[i]);
            }
            catch
            {

            }
        }

        drCore.ReplacementProcess(Selection.objects, targetPrefabs, rotations, prefabsCount);
    }

}
