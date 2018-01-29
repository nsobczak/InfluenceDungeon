using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickDrag : MonoBehaviour {
	public float posX;
	public float posZ;

	// Use this for initialization
	void Start () {
		posX = transform.localPosition.x;
		posZ = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Position" + transform.position);
	}

	void OnTriggerEnter(Collider other) {
		if (Input.GetMouseButtonUp (0)) {
			if (other.CompareTag("Stick")) {
				posX = other.transform.position.x;
				posZ = other.transform.position.z;
				transform.position = new Vector3 (posX, 0, posZ);
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (Input.GetMouseButtonUp (0)) {
			if (other.CompareTag("Stick")) {
				posX = other.transform.position.x;
				posZ = other.transform.position.z;
				transform.position = new Vector3 (posX, 0, posZ);
			}
		}
	}
}
