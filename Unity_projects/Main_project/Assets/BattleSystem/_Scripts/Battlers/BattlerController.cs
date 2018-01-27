using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlerController : MonoBehaviour {

    public string battlerName;
    public int hpMax, mpMax, hp, mp, atk, mag, def, res, init;
    public float fireRes, iceRes, thunderRes;
    public BattleSystem battleSystem;

    [HideInInspector]
    public StatEnhancement buffs;
    public int turn;
    public bool activeTurn;
    public List<Action> actions;

    // Use this for initialization
    void Start () {
        buffs.Reinit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PerformAction(Action action)
    {
        turn++;
        action.CastAction();
    }

    public void PhysicDamage(int damage)
    {
        damage = Mathf.Max(0, damage - def);
        hp -= damage;
    }

    public void MagicDamage(int damage, string element)
    {
        float elementalRes = 1;
        if ("Fire".Equals(element))
        {
            elementalRes = fireRes;
        }
        else if("Ice".Equals(element))
        {
            elementalRes = iceRes;
        }
        else if ("Thunder".Equals(element))
        {
            elementalRes = thunderRes;
        }
        damage = Mathf.Max(0, Mathf.RoundToInt(elementalRes*damage) - res);
        hp -= damage;
    }

    public void SpendMp(int amount)
    {
        mp = Mathf.Max(0, mp - amount);
    }

    public void SpendHp(int amount)
    {
        hp = Mathf.Max(0, hp - amount);
    }

    public void RegenHp(int amount)
    {
        amount = Mathf.Min(hpMax, hp + amount);
    }

    public void RegenMp(int amount)
    {
        amount = Mathf.Min(mpMax, mp + amount);
    }
}
