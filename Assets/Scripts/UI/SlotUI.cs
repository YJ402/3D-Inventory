using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerClickHandler
{
    public int slotIndex;

    public ItemSO item;
    public bool isIn = false;
    public Image icon;

    public TextMeshProUGUI countBox;
    public int count = 0;
    public bool isFull;

    public Image equipImage;
    public bool isEquipped;

    public void Init(int i)
    {
        slotIndex = i;
    }

    public void SetItem(ItemSO getItem, int wantCount)
    {
        // 들어온 아이템과 갯수 정보에 맞게 슬롯 세팅.
        if (wantCount > 0)
        {
            item = getItem;
            isIn = true;
            count = wantCount;
            SetCount(count);
            icon.sprite = item.icon;
            icon.color = Color.white;
            if (count == item.maxStack)
            {
                isFull = true;
            }
            else
            {
                isFull = false;
            }
        }
        else
        {
            item = null;
            isIn = false;
            count = 0;
            SetCount(count);
            icon.sprite = null;
            icon.color = new Color(0, 0, 0, 0);
            isFull = false;
        }
    }

    private void SetCount(int value)
    {
        if (value > 1)
        {
            countBox.text = value.ToString();
            countBox.gameObject.SetActive(true);
        }
        else
        {
            countBox.gameObject.SetActive(false);
        }
    }

    public void Equip()
    {
        isEquipped = true;
        equipImage.gameObject.SetActive(true);
        GameManager.Instance.character.characterEquip.Equip(item);
    }

    public void UnEquip()
    {
        isEquipped = false;
        equipImage.gameObject.SetActive(false);
        GameManager.Instance.character.characterEquip.UnEquip(item);
    }

    private void UseItem()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            Debug.Log("더블 클릭 감지");
            DoubleClickEvent();
        }
    }

    private void DoubleClickEvent()
    {
        if (item.itemType == ItemType.Equipment)
        {
            if (isEquipped)
            {
                (GameManager.Instance.uiManager.dict[UIName.InventoryUI] as InventoryUI).UnEquip(slotIndex, item);
            }
            else
            {
                (GameManager.Instance.uiManager.dict[UIName.InventoryUI] as InventoryUI).Equip(slotIndex, item);
            }
        }
        else if (item.itemType == ItemType.Consumable)
        {

        }
    }
}
