using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(DRId))]
[CanEditMultipleObjects]
public class DRCustomEditor : Editor 
{
    SerializedProperty idProperty;


    void OnEnable()
    {
        idProperty = serializedObject.FindProperty("id");
        SetColor();
	}
	
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        idProperty.intValue = EditorGUILayout.IntField("id", idProperty.intValue);

        //Debug.Log("Value changed to " + idProperty.intValue.ToString());

        SetColor();
        serializedObject.ApplyModifiedProperties();

        
	}

    void SetColor()
    {
        DRId drIdObject = (DRId)target;
        if (idProperty.intValue <= -1)
        {
            drIdObject.gameObject.GetComponent<Renderer>().sharedMaterial.color = new Color(227f / 255f, 227f / 255f, 227f / 255f);
        }
        else
        {
            drIdObject.gameObject.GetComponent<Renderer>().sharedMaterial.color = HSVToRGB(GetSin(idProperty.intValue, 0f), 0.5f, 0.8f);
        }
    }

    public static float GetSin(int x, float shift)
    {
        return Mathf.Abs(Mathf.Sin((x + shift) * x));
    }

    public static Color HSVToRGB(float H, float S, float V)
    {
     if (S == 0f)
         return new Color(V,V,V);
     else if (V == 0f)
         return new Color(0, 0, 0);
     else
     {
         Color col = Color.black;
         float Hval = H * 6f;
         int sel = Mathf.FloorToInt(Hval);
         float mod = Hval - sel;
         float v1 = V * (1f - S);
         float v2 = V * (1f - S * mod);
         float v3 = V * (1f - S * (1f - mod));
         switch (sel + 1)
         {
         case 0:
             col.r = V;
             col.g = v1;
             col.b = v2;
             break;
         case 1:
             col.r = V;
             col.g = v3;
             col.b = v1;
             break;
         case 2:
             col.r = v2;
             col.g = V;
             col.b = v1;
             break;
         case 3:
             col.r = v1;
             col.g = V;
             col.b = v3;
             break;
         case 4:
             col.r = v1;
             col.g = v2;
             col.b = V;
             break;
         case 5:
             col.r = v3;
             col.g = v1;
             col.b = V;
             break;
         case 6:
             col.r = V;
             col.g = v1;
             col.b = v2;
             break;
         case 7:
             col.r = V;
             col.g = v3;
             col.b = v1;
             break;
         }
         col.r = Mathf.Clamp(col.r, 0f, 1f);
         col.g = Mathf.Clamp(col.g, 0f, 1f);
         col.b = Mathf.Clamp(col.b, 0f, 1f);
         return col;
     }
    }
}
