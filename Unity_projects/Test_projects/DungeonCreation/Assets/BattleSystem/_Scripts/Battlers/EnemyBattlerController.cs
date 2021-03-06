﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattlerController : BattlerController {

    public List<Action> actions;

    private int priorityRange;
    private List<Action> priorityActions;

    // Use this for initialization
    void Start () {
        priorityRange = 0;
        priorityActions = new List<Action>();
        foreach (Action action in actions)
        {
            action.target = battleSystem.player;
            action.caster = battleSystem.enemy;
            priorityRange += action.priority;
            action.Init();
            for(int i=0; i<action.priority; i++)
            {
                priorityActions.Add(action);
            }
        }
        
	}

    // Update is called once per frame
    void Update()
    {

    }

    public Action SelectAction()
    {
        return priorityActions[Mathf.RoundToInt(Random.Range(0, priorityRange - 1))];
    }

}
