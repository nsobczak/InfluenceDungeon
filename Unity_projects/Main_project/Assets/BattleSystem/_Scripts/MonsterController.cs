using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    #region Attributes

    public static int maxInstanceCount = 1;
    public static int instanceCount = 0;

    [SerializeField] private string CHARACTER_CONTROLLER_TAG = "CharacterController";
    [SerializeField] private string BATTLE_SYSTEM_TAG = "BattleSystem";
    [SerializeField] private List<GameObject> monsterList;
    [SerializeField] private List<GameObject> bossList;

    private GameObject characterController;
    private CharacterController characterControllerScript;
    private GameObject battleSystem;

    #endregion

    //___________________________________________

    #region singleton

    private static MonsterController monsterControllerInstance = null;

    public MonsterController()
    {
        ++instanceCount;
    }

    ~MonsterController() // destructor
    {
        --instanceCount;
    }

    public static MonsterController GetMonsterControllerInstance
    {
        get
        {
            if (monsterControllerInstance == null)
                monsterControllerInstance = new MonsterController();
            return monsterControllerInstance;
        }
    }

    #endregion

    //___________________________________________

    #region Functions

    private GameObject AddMonster(int monsterIndex)
    {
        return GameObject.Instantiate(monsterList[monsterIndex], battleSystem.GetComponent<Transform>());
    }

    private GameObject AddBoss(int monsterIndex)
    {
        return GameObject.Instantiate(bossList[monsterIndex], battleSystem.GetComponent<Transform>());
    }

    private GameObject AddEnnemy()
    {
        characterControllerScript = characterController.GetComponent<CharacterController>();

        if (characterControllerScript.lastMonsterType == MonsterTypeEnum.Boss)
            return AddBoss(characterControllerScript.lastMonsterIndex);
        else
            return AddMonster(characterControllerScript.lastMonsterIndex);
    }

    public GameObject InitBattle()
    {
        battleSystem = GameObject.FindGameObjectWithTag(BATTLE_SYSTEM_TAG);
        characterController = GameObject.FindGameObjectWithTag(CHARACTER_CONTROLLER_TAG);

        return AddEnnemy();
    }

    #endregion
}