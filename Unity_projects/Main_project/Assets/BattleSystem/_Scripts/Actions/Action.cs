using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action: MonoBehaviour{

    public string name, desc, battleDesc;
    public int priority, mpCost, hpCost;

    [HideInInspector]
    public BattlerController target, caster;

    public abstract void CastAction();

    public abstract void Init();
}
