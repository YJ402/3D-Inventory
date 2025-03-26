using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatus : MonoBehaviour
{
    private float attackPower;
    public float AttackPower => attackPower;
    private float defense;
    public float Defense => defense;
    private float maxHealth;
    public float MaxHealth => maxHealth;
    private float curHealth;
    public float CurHealth => curHealth;
    private float critical;
    public float Critical => critical;

    public float totalAttackPower {  get; private set; }
    public float totalDefense {  get; private set; }
    public float totalMaxHealth {  get; private set; }
    public float totalCritical {  get; private set; }

    private CharacterSO chaData;

    public void Init(CharacterSO data)
    {
        this.chaData = data;
    }

    private void Start()
    {
        attackPower = chaData.AttackPower;
        defense = chaData.Defense;
        maxHealth = chaData.MaxHealth;    
        curHealth = maxHealth;
        critical = chaData.Critical;

        totalAttackPower = attackPower;
        totalDefense = defense;
        totalMaxHealth = maxHealth;
        totalCritical = critical;
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;    
    }

    public void Heal(float value)
    {
        curHealth += value;
    }

    public void ChangeStat(float added1, float added2, float added3, float added4)
    {
        totalAttackPower = AttackPower + added1;
        totalDefense = Defense + added2;
        totalMaxHealth = maxHealth + added3;
        totalCritical = critical + added4;
    }
}