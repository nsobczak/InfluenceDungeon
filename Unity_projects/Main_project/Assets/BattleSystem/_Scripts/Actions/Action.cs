using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action{

    public string name, desc, battleDesc;
    public int priority, mpCost, hpCost;
    public BattlerController target, caster;

    public abstract void CastAction();
}
