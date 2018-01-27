using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : Action{

    public Thunder()
    {
        name = "Thunder";
        desc = "Cast a magical thunder strike to the enemy";
        battleDesc = caster.battlerName + " casts a thunder strike ";
        priority = 1;
        mpCost = 5;
        hpCost = 0;
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        target.MagicDamage(caster.mag, "Thunder");
    }
}
