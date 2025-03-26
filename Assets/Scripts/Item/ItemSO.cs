using System;
using System.Collections;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumable, // ÇÇ
}
public enum EquipmentBodyType // Âø¿ë ºÎÀ§
{
    Weapon, 
    Armor,  
    Accessory 
}

[Serializable]
public class EquipmentData
{
    public EquipmentBodyType equipmentBodyType;
    public float attackPower;
    public float defense;
    public float health;
    [Range(0f,1f)]public float critical;
}

[Serializable]
public class ConsumableData
{
    public float healAmount;
}

[CreateAssetMenu(fileName = "newItem", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite icon;
    public bool canStack;
    public int maxStack;

    public EquipmentData equipmentData;
    public ConsumableData consumableData;
}
