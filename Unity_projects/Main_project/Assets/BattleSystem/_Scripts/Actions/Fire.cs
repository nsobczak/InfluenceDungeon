using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Action{

    public Fire()
    {
        name = "Fire";
        desc = "Cast a magical fire ball to the enemy";
        battleDesc = caster.battlerName + " casts a fire ball ";
        priority = 1;
        mpCost = 5;
        hpCost = 0;
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        target.MagicDamage(caster.mag, "Fire");
    }
}
