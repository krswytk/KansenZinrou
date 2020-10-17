using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventAll : Config
{

    MainManeger MM;
    UIManger UIM;
    FildObject FO;
    Player[] Player;

    private bool sw = false;//タイマースタートのスイッチ　trueでスタート
    private float TimerCount;

    private void Start()
    {
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        UIM = GameObject.Find("Maneger").GetComponent<UIManger>();
        FO = GameObject.Find("Maneger").GetComponent<FildObject>();
        Player = MM.Player;

        TimerCount = 0;
        FO.TimerText.text = "残り時間:" + TimerCount.ToString("f0");
    }
    private void Update()
    {
        if (sw)
        {
            TimerCount += Time.deltaTime;
            FO.TimerText.text = "残り時間:" + TimerCount.ToString("f0");
            if (TimerCount > (int)FirstNumber.仕入れ時間)
            {
                sw = false;//制限時間以上ならカウント終了
                TimerCount = 0;
                FO.TimerText.text = "残り時間:" + TimerCount.ToString("f0");
            }
        }
    }
    public void Salary()//お給料
    {
        int num;
        num = Player[0].GetMoney();
        num += (int)SalaryNumber.薬剤師給料;
        Player[0].SetMoney(num);

        num = Player[1].GetMoney();
        num += (int)SalaryNumber.食べ物屋給料;
        Player[1].SetMoney(num);

        num = Player[2].GetMoney();
        num += (int)SalaryNumber.水屋給料;
        Player[2].SetMoney(num);

        num = Player[3].GetMoney();
        num += (int)SalaryNumber.道具屋給料;
        Player[3].SetMoney(num);

        UIM.TableUpdate();
    }

    public void TimerON()//お給料
    {
        sw = true;
    }
}
