using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipOnCollide : MonoBehaviour {
	DragBricks script;
	void Start() {
		script = transform.parent.gameObject.GetComponent<DragBricks> ();
	}
	void OnTriggerStay(Collider other){
		if(Input.GetMouseButtonUp(0))script.Clip (other.transform.parent.gameObject);
	}
}