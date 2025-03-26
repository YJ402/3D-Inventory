using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUI : BaseUI
{
    public Button backButton;

    protected override void AddListener()
    {
        base.AddListener();

        backButton.onClick.AddListener(() => uiManager.ChangeCurrentUI(UIName.MainMeunu));
    }
}
