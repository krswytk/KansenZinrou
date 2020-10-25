using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countermeasures : MonoBehaviour//感染対策用のボタンスクリプト
{
    MainManeger MM;
    FildObject FO;
    BusinessALL BA;
    // Start is called before the first frame update
    void Start()
    {
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        FO = GameObject.Find("Maneger").GetComponent<FildObject>();
        BA = GameObject.Find("Maneger").GetComponent<BusinessALL>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        MM.Player[BA.GetTurn()].SetCountermeasures(true);//該当プレイヤーの感染対策をONにする
        FO.CountermeasuresMask[BA.GetTurn()].SetActive(true);
        FO.Countermeasures.SetActive(false);
        MM.PlaySE(0);
        Debug.Log(MM.Player[BA.GetTurn()].GetName() + "は感染対策を行いました。");
        /*
        int num = MM.Player[BA.GetTurn()].GetMoney();
        num -= MainManeger.InfectionControl;
        MM.Player[BA.GetTurn()].SetMoney(num);
        GameObject.Find("Maneger").GetComponent<UIManger>().TableUpdate();
        */
    }

    public void No()
    {
        FO.Countermeasures.SetActive(false);
        MM.PlaySE(3);
        Debug.Log(MM.Player[BA.GetTurn()].GetName() + "は感染対策を行いませんでした×");
    }
}
