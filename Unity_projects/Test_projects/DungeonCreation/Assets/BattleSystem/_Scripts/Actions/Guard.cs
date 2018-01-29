using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Action{

    public override void Init()
    {
        name = "Guard";
        desc = "Raise your guard to defend yourself";
        battleDesc = caster.battlerName + " guards up ";
    }

    public override void CastAction()
    {
        caster.buffs.EnhanceStat("def", caster.def, 1);
        caster.buffs.EnhanceStat("res", caster.res, 1);
    }
}
