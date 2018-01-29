using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Action{

    public override void Init()
    {
        name = "Ice";
        desc = "Cast a magical ice lance to the enemy";
        battleDesc = caster.battlerName + " casts an ice lance ";
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        target.MagicDamage(caster.mag, "Ice");
    }
}
