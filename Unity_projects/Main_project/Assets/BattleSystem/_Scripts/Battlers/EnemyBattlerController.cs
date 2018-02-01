using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattlerController : BattlerController
{
    #region Attributes

    public List<Action> actions;

    private int priorityRange;
    private List<Action> priorityActions;

    #endregion

    //___________________________________________________
    
    void Start()
    {
        //TODO: set monster's characteristics
        
        priorityRange = 0;
        priorityActions = new List<Action>();
        foreach (Action action in actions)
        {
            action.target = battleSystem.player;
            action.caster = battleSystem.enemy;
            priorityRange += action.priority;
            action.Init();
            for (int i = 0; i < action.priority; i++)
            {
                priorityActions.Add(action);
            }
        }
    }


    public Action SelectAction()
    {
        return priorityActions[Mathf.RoundToInt(Random.Range(0, priorityRange - 1))];
    }
}