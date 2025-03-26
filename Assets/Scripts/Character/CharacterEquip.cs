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

    public void Equip(ItemSO item) // 캐릭터에 장착, 스테이터스에 영향
    {
        //장착된 부위인지 확인
        //  O:원래 장착했던 아이템 해제
        //      
        //장착(addded 추가, 장착 부위 추가)


        //if (equippedBody.ContainsKey(item.equipmentData.equipmentBodyType))
        //{
        //    // 장착중인 부위 해제
        //    //Inventory.UnEquip(equippedBody[item.equipmentData.equipmentBodyType]); 
        //}

        //equippedBody.Add(item.equipmentData.equipmentBodyType, item);
        AddedAttackPower += item.equipmentData.attackPower;
        AddedDefense += item.equipmentData.defense;
        AddedMaxHealth += item.equipmentData.health;
        AddedCritical += item.equipmentData.critical;

        character.characterStatus.ChangeStat(AddedAttackPower, AddedDefense, AddedMaxHealth, AddedCritical);
    }

    public void UnEquip(ItemSO item) // 캐릭터에서 장비 해제, 스테이터스에 영향 제거
    {

        //equippedBody.Remove(item.equipmentData.equipmentBodyType);
        AddedAttackPower -= item.equipmentData.attackPower;
        AddedDefense -= item.equipmentData.defense;
        AddedMaxHealth -= item.equipmentData.health;
        AddedCritical -= item.equipmentData.critical;

        character.characterStatus.ChangeStat(AddedAttackPower, AddedDefense, AddedMaxHealth, AddedCritical);
    }
}
