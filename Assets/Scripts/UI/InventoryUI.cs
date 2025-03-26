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

    public bool AddItem(ItemSO item) // �κ��丮�� ������ �ִ� ����
    {

        //���ð�������
        //  o: isfull �ƴϰ� �̸����� �� �ִ���.
        //      o:��� ���ߴ�.
        //      x:���ڸ� Ž���ؼ� ��� ���ߴ�.
        // ���� ������ �־�.

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
            Debug.Log("���ڸ��� ã�� �� �����ϴ�.");
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
            //� ���� �� ������ üũ. ������ �з��� set�ϰ�, �Ұ����� �з��� ���.
            int freeSpace = item.maxStack - slots[index].count - count;

            if (freeSpace >= 0)
            {
                slots[index].SetItem(item, slots[index].count + count);
                UpdateUI();
                return true;
            }
            else
            {
                slots[index].SetItem(item, item.maxStack);// ������ �з�
                UpdateUI();
                return AddItem(item, -freeSpace);   // �Ұ����� �з�
            }
        }
        else
        {
            Debug.Log($"���ڸ��� ã�� �� ���, {item.itemName} {count}���� ���� ���߽��ϴ�.");
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
            //������ �� ���� ����
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
