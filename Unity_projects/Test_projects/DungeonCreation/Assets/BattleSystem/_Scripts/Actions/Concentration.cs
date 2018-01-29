using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concentration : Action{

    public override void Init()
    {
        name = "Concentration";
        desc = "Focus to regain MP";
        battleDesc = caster.battlerName + " is focusing ";
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        caster.RegenMp(10);
    }
}
