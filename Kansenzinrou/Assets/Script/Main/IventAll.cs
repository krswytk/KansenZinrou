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
    private bool ssw = false;//タイマーに使用


    private float Timer;
    private float TimerCount;

    private void Start()
    {
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        UIM = GameObject.Find("Maneger").GetComponent<UIManger>();
        FO = GameObject.Find("Maneger").GetComponent<FildObject>();
        Player = MM.Player;

        Timer = 0;
        FO.TimerText.text = "残り時間:" + Timer.ToString("f0");

        FO.PCR.SetActive(false);//PCR用の表示を非表示に
        PurchasingOFF();//仕入れボタンを非表示に
    }
    private void Update()
    {
        Timer += Time.deltaTime;

        if (sw)
        {
            if (ssw == false) { TimerCount = Timer; ssw = true; }//タイマー初回起動時
            FO.TimerText.text = "残り時間:" + ((int)FirstNumber.仕入れ時間- (Timer - TimerCount)).ToString("f0");
            if ((Timer - TimerCount) > (int)FirstNumber.仕入れ時間)
            {
                sw = false;//制限時間以上ならカウント終了
                ssw = false;
                Timer = 0;
                FO.TimerText.text = "残り時間:" + Timer.ToString("f0");
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

    public void TimerON()//制限時間のタイマー計測を始める　
    {
        sw = true;
    }

    public bool GetTimerSW()//現在タイマーが作動中か判定　
    {
        return sw;//タイマーが作動中ならtrueが返る
    }

    public void PurchasingRiset()//仕入れ数を0にリセットする　
    {
        for(int i = 0; i < Player.Length; i++)
        {
            Player[i].SetPurchasing(0);
        }
    }

    public void AllSuppliesMinus()//物資を-1する
    {
        for (int i = 0; i < Player.Length; i++)
        {
            Player[i].AllSuppliesMinus();
        }
    }

    private news now = news.何もない;//現在の情勢イベントを格納しておく
    public void NewsON(bool T)//情勢イベントの選択、効果の繁栄を行う
    {
        if (now == news.何もない)//情勢イベントが打ち消されているかの確認
        {
            int n;
            n = RandomDice.DiceRoll(6);//1-6が入る
            if (T) n = 0;//最初のターンなら
            int num = 0;//各処理で使う変数

            switch (n)
            {
                case 0:
                    now = news.発見;
                    //効果特になし
                    break;
                case 1:
                    now = news.クラスター;
                    MM.Infectionprobability = (int)newsNumber.感染確率;//感染確率
                    break;
                case 2:
                    now = news.給付金;
                    for (int i = 0; i < Player.Length; i++)
                    {
                        num = Player[i].GetMoney();//現在の金額を収納
                        num += (int)newsNumber.給付金額;//給付金額をプラス
                        Player[i].SetMoney(num);//それを反映
                    }
                    break;
                case 3:
                    now = news.変異;
                    MM.InfectionStage = (int)newsNumber.感染増加;//感染確率
                    break;
                case 4:
                    now = news.体調不良;
                    num = RandomDice.DiceRoll(4)-1;//0-3が入る
                    UIM.InfectionIndication(num);
                    FO.PCR.SetActive(true);//ゲームオブジェクトPCRを表示
                    Invoke("OFFPCR", 3.5f);
                    break;
                case 5:
                    now = news.支援;
                    MM.InfectionControl = (int)newsNumber.感染対策;//感染確率
                    break;
                case 6:
                    now = news.医療崩壊;
                    MM.DrugPurchaseRestrictions = (int)newsNumber.薬最大数;//薬仕入れ上限
                    break;
            }
            UIM.NewsDisplay(now);//選択された情勢イベントをテキストとして出力させる
        }
        else
        {
            Debug.LogError("Cord_301-情勢イベント選択でエラー");
        }
    }

    public void NewsOFF()//情勢イベントの効果を打ち消す
    {
        switch (now)
        {
            case news.発見:
                //特になし
                break;
            case news.クラスター:
                MM.Infectionprobability = (int)FirstNumber.感染確率;//感染確率
                break;
            case news.給付金:
                //特になし
                break;
            case news.変異:
                MM.InfectionStage = (int)FirstNumber.感染増加;//感染した際の増加率
                break;
            case news.体調不良:
                //特になし
                break;
            case news.支援:
                MM.InfectionControl = (int)FirstNumber.感染対策;//感染対策に必要な費用
                break;
            case news.医療崩壊:
                MM.DrugPurchaseRestrictions = (int)FirstNumber.薬最大数;//薬仕入れ上限
                break;
            default:
                Debug.LogError("Cord_302-情勢イベント取り消しでエラー");
                break;
        }
        now = news.何もない;
    }

    public void PurchasingON()
    {
        FO.PurchasingGroup.SetActive(true);
    }
    public void PurchasingOFF()
    {
        FO.PurchasingGroup.SetActive(false);
    }
    public void OFFPCR()
    {
        FO.PCR.SetActive(false);//ゲームオブジェクトPCRを非表示に戻す
    }

    public void NextStage()//ターンマネージャーを一定時間後に次の段階に進めるための関数
    {

    }

    public void MedicineConsumption()//全プレイヤーの薬を使用　使用した分感染率を下げる
    {
        int num;
        int c;
        for(int i = 0; i < Player.Length; i++)
        {
            num = Player[i].GetMedicine();//薬数を格納
            c = Player[i].Getinfection();//感染度を格納
            Player[i].SetMedicine(0);//薬数を0に
            c = c - num;
            if (c < 0) c = 0;
            Player[i].Setinfection(c);
        }
    }
    public void Countermeasures()
    {
        for (int i = 0; i < Player.Length; i++)
        {
            Player[i].SetCountermeasures(false);
        }
    }
    public void ShortageOfSupplies()//物資不足での死亡判定
    {
        for (int i = 0; i < Player.Length; i++)
        {
            if (Player[i].GetFood() < 0 || Player[i].GetWater() < 0 || Player[i].GetTool() < 0 )//どれか1つが0未満なら
            {
                Player[i].SetFood(-1);
                Player[i].SetWater(-1);
                Player[i].SetTool(-1);
                Player[i].SetDeath(true);//死亡判定
            }
        }
    }
    public void InfectionDeath ()//感染での死亡
    {
        for (int i = 0; i < Player.Length; i++)
        {
            if (Player[i].Getinfection() > (int)FirstNumber.感染死亡)//感染が死亡ラインを越えていたら
            {
                Player[i].SetDeath(true);//死亡判定
            }
        }
    }
}
