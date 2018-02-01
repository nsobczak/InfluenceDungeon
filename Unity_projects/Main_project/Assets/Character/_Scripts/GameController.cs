using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Attributes

    [SerializeField] private static int maxInstanceCount = 1;
    private static int instanceCount = 0;

    [SerializeField] private GameObject characterControllerPrefab;
    [SerializeField] private GameObject monsterControllerPrefab;

    #endregion

    //___________________________________________

    #region singleton

    private static GameController gameControllerInstance = null;

    public GameController()
    {
        ++instanceCount;
    }

    ~GameController() // destructor
    {
        --instanceCount;
    }

    public static GameController GetGameControllerInstance
    {
        get
        {
            if (gameControllerInstance == null)
                gameControllerInstance = new GameController();
            return gameControllerInstance;
        }
    }

    #endregion

    //___________________________________________

    void Start()
    {
        if (instanceCount > maxInstanceCount + 1)
            GameObject.Destroy(this.gameObject);


        if (CharacterController.characterControllerCount < CharacterController.maxCharacterControllerCount + 1)
            GameObject.Instantiate(characterControllerPrefab, transform);
        else
            Debug.Log("GameController instance already exists");
        
        if (MonsterController.instanceCount < MonsterController.maxInstanceCount + 1)
            GameObject.Instantiate(monsterControllerPrefab, transform);
        else
            Debug.Log("MonsterController instance already exists");
    }
}