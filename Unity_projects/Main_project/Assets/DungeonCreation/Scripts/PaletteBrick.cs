using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteBrick : MonoBehaviour {
	public GameObject brick;
	void OnMouseDown()
	{
		//Instantiate (brick,transform.position,Quaternion.identity);
		RaycastHit hitInfo;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hitInfo))
			Instantiate(brick, hitInfo.point, transform.rotation);
	}
}
