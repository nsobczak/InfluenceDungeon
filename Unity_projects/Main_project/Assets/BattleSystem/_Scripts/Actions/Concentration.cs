using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concentration : Action{

    public Concentration()
    {
        name = "Concentration";
        desc = "Focus to regain MP";
        battleDesc = caster.battlerName + " is focusing ";
        priority = 1;
        mpCost = 0;
        hpCost = 0;
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        caster.RegenMp(caster.mag/4);
    }
}
