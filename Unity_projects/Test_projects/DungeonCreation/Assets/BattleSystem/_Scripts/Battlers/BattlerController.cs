using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlerController : MonoBehaviour {

    public string battlerName;
    public int hpMax, mpMax, hp, mp, atk, mag, def, res, init;
    public float fireRes, iceRes, thunderRes;
    public BattleSystem battleSystem;
    public StatEnhancement buffs;

    [HideInInspector] public int turn;
    [HideInInspector] public bool activeTurn;

    // Use this for initialization
    void Start () {
        buffs.Reinit();
	}
	
	// Update is called once per frame
	void Update () {
        if (hp > hpMax + buffs.hpMax)
        {
            hp = hpMax + buffs.hpMax;
        }
        else if (hp < 0)
        {
            hp = 0;
        }
        if (mp > mpMax + buffs.mpMax)
        {
            mp = mpMax + buffs.mpMax;
        }
        else if (mp < 0)
        {
            mp = 0;
        }
    }

    public void PerformAction(Action action)
    {
        turn++;
        if (action != null)
        {
            action.CastAction();
            battleSystem.descriptionText.text = action.battleDesc;
        }
        else
        {
            battleSystem.descriptionText.text = battlerName + " is waiting";
        }
    }

    public void PhysicDamage(int damage)
    {
        damage = Mathf.Max(0, damage - (def+buffs.def));
        hp -= damage;
    }

    public void MagicDamage(int damage, string element)
    {
        float elementalRes = 1;
        if ("Fire".Equals(element))
        {
            elementalRes = fireRes + buffs.fireRes;
        }
        else if("Ice".Equals(element))
        {
            elementalRes = iceRes + buffs.iceRes;
        }
        else if ("Thunder".Equals(element))
        {
            elementalRes = thunderRes + buffs.thunderRes;
        }
        damage = Mathf.Max(0, Mathf.RoundToInt(elementalRes*damage) - (res+buffs.res));
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
        hp = Mathf.Min(hpMax+buffs.hpMax, hp + amount);
    }

    public void RegenMp(int amount)
    {
        mp = Mathf.Min(mpMax+buffs.mpMax, mp + amount);
    }
}
