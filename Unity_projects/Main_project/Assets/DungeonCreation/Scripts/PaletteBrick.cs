using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteBrick : MonoBehaviour {
	public GameObject brick;
	void OnMouseDown()
	{
		Instantiate (brick,transform, Quaternion.identity);
	}
}
