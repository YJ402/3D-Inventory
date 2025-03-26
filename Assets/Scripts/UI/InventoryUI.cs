using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class InventoryUI : InfoUI
{
    [SerializeField] private SlotUI SlotUIPref;
    [SerializeField] private Transform SlotsParent;
    [SerializeField] private TextMeshProUGUI invenMax;
    [SerializeField] private TextMeshProUGUI invenCount;

    List<SlotUI> slots = new();

    public float maxInventory = 20;

    Dictionary<EquipmentBodyType, int> equippedBody = new();

    public override void Init(UIManager uiManager, UIName uiName)
    {
        base.Init(uiManager, uiName);

        SlotUI slot;
        for (int i = 0; i < maxInventory; i++)
        {
            slot = Instantiate(SlotUIPref, SlotsParent, false);
            slot.Init(i);
            slots.Add(slot);
        }

        invenMax.text = maxInventory.ToString();
    }

    public override void UpdateUI()
    {
        int i = 0;  
        foreach (SlotUI slot in slots)
        {
            if(slot.isIn) i++; 
        }
        invenCount.text = i.ToString();
    }

    public bool AddItem(ItemSO item) // 인벤토리에 아이템 넣는 과정
    {

        //스택가능한지
        //  o: isfull 아니고 이름같은 애 있는지.
        //      o:얘로 정했다.
        //      x:빈자리 탐색해서 얘로 정했다.
        // 정한 애한테 넣어.

        int index = -1;

        if (item.canStack)
        {
            int j = FindSameSlotIndex(item);
            if (j >= 0 && !slots[j].isFull)
            {
                index = j;
            }
            else
            {
                index = FindEmptySlotIndex();
            }
        }
        else
        {
            index = FindEmptySlotIndex();
        }


        if (index >= 0)
        {
            slots[index].SetItem(item, slots[index].count + 1);
            UpdateUI();
            return true;
        }
        else
        {
            Debug.Log("빈자리를 찾을 수 없습니다.");
            return false;
        }
    }

    public bool AddItem(ItemSO item, int count)
    {
        int index = -1;

        if (item.canStack)
        {
            int j = FindSameSlotIndex(item);
            if (j >= 0 && !slots[j].isFull)
            {
                index = j;
            }
            else
            {
                index = FindEmptySlotIndex();
            }
        }
        else
        {
            index = FindEmptySlotIndex();
        }

        if (index >= 0)
        {
            //몇개 넣을 수 있을지 체크. 가능한 분량은 set하고, 불가능한 분량은 재귀.
            int freeSpace = item.maxStack - slots[index].count - count;

            if (freeSpace >= 0)
            {
                slots[index].SetItem(item, slots[index].count + count);
                UpdateUI();
                return true;
            }
            else
            {
                slots[index].SetItem(item, item.maxStack);// 가능한 분량
                UpdateUI();
                return AddItem(item, -freeSpace);   // 불가능한 분량
            }
        }
        else
        {
            Debug.Log($"빈자리를 찾을 수 없어서, {item.itemName} {count}개를 넣지 못했습니다.");
            return false;
        }
    }

    private int FindEmptySlotIndex()
    {
        foreach (SlotUI slot in slots)
        {
            if (!slot.isIn)
                return slot.slotIndex;
        }
        return -1;
    }

    private int FindSameSlotIndex(ItemSO item)
    {
        foreach (SlotUI slot in slots)
        {
            if (slot.item == item)
                return slot.slotIndex;
        }
        return -1;
    }

    public void Equip(int index, ItemSO item)
    {
        if (equippedBody.ContainsKey(item.equipmentData.equipmentBodyType))
        {
            //기존의 것 장착 해제
            UnEquip(equippedBody[item.equipmentData.equipmentBodyType], item);
        }

        equippedBody.Add(item.equipmentData.equipmentBodyType, index);
        slots[index].Equip();
    }

    public void UnEquip(int index, ItemSO item)
    {
        equippedBody.Remove(item.equipmentData.equipmentBodyType);
        slots[index].UnEquip();
    }
}
