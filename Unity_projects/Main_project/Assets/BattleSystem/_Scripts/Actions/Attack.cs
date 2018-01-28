using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action{

    public override void Init()
    {
        name = "Attack";
        desc = "Hit the enemy with a physical attack";
        battleDesc = caster.battlerName + " attacks " + target.battlerName;
    }

    public override void CastAction()
    {
        target.PhysicDamage(caster.atk);
    }
}
