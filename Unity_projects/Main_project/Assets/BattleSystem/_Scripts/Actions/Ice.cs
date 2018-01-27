using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Action{

    public Ice()
    {
        name = "Ice";
        desc = "Cast a magical ice lance to the enemy";
        battleDesc = caster.battlerName + " casts an ice lance ";
        priority = 1;
        mpCost = 5;
        hpCost = 0;
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        target.MagicDamage(caster.mag, "Ice");
    }
}
