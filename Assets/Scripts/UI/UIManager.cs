using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<UIs> list;
    public Dictionary<UIName, BaseUI> dict = new();    

    public BaseUI currentUI;
    public UIName currentUIName;

    private void Start()
    {
        foreach (var item in list)
        {
            dict.Add(item.uiName, Instantiate(item.baseUI, gameObject.transform, false));
            dict[item.uiName].Init(this, item.uiName);
            //item.baseUI.Init(this, item.uiName);
        }

        // 메인 메뉴로 시작.
        currentUIName = UIName.MainMeunu;
        currentUI = dict[currentUIName];

        // 처음에 해당 없는 UI 전부 비활성화.
        foreach (var item in dict)
        {
            item.Value.gameObject.SetActive(currentUIName == item.Value.uiName);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        currentUI.UpdateUI();
    }

    public  void ChangeCurrentUI(UIName nextUI)
    {
        if (currentUIName != nextUI)
        {
            currentUI.Exit();

            currentUI = dict[nextUI];
            currentUIName = nextUI;

            currentUI.Enter();
        }
    }
}
