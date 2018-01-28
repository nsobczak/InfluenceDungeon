                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBricks : MonoBehaviour {

	public float blocSize=5;
	private Vector3 screenPoint;
	private Vector3 offset;

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
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit, 10)) {
			transform.position = new Vector3 (hit.transform.position.x - blocSize, hit.transform.position.y, hit.transform.position.z);
		} else if (Physics.Raycast (transform.position, bwd, out hit, 10)) {
			transform.position = new Vector3 (hit.transform.position.x + blocSize, hit.transform.position.y, hit.transform.position.z);
		}else if (Physics.Raycast (transform.position, uwd, out hit, 10)) {
			transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y, hit.transform.position.z - blocSize);
		}else if (Physics.Raycast (transform.position, dwd, out hit, 10)) {
			transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y, hit.transform.position.z + blocSize);
		}
	}
}