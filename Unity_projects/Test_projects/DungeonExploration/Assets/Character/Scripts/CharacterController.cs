using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private string FLOOR_TAG = "Floor";
    [SerializeField] private float PLAYER_Y_OFFSET = 0.8f;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.transform.CompareTag(FLOOR_TAG) && Input.GetMouseButtonDown(0))
            {
                Debug.Log("hit object is: " + hit.transform.name);
                transform.position = new Vector3(hit.transform.position.x, PLAYER_Y_OFFSET, hit.transform.position.z);
            }
        }
    }
}