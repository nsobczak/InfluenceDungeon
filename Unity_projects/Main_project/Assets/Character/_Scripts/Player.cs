using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Attribute

    [SerializeField] private int MAX_HP = 100;
    [SerializeField] private int MAX_MP = 50;
    
    private string name;
    private int hp;
    private int mp;

    #endregion

    //___________________________________________________

    #region Methodes

    public Player()
    {
        this.hp = MAX_HP;
        this.mp = MAX_MP;
        this.name = "Player";
    }

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Mp
    {
        get { return mp; }
        set { mp = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    #endregion
}