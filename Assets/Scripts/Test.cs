using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<ItemSO> items;
    public void minusHP()
    {
        GameManager.Instance.character.characterStatus.TakeDamage(10);
        (GameManager.Instance.uiManager.dict[UIName.StatusUI]).UpdateUI();
    }

    public void GetRandomItem()
    {
        (GameManager.Instance.uiManager.dict[UIName.InventoryUI] as InventoryUI).AddItem(items[Random.Range(0, items.Count)]);
    }
}
