using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Attributes

    [SerializeField] private string FLOOR_TAG = "Floor";
    [SerializeField] private string TRAP_SPIKES_TAG = "TrapSpikes";
    [SerializeField] private string TRAP_HOLES_TAG = "TrapHoles";
    [SerializeField] private string TRAP_OTHER_TAG = "TrapOther";
    [SerializeField] private float PLAYER_Y_OFFSET = 0.8f;
    [SerializeField] private GameObject floorPrefab;
    private List<GameObject> coloredTiles;

    private float floorSize;
    [SerializeField] private float SECURITY_PERCENTAGE = 0.2f;

    #endregion


    //____________________________________________________

    #region Functions

    private void Start()
    {
        Vector3 floorSizeVector = floorPrefab.transform.GetComponent<MeshRenderer>().bounds.size;
        floorSize = (floorSizeVector.x + floorSizeVector.z) / 2 +
                    SECURITY_PERCENTAGE * (floorSizeVector.x + floorSizeVector.z);
        coloredTiles = new List<GameObject>();
    }


    private bool IsMovementAllowed(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) <= this.floorSize)
            return true;
        else
            return false;
    }


    //check if tile contains a special tile
    private void CheckTileEvent(GameObject tile)
    {
        if (tile.transform.childCount > 0)
        {
            //TODO: handle trap
            Debug.Log("It's a trap !");
            Transform childTile = tile.transform.GetChild(0);
            if (childTile.CompareTag(TRAP_SPIKES_TAG))
            {
                Debug.Log("Trap is: " + TRAP_SPIKES_TAG);
            }
            else if (childTile.CompareTag(TRAP_HOLES_TAG))
            {
                Debug.Log("Trap is: " + TRAP_HOLES_TAG);
            }
            else //banana peel
            {
                Debug.Log("Trap is: " + TRAP_OTHER_TAG);
            }
        }
    }


    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.transform.CompareTag(FLOOR_TAG) && IsMovementAllowed(hit.transform))
            {
                hit.transform.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                coloredTiles.Add(hit.transform.gameObject);

                if (Input.GetMouseButtonDown(0))
                {
//                    Debug.Log("hit object is: " + hit.transform.name);
                    transform.position =
                        new Vector3(hit.transform.position.x, PLAYER_Y_OFFSET, hit.transform.position.z);

                    foreach (var tile in coloredTiles)
                        tile.transform.GetComponent<MeshRenderer>().materials[0].color = Color.white;

                    CheckTileEvent(hit.transform.gameObject);
                }
            }
        }
    }

    #endregion
}