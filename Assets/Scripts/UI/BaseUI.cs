using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIName
{
    MainMeunu,
    InventoryUI,
    StatusUI
}

//public interface DefineUI
//{
//    private DefineUI 
//}

[Serializable]
public class UIs
{
    public BaseUI baseUI;
    public UIName uiName;
}

public abstract class BaseUI : MonoBehaviour
{
    [HideInInspector] public UIName uiName;
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager, UIName uiName)
    {
        this.uiManager = uiManager;
        this.uiName = uiName;

        AddListener();
    }

    public virtual void Enter()
    {
        gameObject.SetActive(true);
        UpdateUI();
    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }

    protected virtual void AddListener()
    {
    }

    public virtual void UpdateUI()
    {
    }
}
