using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour {

    public EnemyBattlerController enemy;
    public PlayerBattlerController player;
    public GameObject description;
    public GameObject selectionPanel;
    public GameObject magicPanel;

    [HideInInspector] public Text descriptionText;

    private bool wait;

	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
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

    private void endBattle(bool victory)
    {
        player.activeTurn = false;
        enemy.activeTurn = false;
        selectionPanel.SetActive(false);
        if (victory)
        {
            descriptionText.text = "Victory";
        }
        else
        {
            descriptionText.text = "Game Over";
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

}
