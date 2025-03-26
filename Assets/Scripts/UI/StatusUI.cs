using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Animation;
using UnityEngine;

public enum StatType
{
    AttackPower,
    Defense,
    Health,
    Critical
}

public class StatusUI : InfoUI
{
    [SerializeField] private TextMeshProUGUI AttackPower;
    [SerializeField] private TextMeshProUGUI addedAttackPower;
    [SerializeField] private TextMeshProUGUI Defense;
    [SerializeField] private TextMeshProUGUI addedDefense;
    [SerializeField] private TextMeshProUGUI CurHealth;
    [SerializeField] private TextMeshProUGUI MaxHealth;
    [SerializeField] private TextMeshProUGUI addedMaxHealth;
    [SerializeField] private TextMeshProUGUI Critical;
    [SerializeField] private TextMeshProUGUI addedCritical;


    private CharacterStatus chaStat;
    private CharacterEquip chaEquip;

    public override void Init(UIManager uiManager, UIName uiName)
    {
        base.Init(uiManager, uiName);
        chaStat = GameManager.Instance.character.characterStatus;
        chaEquip = GameManager.Instance.character.characterEquip;
    }

    public override void UpdateUI()
    {
        AttackPower.text = chaStat.totalAttackPower.ToString();
        Defense.text = chaStat.totalDefense.ToString();
        CurHealth.text = chaStat.CurHealth.ToString();
        MaxHealth.text = chaStat.totalMaxHealth.ToString();
        Critical.text = (chaStat.totalCritical * 100).ToString() + "%";

        addedAttackPower.text = chaEquip.AddedAttackPower.ToString();
        addedDefense.text = chaEquip.AddedDefense.ToString();
        addedMaxHealth.text = chaEquip.AddedMaxHealth.ToString();
        addedCritical.text = (chaEquip.AddedCritical * 100).ToString() + "%";
    }
}


