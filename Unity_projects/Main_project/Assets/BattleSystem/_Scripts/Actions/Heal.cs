using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Action {

    public Heal()
    {
        name = "Heal";
        desc = "Heal yourself";
        battleDesc = caster.battlerName + " heals up ";
        priority = 1;
        mpCost = 10;
        hpCost = 0;
    }

    public override void CastAction()
    {
        caster.SpendMp(mpCost);
        caster.RegenHp(caster.mag);
    }

}
