using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattlerController : BattlerController {

    private Action attack;
    private List<Action> magics;
    private Action guard;
    private Action selectedAction;

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

		selectedAction = null;
	}
	
	// Update is called once per frame
//	void Update () {
//        if (activeTurn)
//        {
//            StartCoroutine("Action");
//        }
//	}

	IEnumerator selectionWaiting() {
		Debug.Log("Before Waiting 1 seconds");
		yield return new WaitForSeconds(1);
		Debug.Log("After Waiting 1 Seconds");
	}
	
    public Action selectAction()
    {
        while (selectedAction == null)
        {
	        StartCoroutine(selectionWaiting());
        }
        return selectedAction;
    }
    
	
	//______________________________________
	// buttons functions

	public void selectAttackAction()
	{
		this.selectedAction = attack;
		Debug.Log("attack action selected");
	}
	

}
