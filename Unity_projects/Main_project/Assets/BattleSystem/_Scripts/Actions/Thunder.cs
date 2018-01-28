using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : Action{

    public override void Init()
    {
        name = "Thunder";
        desc = "Cast a magical thunder strike to the enemy";
        battleDesc = caster.battlerName + " casts a thunder strike ";
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        target.MagicDamage(caster.mag, "Thunder");
    }
}
