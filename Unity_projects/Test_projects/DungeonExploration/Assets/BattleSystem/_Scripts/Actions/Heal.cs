using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Action {

    public override void Init()
    {
        name = "Heal";
        desc = "Heal yourself";
        battleDesc = caster.battlerName + " heals up ";
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        caster.RegenHp(caster.mag);
    }

}
