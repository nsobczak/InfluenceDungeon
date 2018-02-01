using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMonster : MonoBehaviour
{
    [SerializeField] private MonsterTypeEnum monsterType;
    [SerializeField] private int monsterIndex;

    public MonsterTypeEnum MonsterType
    {
        get { return monsterType; }
        set { monsterType = value; }
    }

    public int MonsterIndex
    {
        get { return monsterIndex; }
        set { monsterIndex = value; }
    }
}