using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTile : MonoBehaviour
{
    private TileNatureEnum tileNatureEnum;
    [SerializeField] private int tileNatureIndex;


    public TileNatureEnum TileNatureEnum
    {
        get { return tileNatureEnum; }
    }


    private void Start()
    {
        switch (tileNatureIndex)
        {
            case 1:
                tileNatureEnum = TileNatureEnum.Spikes;
                break;
            case 2:
                tileNatureEnum = TileNatureEnum.Holes;
                break;
            case 3:
                tileNatureEnum = TileNatureEnum.OtherTrap;
                break;
            case 4:
                tileNatureEnum = TileNatureEnum.Monster;
                break;
            case 5:
                tileNatureEnum = TileNatureEnum.StartPoint;
                break;
            case 6:
                tileNatureEnum = TileNatureEnum.ExitPoint;
                break;
            default:
                Debug.LogWarning("No trap on this tile");
                break;
        }
    }
}