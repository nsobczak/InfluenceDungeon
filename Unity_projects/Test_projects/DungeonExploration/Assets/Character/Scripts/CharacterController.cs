using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Attributes

    [SerializeField] private string FLOOR_TAG = "Floor";
    [SerializeField] private float PLAYER_Y_OFFSET = 0.8f;
    [SerializeField] private GameObject FLOOR_PREFAB;

    private float floorSize;
    [SerializeField] private float SECURITY_PERCENTAGE = 0.2f;

    #endregion


    //____________________________________________________

    #region Functions
    
    private void Start()
    {
        Vector3 floorSizeVector = FLOOR_PREFAB.transform.GetComponent<MeshRenderer>().bounds.size;
        floorSize = (floorSizeVector.x + floorSizeVector.z) / 2 +
                    SECURITY_PERCENTAGE * (floorSizeVector.x + floorSizeVector.z);
        Debug.Log("size: " + floorSize);
    }


    private bool IsMovementAllowed(Transform target)
    {
        Debug.Log("distance: " + Vector3.Distance(transform.position, target.position));
        if (Vector3.Distance(transform.position, target.position) <= this.floorSize)
            return true;
        else
            return false;
    }


    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (Input.GetMouseButtonDown(0) && hit.transform.CompareTag(FLOOR_TAG) && IsMovementAllowed(hit.transform))
            {
                Debug.Log("hit object is: " + hit.transform.name);
                transform.position = new Vector3(hit.transform.position.x, PLAYER_Y_OFFSET, hit.transform.position.z);
            }
        }
    }
    
    #endregion
}