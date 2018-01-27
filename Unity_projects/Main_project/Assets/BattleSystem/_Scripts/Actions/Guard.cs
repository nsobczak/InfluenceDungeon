using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Action{

    public Guard()
    {
        name = "Guard";
        desc = "Raise your guard to defend yourself";
        battleDesc = caster.battlerName + " guards up ";
        priority = 1;
        mpCost = 0;
        hpCost = 0;
    }

    public override void CastAction()
    {
        caster.buffs.EnhanceStat("def", caster.def, 1);
        caster.buffs.EnhanceStat("res", caster.def, 1);
    }
}
