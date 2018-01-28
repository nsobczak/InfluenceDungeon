using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Attribute

    [SerializeField] private int MAX_HP = 100;
    [SerializeField] private int MAX_MP = 50;

    private int HP;
    private int MP;

    #endregion

    //___________________________________________________

    #region Methodes

    public Player()
    {
        this.HP = MAX_HP;
        this.MP = MAX_MP;
    }

    public int Hp
    {
        get { return HP; }
        set { HP = value; }
    }

    public int Mp
    {
        get { return MP; }
        set { MP = value; }
    }

    #endregion
}