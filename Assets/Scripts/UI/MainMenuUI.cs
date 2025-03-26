using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : BaseUI
{
    public Button InventoryButton;
    public Button StatButton;

    protected override void AddListener()
    {
        base.AddListener();

        InventoryButton.onClick.AddListener(() => uiManager.ChangeCurrentUI(UIName.InventoryUI));
        StatButton.onClick.AddListener(() => uiManager.ChangeCurrentUI(UIName.StatusUI));
    }
}
