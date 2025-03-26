using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterEquip :MonoBehaviour
{
    public Character character;
    //Dictionary<EquipmentBodyType, ItemSO> equippedBody;


    public float AddedAttackPower {  get; private set; }
    public float AddedDefense {  get; private set; }
    public float AddedMaxHealth {  get; private set; }
    public float AddedCritical {  get; private set; }

    public void Init(Character character)
    {
        this.character = character;
    }

    public void Equip(ItemSO item) // ĳ���Ϳ� ����, �������ͽ��� ����
    {
        //������ �������� Ȯ��
        //  O:���� �����ߴ� ������ ����
        //      
        //����(addded �߰�, ���� ���� �߰�)


        //if (equippedBody.ContainsKey(item.equipmentData.equipmentBodyType))
        //{
        //    // �������� ���� ����
        //    //Inventory.UnEquip(equippedBody[item.equipmentData.equipmentBodyType]); 
        //}

        //equippedBody.Add(item.equipmentData.equipmentBodyType, item);
        AddedAttackPower += item.equipmentData.attackPower;
        AddedDefense += item.equipmentData.defense;
        AddedMaxHealth += item.equipmentData.health;
        AddedCritical += item.equipmentData.critical;

        character.characterStatus.ChangeStat(AddedAttackPower, AddedDefense, AddedMaxHealth, AddedCritical);
    }

    public void UnEquip(ItemSO item) // ĳ���Ϳ��� ��� ����, �������ͽ��� ���� ����
    {

        //equippedBody.Remove(item.equipmentData.equipmentBodyType);
        AddedAttackPower -= item.equipmentData.attackPower;
        AddedDefense -= item.equipmentData.defense;
        AddedMaxHealth -= item.equipmentData.health;
        AddedCritical -= item.equipmentData.critical;

        character.characterStatus.ChangeStat(AddedAttackPower, AddedDefense, AddedMaxHealth, AddedCritical);
    }
}
