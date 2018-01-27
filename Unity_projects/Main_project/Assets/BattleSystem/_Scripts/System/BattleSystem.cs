using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour {

    public EnemyBattlerController enemy;
    public PlayerBattlerController player;

	// Use this for initialization
	void Start () {
        if (player.init >= enemy.init)
        {
            player.activeTurn = false;
            enemy.activeTurn = true;
        }
        else
        {
            player.activeTurn = true;
            enemy.activeTurn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (player.activeTurn)
        {
            player.PerformAction(player.selectAction());
            player.activeTurn = false;
            enemy.activeTurn = true;
        }else if (enemy.activeTurn)
        {
            enemy.PerformAction(enemy.selectAction());
            enemy.activeTurn = false;
            player.activeTurn = true;
        }
        if(player.hp <= 0)
        {
            endBattle(true);
        }else if(enemy.hp <= 0)
        {
            endBattle(false);
        }
	}

    private void endBattle(bool victory)
    {
        if (victory)
        {
            Debug.Log("Victory");
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}
