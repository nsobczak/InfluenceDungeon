using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class DRCore: ScriptableObject
{

    public void ReplacementProcess(Object[] selectedObjects, Dictionary<int, GameObject> targetPrefabs, Dictionary<int, float> rotations, int replaceIdCount)
    {
        //сначала поулчаем список всех выделенных объектов с подобъектами
        List<GameObject> toReplaceList = new List<GameObject>();
        for (int i = 0; i < selectedObjects.Length; i++ )
        {
            GameObject go = (GameObject)selectedObjects[i];
            Transform[] trs = go.GetComponentsInChildren<Transform>();
            
            for (int j = 0; j < trs.Length; j++ )
            {
                GameObject g = (GameObject)trs[j].gameObject;
                if(g.GetComponent<DRId>() != null)
                {
                    toReplaceList.Add(g);
                }
            }
        }

        //теперь делаем замену каждого из них
        for (int i = toReplaceList.Count - 1; i >= 0; i-- )
        {
            int id = toReplaceList[i].GetComponent<DRId>().id;
            if(id < replaceIdCount)
            {
                if (targetPrefabs.ContainsKey(id) && targetPrefabs[id] != null)
                {
                    GameObject g = (GameObject)PrefabUtility.InstantiatePrefab(targetPrefabs[id]);
                    g.transform.position = toReplaceList[i].transform.position;
                    Vector3 angles = g.transform.rotation.eulerAngles;
                    angles = new Vector3(angles.x, angles.y + rotations[id], angles.z);
                    g.transform.rotation = Quaternion.Euler(angles);

                    g.transform.SetParent(toReplaceList[i].transform.parent);
                    DestroyImmediate(toReplaceList[i]);
                }
            }
            
        }
        toReplaceList = new List<GameObject>();
    }

	
}
