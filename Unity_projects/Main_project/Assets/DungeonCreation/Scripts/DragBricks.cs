using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBricks : MonoBehaviour {

	public float blocSize=5;
	private Vector3 screenPoint;
	private Vector3 offset;
	public bool joinUp=true,joinDown=true,joinLeft=true,joinRight=true;
	public float joinDistanceUp=10,joinDistanceDown=10,joinDistanceLeft=10,joinDistanceRight=10;

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
	}

	void OnMouseUp(){
		Vector3 fwd = transform.TransformDirection(new Vector3(1,0,0));
		Vector3 bwd = transform.TransformDirection(new Vector3(-1,0,0));
		Vector3 uwd = transform.TransformDirection(new Vector3(0,1,0));
		Vector3 dwd = transform.TransformDirection(new Vector3(0,-1,0));
		float minDistR=joinDistanceRight,minDistL=joinDistanceLeft,minDistU=joinDistanceUp,minDistD=joinDistanceDown;
		Transform transR, transL, transU, transD;
		transR=transL=transU=transD=transform;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit, joinDistanceRight)&&joinRight) {
			minDistR=hit.distance;
			transR=hit.transform;
		}
		if (Physics.Raycast (transform.position, bwd, out hit, joinDistanceLeft)&&joinLeft) {
			minDistL=hit.distance;
			transL=hit.transform;
		}
		if (Physics.Raycast (transform.position, uwd, out hit, joinDistanceUp)&&joinUp) {
			minDistU=hit.distance;
			transU=hit.transform;
		}
		if (Physics.Raycast (transform.position, dwd, out hit, joinDistanceDown)&&joinDown) {
			minDistD=hit.distance;
			transD=hit.transform;
		}
		if (minDistR < minDistL&&minDistR<minDistU&&minDistR<minDistD) {
			transform.position = new Vector3 (transR.position.x - blocSize, transR.position.y, transR.position.z);
		}
		if (minDistL < minDistR && minDistL < minDistU && minDistL < minDistD) {
			transform.position = new Vector3 (transL.position.x + blocSize, transL.position.y, transL.position.z);
		}
		if (minDistU < minDistR && minDistU < minDistL && minDistU < minDistD) {
			transform.position = new Vector3 (transU.position.x, transU.position.y, transU.position.z - blocSize);
		}
		if (minDistD < minDistR && minDistD < minDistL && minDistD < minDistU) {
			transform.position = new Vector3 (transD.position.x, transD.position.y, transD.position.z + blocSize);
		}
	}
}