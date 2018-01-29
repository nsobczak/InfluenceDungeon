using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Action{

    public override void Init()
    {
        name = "Fire";
        desc = "Cast a magical fire ball to the enemy";
        battleDesc = caster.battlerName + " casts a fire ball ";
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        target.MagicDamage(caster.mag, "Fire");
    }
}
