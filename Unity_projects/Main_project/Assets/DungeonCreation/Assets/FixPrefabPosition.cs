using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPrefabPosition : MonoBehaviour {

	public GameObject CrossTriggerPrefab;
	public GameObject[] CrossTriggers;

	// Use this for initialization
	void Start () {
		if (CrossTriggers == null) {
			CrossTriggers = GameObject.FindGameObjectsWithTag ("Stick");
		}

		foreach (GameObject CrossTrigger in CrossTriggers) {
			CrossTrigger.transform.position = new Vector3(0,0,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossTriggers == null) {
			CrossTriggers = GameObject.FindGameObjectsWithTag ("Stick");
		}

		foreach (GameObject CrossTrigger in CrossTriggers) {
			CrossTrigger.transform.position = transform.parent.position;
		}
	}
}
