using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattlerController : BattlerController {

    private Action attack;
    private List<Action> magics;
    private Action guard;

	// Use this for initialization
	void Start () {
        attack = new Attack();
        guard = new Guard();
        magics = new List<Action>();
        magics.Add(new Fire());
        magics.Add(new Ice());
        magics.Add(new Thunder());
        magics.Add(new Heal());
        magics.Add(new Concentration());
    }
	
	// Update is called once per frame
	void Update () {
        if (activeTurn)
        {
            StartCoroutine("Action");
        }
	}

    public Action selectAction()
    {
        return null;
    }

}
