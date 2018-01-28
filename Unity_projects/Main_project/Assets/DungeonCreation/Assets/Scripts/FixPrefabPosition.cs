using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPrefabPosition : MonoBehaviour {

	public GameObject CrossTriggerPrefab;
	public GameObject[] CrossTriggers;

	// Use this for initialization
	void Start () {
		CrossTriggers = GameObject.FindGameObjectsWithTag ("Stick");


		for (int i = 0; i < CrossTriggers.Length; i = i+4) {
			CrossTriggers [i].transform.localPosition = new Vector3 (0, 0, -1);
			CrossTriggers [i + 1 ].transform.localPosition = new Vector3 (0, 0, 1);
			CrossTriggers [i + 2].transform.localPosition = new Vector3 (-1, 0, 0);
			CrossTriggers [i + 3].transform.localPosition = new Vector3 (1, 0, 0);
			CrossTriggers [i].transform.Rotate(0, 90, 0);
			CrossTriggers [i + 1].transform.Rotate(0, 90, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossTriggers == null) {
			CrossTriggers = GameObject.FindGameObjectsWithTag ("Stick");
		}

//		foreach (GameObject CrossTrigger in CrossTriggers) {
//			CrossTrigger.transform.position = transform.parent.position;
//		}
		for (int i = 0; i <= CrossTriggers.Length; i = i+4) {
			CrossTriggers [i].transform.localPosition = new Vector3 (0, 0, -1);
			CrossTriggers [i + 1 ].transform.localPosition = new Vector3 (0, 0, 1);
			CrossTriggers [i + 2].transform.localPosition = new Vector3 (-1, 0, 0);
			CrossTriggers [i + 3].transform.localPosition = new Vector3 (1, 0, 0);
			CrossTriggers [i].transform.Rotate(0, 90, 0);
			CrossTriggers [i + 1].transform.Rotate(0, 90, 0);
		}
	}
}
