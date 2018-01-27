using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action{

    public Attack()
    {
        name = "Attack";
        desc = "Hit the enemy with a physical attack";
        battleDesc = caster.battlerName + " attacks " + target.battlerName;
        priority = 1;
        mpCost = 0;
        hpCost = 0;
    }

    public override void CastAction()
    {
        target.PhysicDamage(caster.atk);
    }
}
