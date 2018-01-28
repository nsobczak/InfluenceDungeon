using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class DGWindow : EditorWindow
{
    static DGWindow curWindow;

    GameObject lineLGO;
    GameObject lineRGO;
    GameObject lineTGO;
    GameObject lineBGO;
    GameObject ICornerTLGO;
    GameObject ICornerTRGO;
    GameObject ICornerBLGO;
    GameObject ICornerBRGO;
    GameObject OCornerTLGO;
    GameObject OCornerTRGO;
    GameObject OCornerBLGO;
    GameObject OCornerBRGO;
    GameObject FloorPlate;

    int dSize = 12;
    int roomSize = 6;
    int roomSizeDelta = 3;
    int roomsCount = 4;
    int coridorThickness = 2;
    float oneStepSize;
    string oneStepSizeStr = "5";
    bool isAllowIntersection = false;
    bool isSetIds = false;
    int coridorsCount = 1;
    float whProportion = 0f;
    DGCore dgCore;

    //static bool drawHelpers = true;

    float paramLabelWidth = 150f;
    float paramValueWidth = 30;

    Vector2 scrollPosition;


    [MenuItem("Tools/Dungeon Tools/Dungeon Creator")]
    static void Init()
    {
        curWindow = (DGWindow)EditorWindow.GetWindow(typeof(DGWindow));
        curWindow.titleContent = new GUIContent("DCreator");
        //curWindow.minSize = new Vector2(512, 560);
        //SceneView.onSceneGUIDelegate += OnScene;
    }

    void OnGUI()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        GUILayout.BeginHorizontal();
        GUILayout.Space(10);
        GUILayout.BeginVertical();
        GUILayout.Space(10);
        
        GUILayout.Label("Modular elements prefabs:", EditorStyles.boldLabel);
        lineLGO = (GameObject)EditorGUILayout.ObjectField("Wall left: ", lineLGO, typeof(GameObject), true);
        lineRGO = (GameObject)EditorGUILayout.ObjectField("Wall right: ", lineRGO, typeof(GameObject), true);
        lineTGO = (GameObject)EditorGUILayout.ObjectField("Wall top: ", lineTGO, typeof(GameObject), true);
        lineBGO = (GameObject)EditorGUILayout.ObjectField("Wall bottom: ", lineBGO, typeof(GameObject), true);
        ICornerTLGO = (GameObject)EditorGUILayout.ObjectField("Inner corner Top-Left: ", ICornerTLGO, typeof(GameObject), true);
        ICornerTRGO = (GameObject)EditorGUILayout.ObjectField("Inner corner Top-Right: ", ICornerTRGO, typeof(GameObject), true);
        ICornerBLGO = (GameObject)EditorGUILayout.ObjectField("Inner corner Bottom-Left: ", ICornerBLGO, typeof(GameObject), true);
        ICornerBRGO = (GameObject)EditorGUILayout.ObjectField("Inner corner Bottom-Right: ", ICornerBRGO, typeof(GameObject), true);
        OCornerTLGO = (GameObject)EditorGUILayout.ObjectField("Outer corner Top-Left: ", OCornerTLGO, typeof(GameObject), true);
        OCornerTRGO = (GameObject)EditorGUILayout.ObjectField("Outer corner Top-Right: ", OCornerTRGO, typeof(GameObject), true);
        OCornerBLGO = (GameObject)EditorGUILayout.ObjectField("Outer corner Bottom-Left: ", OCornerBLGO, typeof(GameObject), true);
        OCornerBRGO = (GameObject)EditorGUILayout.ObjectField("Outer corner Bottom-Right: ", OCornerBRGO, typeof(GameObject), true);
        FloorPlate = (GameObject)EditorGUILayout.ObjectField("Floor plate: ", FloorPlate, typeof(GameObject), true);


        GUILayout.BeginHorizontal();
        GUILayout.Label("Set id: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("isSetIds");
        isSetIds = GUILayout.Toggle(isSetIds, "");
        GUILayout.EndHorizontal();
        
        GUILayout.Space(10);

        GUILayout.Label("Parameters:", EditorStyles.boldLabel);


        GUILayout.BeginHorizontal();
        GUILayout.Label("One step size: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("oneStepSize");
        oneStepSizeStr = GUILayout.TextField(oneStepSizeStr, 120);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Dungeon size: ", GUILayout.Width(150f));
        GUI.SetNextControlName("dSize");
        dSize = (int)GUILayout.HorizontalSlider((float)dSize, 1, 128);
        GUILayout.Label(dSize.ToString(), GUILayout.Width(paramValueWidth));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Rooms count: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("roomsCount");
        roomsCount = (int)GUILayout.HorizontalSlider((float)roomsCount, 2, 64);
        GUILayout.Label(roomsCount.ToString(), GUILayout.Width(paramValueWidth));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Room size: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("roomSize");
        roomSize = (int)GUILayout.HorizontalSlider((float)roomSize, 1, 16);
        GUILayout.Label(roomSize.ToString(), GUILayout.Width(paramValueWidth));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Room size delta: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("roomSizeDelta");
        roomSizeDelta = (int)GUILayout.HorizontalSlider((float)roomSizeDelta, 0, 8);
        GUILayout.Label(roomSizeDelta.ToString(), GUILayout.Width(paramValueWidth));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Corridor thickness: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("coridorThickness");
        coridorThickness = (int)GUILayout.HorizontalSlider((float)coridorThickness, 1, 8);
        GUILayout.Label(coridorThickness.ToString(), GUILayout.Width(paramValueWidth));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Corridors count: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("coridorsCount");
        coridorsCount = (int)GUILayout.HorizontalSlider((float)coridorsCount, 1, 6);
        GUILayout.Label(coridorsCount.ToString(), GUILayout.Width(paramValueWidth));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Width and height proportion: ", GUILayout.Width(paramLabelWidth));
        GUI.SetNextControlName("whProportion");
        whProportion = GUILayout.HorizontalSlider((float)whProportion, -1f, 1f);
        GUILayout.Label(whProportion.ToString("0.#"), GUILayout.Width(paramValueWidth));
        GUILayout.EndHorizontal();

        
        if (GUILayout.Button("Generate dungeon", GUILayout.Height(35)))
        {
            ClickGenerate();
        }
        if (GUILayout.Button("Rebuild geometry", GUILayout.Height(25), GUILayout.Width(120)))
        {
            if (dgCore == null)
            {
                ClickGenerate();
            }
            else
            {
                try
                {
                    oneStepSize = (float)System.Convert.ToDouble(oneStepSizeStr);
                    EmitGeometry();
                }
                catch
                {
                    Debug.Log("Set correct step size.");
                }
                
            }
        }

        GUILayout.EndVertical();
        GUILayout.Space(10);
        GUILayout.EndHorizontal();

        EditorGUILayout.EndScrollView();
        Repaint();
    }

    void ClickGenerate()
    {
        try
        {
            oneStepSize = (float)System.Convert.ToDouble(oneStepSizeStr);
            if (dgCore == null)
            {
                dgCore = ScriptableObject.CreateInstance<DGCore>();
            }

            dgCore.Init(dSize, roomSize, roomSizeDelta, roomsCount, isAllowIntersection, coridorThickness, oneStepSize, whProportion, coridorsCount);
            dgCore.Generate();
            EmitGeometry();
        }
        catch
        {
            Debug.Log("Set correct step size.");
        }
        
    }

    static DGCore GetCore()
    {
        return curWindow.dgCore;
    }

    void EmitGeometry()
    {
        if(dgCore != null && dgCore.isCorrect())
        {
            oneStepSize = (float)System.Convert.ToDouble(oneStepSizeStr);
            dgCore.EmitGeometry(lineLGO, lineRGO, lineTGO, lineBGO, ICornerTLGO, ICornerTRGO, ICornerBLGO, ICornerBRGO, OCornerTLGO, OCornerTRGO, OCornerBLGO, OCornerBRGO, FloorPlate, oneStepSize, isSetIds);
        }
        else
        {
            Debug.Log("Nothing to build. Generate the scheme at first.");
        }
        
    }
}
