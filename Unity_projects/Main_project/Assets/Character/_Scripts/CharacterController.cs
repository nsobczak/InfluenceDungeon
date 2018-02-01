using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    #region Attributes

    public bool mustBeReset = false;

    public static int maxCharacterControllerCount = 1;
    public static int characterControllerCount = 0;

    [SerializeField] private int MAIN_MENU_INDEX = 0;
    [SerializeField] private string FLOOR_TAG = "Floor";
    [SerializeField] private string FLOOR_START_TAG = "FloorStart";
    [SerializeField] private string FLOOR_TRAP_TAG = "FloorTrap";
    [SerializeField] private string BATTLE_SCENE_NAME = "BattleScene";
    [SerializeField] private float PLAYER_Y_OFFSET = 0.8f;
    [SerializeField] private float TRAP_Y_OFFSET = -0.2f;
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float SECURITY_FLOOR_DISTANCE_PERCENTAGE = 0.2f;
    [SerializeField] private int TRAP_SPIKES_DAMAGE_AMOUNT = 40;
    [SerializeField] private int TRAP_OTHER_DAMAGE_AMOUNT = 20;

    private GameObject startPointTile;
    private List<GameObject> coloredTiles;
    private float floorSize;
    private Player player;
    private Vector3 playerPosition;

    public MonsterTypeEnum lastMonsterType;
    public int lastMonsterIndex;

    #endregion


    //____________________________________________________

    #region singleton

    private static CharacterController characterControllerInstance = null;

    private CharacterController()
    {
        ++characterControllerCount;
    }

    ~CharacterController()
    {
        --characterControllerCount;
    }

    public static CharacterController GetGameControllerInstance
    {
        get
        {
            if (characterControllerInstance == null)
                characterControllerInstance = new CharacterController();
            return characterControllerInstance;
        }
    }

    #endregion


    #region Methods

    private bool IsMovementAllowed(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) <= this.floorSize)
            return true;
        else
            return false;
    }


    private void Reset()
    {
        Debug.Log("this.transform.name: " + this.transform.name);
        if (null == startPointTile)
            startPointTile = GameObject.FindWithTag(FLOOR_START_TAG);
        this.transform.position = new Vector3(startPointTile.transform.position.x, startPointTile.transform.position.y,
            startPointTile.transform.position.z); //on start point
        player = GameObject.Instantiate(playerPrefab, transform).GetComponent<Player>();
        player.transform.position = this.transform.position + new Vector3(0, PLAYER_Y_OFFSET, 0); //make visible
    }


    private void GameOver()
    {
        Debug.Log("game over");
        GameObject.Destroy(player);
        SceneManager.LoadScene(0);
    }

    #endregion


    #region MainFunctions

    private void Start()
    {
        Vector3 floorSizeVector = floorPrefab.transform.GetComponent<MeshRenderer>().bounds.size;
        floorSize = (floorSizeVector.x + floorSizeVector.z) / 2 +
                    SECURITY_FLOOR_DISTANCE_PERCENTAGE * (floorSizeVector.x + floorSizeVector.z);
        coloredTiles = new List<GameObject>();

        startPointTile = GameObject.FindWithTag(FLOOR_START_TAG);
        mustBeReset = true;
    }


    /**
     * \fn private void CheckTileEvent(GameObject tile)
     * \param GameObject tile
     * \brief check if tile contains a special tile
     */
    private void CheckTileEvent(GameObject tile)
    {
        if (tile.transform.childCount > 0 || tile.transform.CompareTag(FLOOR_TRAP_TAG))
        {
            Debug.Log("It's a trap !");
            GameObject trapTile;
            if (tile.transform.childCount > 0)
                trapTile = tile.transform.GetChild(0).gameObject;
            else
                trapTile = tile.gameObject;

            tile.GetComponent<MeshRenderer>().enabled = false;
//            trapTile.transform.position = new Vector3(trapTile.transform.position.x, TRAP_Y_OFFSET,
//                trapTile.transform.position.z);

            if (null != trapTile)
            {
                TileNatureEnum childTileNature = trapTile.GetComponent<EventTile>().TileNatureEnum;

                if (childTileNature == TileNatureEnum.Spikes)
                {
                    Debug.Log("Trap is: " + TileNatureEnum.Spikes);
                    player.Hp -= TRAP_SPIKES_DAMAGE_AMOUNT;
                }
                else if (childTileNature == TileNatureEnum.Holes)
                {
                    Debug.Log("Trap is: " + TileNatureEnum.Holes);
                    GameObject.Destroy(player.gameObject);
                    Reset();
                }
                else if (childTileNature == TileNatureEnum.OtherTrap)
                {
                    Debug.Log("Trap is: " + TileNatureEnum.OtherTrap);
                    player.Hp -= TRAP_OTHER_DAMAGE_AMOUNT;
                }
                else if (childTileNature == TileNatureEnum.Monster)
                {
                    Debug.Log("Trap is: " + TileNatureEnum.Monster);
                    //TODO: select matching monster
                    TileMonster tileMonster = trapTile.GetComponent<TileMonster>();
                    if (null != tileMonster)
                    {
                        lastMonsterType = tileMonster.MonsterType;
                        lastMonsterIndex = tileMonster.MonsterIndex;
                        SceneManager.LoadScene(BATTLE_SCENE_NAME);
                    }
                    else
                        Debug.LogError("Monster tile not found");
                }
                else if (childTileNature == TileNatureEnum.StartPoint)
                {
                    Debug.Log("Trap is: " + TileNatureEnum.StartPoint);
                }
                else if (childTileNature == TileNatureEnum.ExitPoint)
                {
                    Debug.Log("Trap is: " + TileNatureEnum.ExitPoint);
                    GameOver();
                }
                else
                    Debug.Log("Trap is unknown !");
            }

            if (player.Hp <= 0)
            {
                GameObject.Destroy(player.gameObject);
                Reset();
            }
        }
    }

    private void Update()
    {
        if (mustBeReset)
        {
            mustBeReset = false;
            Reset();
        }


        // === handle movement on tiles ===
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if ((hit.transform.CompareTag(FLOOR_TAG) || hit.transform.CompareTag(FLOOR_TRAP_TAG)) &&
                IsMovementAllowed(hit.transform))
            {
                hit.transform.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                coloredTiles.Add(hit.transform.gameObject);

                if (Input.GetMouseButtonDown(0))
                {
                    playerPosition =
                        new Vector3(hit.transform.position.x, PLAYER_Y_OFFSET, hit.transform.position.z);
                    transform.position = playerPosition;

                    //TODO: see what doesn't work here
                    foreach (GameObject tile in coloredTiles)
                    {
                        if (null != tile)
                            tile.transform.GetComponent<MeshRenderer>().materials[0].color = Color.white;
                    }

                    CheckTileEvent(hit.transform.gameObject);
                }
            }
        }
    }

    #endregion
}