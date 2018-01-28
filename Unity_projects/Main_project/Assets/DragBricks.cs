                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBricks : MonoBehaviour {

	public float blocSize=5;
	private Vector3 screenPoint;
	private Vector3 offset;

	private string pos;
	private GameObject collisionObject;
	private bool canClip = false;

	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag()
	{
		Vector3 cursorScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint (cursorScreenPoint) + offset;
		transform.position = cursorPosition;
		canClip = true;
	}

	void OnMouseUp(){
		if (canClip&&collisionObject!=null) {
			Vector3 relative=collisionObject.transform.InverseTransformPoint(transform.position);
			if(relative.x>0){
				pos="right";
			}else{
				pos="left";
			}
			if(relative.x/relative.y<1){
				if(relative.y>0){
					pos="top";
				}else{
					pos="bottom";
				}
			}

			Debug.Log (pos);

			if (pos == "top") {
				transform.position = new Vector3 (collisionObject.transform.position.x, collisionObject.transform.position.y, collisionObject.transform.position.z + blocSize);
			} else if (pos == "right") {
				transform.position = new Vector3 (collisionObject.transform.position.x + blocSize, collisionObject.transform.position.y, collisionObject.transform.position.z);
			} else if (pos == "left") {
				transform.position = new Vector3 (collisionObject.transform.position.x - blocSize, collisionObject.transform.position.y, collisionObject.transform.position.z);
			} else if (pos == "bottom") {
				transform.position = new Vector3 (collisionObject.transform.position.x, collisionObject.transform.position.y, collisionObject.transform.position.z - blocSize);
			}
		}
		canClip = false;

	}

	public void Clip(GameObject otherObject){
		if (canClip) {
			Debug.Log (otherObject);
			collisionObject = otherObject;
		}
	}

	void OnTriggerExit(Collider other){
		collisionObject = null;
	}
}