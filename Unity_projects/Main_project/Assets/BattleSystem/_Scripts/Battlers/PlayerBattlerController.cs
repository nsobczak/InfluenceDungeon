using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattlerController : BattlerController
{
    #region Attributes

    public Player player;
    public string PLAYER_TAG = "Player";

    public Action attack, guard, fire, ice, thunder, heal, concentration;

    public GameObject hpTextObject,
        mpTextObject,
        hpSliderObject,
        mpSliderObject,
        atkTextObject,
        magTextObject,
        defTextObject,
        resTextObject;

    [HideInInspector] public Action selectedAction;

    private Text hpText, mpText, atkText, magText, defText, resText;
    private Slider hpSlider, mpSlider;

    #endregion

    //___________________________________________________


    private void InitActions()
    {
        attack.target = battleSystem.enemy;
        attack.caster = battleSystem.player;
        attack.Init();

        guard.target = battleSystem.enemy;
        guard.caster = battleSystem.player;
        guard.Init();

        fire.target = battleSystem.enemy;
        fire.caster = battleSystem.player;
        fire.Init();

        ice.target = battleSystem.enemy;
        ice.caster = battleSystem.player;
        ice.Init();

        thunder.target = battleSystem.enemy;
        thunder.caster = battleSystem.player;
        thunder.Init();

        heal.target = battleSystem.enemy;
        heal.caster = battleSystem.player;
        heal.Init();

        concentration.target = battleSystem.enemy;
        concentration.caster = battleSystem.player;
        concentration.Init();
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYER_TAG).GetComponent<Player>();
        hp = player.Hp;
        mp = player.Mp;
        name = player.Name;

        hpText = hpTextObject.GetComponent<Text>();
        mpText = mpTextObject.GetComponent<Text>();
        atkText = atkTextObject.GetComponent<Text>();
        magText = magTextObject.GetComponent<Text>();
        defText = defTextObject.GetComponent<Text>();
        resText = resTextObject.GetComponent<Text>();

        hpSlider = hpSliderObject.GetComponent<Slider>();
        mpSlider = mpSliderObject.GetComponent<Slider>();

        InitActions();

        selectedAction = null;
    }

    void Update()
    {
        hpSlider.maxValue = hpMax + buffs.hpMax;
        hpSlider.value = hp;
        mpSlider.maxValue = mpMax + buffs.mpMax;
        mpSlider.value = mp;
        hpText.text = hp + "/" + (int) (hpMax + buffs.hpMax);
        mpText.text = mp + "/" + (int) (mpMax + buffs.mpMax);
        atkText.text = "ATK " + (int) (atk + buffs.atk);
        magText.text = "MAG " + (int) (mag + buffs.mag);
        defText.text = "DEF " + (int) (def + buffs.def);
        resText.text = "RES " + (int) (res + buffs.res);
    }

    //______________________________________

    #region buttons functions

    public void SelectAttackAction()
    {
        this.selectedAction = attack;
    }

    public void SelectGuardAction()
    {
        this.selectedAction = guard;
    }

    public void SelectFireAction()
    {
        this.selectedAction = fire;
    }

    public void SelectIceAction()
    {
        this.selectedAction = ice;
    }

    public void SelectThunderAction()
    {
        this.selectedAction = thunder;
    }

    public void SelectHealAction()
    {
        this.selectedAction = heal;
    }

    public void SelectConcentrationAction()
    {
        this.selectedAction = concentration;
    }

    #endregion


    #region over buttons actions

    public void OverAttackAction()
    {
        battleSystem.descriptionText.text = attack.desc;
    }

    public void OverGuardAction()
    {
        battleSystem.descriptionText.text = guard.desc;
    }

    public void OverFireAction()
    {
        battleSystem.descriptionText.text = fire.desc;
    }

    public void OverIceAction()
    {
        battleSystem.descriptionText.text = ice.desc;
    }

    public void OverThunderAction()
    {
        battleSystem.descriptionText.text = thunder.desc;
    }

    public void OverHealAction()
    {
        battleSystem.descriptionText.text = heal.desc;
    }

    public void OverConcentrationAction()
    {
        battleSystem.descriptionText.text = concentration.desc;
    }

    public void OverReturn()
    {
        battleSystem.descriptionText.text = "Return to previous menu";
    }

    public void OverMagic()
    {
        battleSystem.descriptionText.text = "Choose a magic spell to cast";
    }

    #endregion
}