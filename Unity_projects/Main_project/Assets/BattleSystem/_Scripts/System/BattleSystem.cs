using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    #region Attributes

    public EnemyBattlerController enemy;
    public PlayerBattlerController player;
    public GameObject description;
    public GameObject selectionPanel;
    public GameObject magicPanel;

    [SerializeField] private string EXPlORATION_SCENE = "DungeonExploration";

    [HideInInspector] public Text descriptionText;

    private bool wait;

    #endregion

    //___________________________________________________

    private void endBattle(bool victory)
    {
        player.activeTurn = false;
        enemy.activeTurn = false;
        selectionPanel.SetActive(false);
        if (victory)
        {
            descriptionText.text = "Victory";
            Destroy(enemy.gameObject);
//            TODO: replace following line by just destroy battle scene and
// return to the same EXPlORATION_SCENE (without creating a new player)
            SceneManager.LoadScene(EXPlORATION_SCENE);
        }
        else
        {
            descriptionText.text = "Game Over";
            Destroy(player.gameObject);
            SceneManager.LoadScene(EXPlORATION_SCENE); //restart level
        }
    }

    IEnumerator PlayerTurn()
    {
        player.PerformAction(player.selectedAction);
        magicPanel.SetActive(false);
        selectionPanel.SetActive(false);
        player.selectedAction = null;
        player.activeTurn = false;
        enemy.activeTurn = true;
        yield return new WaitForSeconds(2);
        wait = false;
    }

    IEnumerator EnemyTurn()
    {
        enemy.PerformAction(enemy.SelectAction());
        enemy.activeTurn = false;
        player.activeTurn = true;
        yield return new WaitForSeconds(2);
        wait = false;
    }

    //___________________________________________________

    void Start()
    {
        descriptionText = description.GetComponent<Text>();

        selectionPanel.SetActive(false);
        if (player.init >= enemy.init)
        {
            player.activeTurn = true;
            enemy.activeTurn = false;
        }
        else
        {
            player.activeTurn = false;
            enemy.activeTurn = true;
        }
    }

    void Update()
    {
        if (!wait)
        {
            if (player.activeTurn)
            {
                selectionPanel.SetActive(true);
                if (player.selectedAction != null)
                {
                    wait = true;
                    StartCoroutine(PlayerTurn());
                }
            }
            else if (enemy.activeTurn)
            {
                wait = true;
                StartCoroutine(EnemyTurn());
            }

            if (player.hp <= 0)
            {
                endBattle(false);
            }
            else if (enemy.hp <= 0)
            {
                endBattle(true);
            }
        }
    }
}