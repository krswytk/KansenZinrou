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
    private float TimerCount = 0;
    private bool[] TimerSw;

    private void Start()
    {
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        UIM = GameObject.Find("Maneger").GetComponent<UIManger>();
        FO = GameObject.Find("Maneger").GetComponent<FildObject>();
        Player = MM.Player;
        
        FO.TimerText.text = Timer.ToString("f0");
        FO.TimerAll.SetActive(false);//タイマー表記を隠す
        FO.PCR.SetActive(false);//PCR用の表示を非表示に
        PurchasingOFF();//仕入れボタンを非表示に

        TimerSw = new bool[11];
        TimerSwOFF();//10秒カウント初期化用
        FO.IbentAll.SetActive(false);//情勢イベントボックスを表示

    }
    private void Update()
    {

        if (sw)
        {
            if (ssw == false)
            {
                ssw = true;//一度のみ呼び出すためのスイッチ
                Timer = 0;//Timerの初期化
                FO.TimerAll.SetActive(true);//タイマー関係全表示
                Debug.Log("仕入れタイマースタート");
                TimerSwOFF();
            }//タイマー初回起動時

            Timer += Time.deltaTime;
            FO.TimerText.text = ((int)FirstNumber.仕入れ時間 - Timer).ToString("f0");

            if(((int)FirstNumber.仕入れ時間 - Timer) <= 10){
                switch((int)FirstNumber.仕入れ時間 - Timer)
                {
                    case 10:
                        if (TimerSw[0])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 9:
                        if (TimerSw[1])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 8:
                        if (TimerSw[2])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 7:
                        if (TimerSw[3])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 6:
                        if (TimerSw[4])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 5:
                        if (TimerSw[5])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 4:
                        if (TimerSw[6])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 3:
                        if (TimerSw[7])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 2:
                        if (TimerSw[8])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 1:
                        if (TimerSw[9])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                    case 0:
                        if (TimerSw[10])
                        {
                            MM.PlaySE(5);
                            TimerSw[0] = false;
                        }
                        break;
                }
            }

            if ((Timer - TimerCount) > (int)FirstNumber.仕入れ時間)
            {
                sw = false;//制限時間以上ならカウント終了
                ssw = false;
                FO.TimerAll.SetActive(false);//タイマー表記を隠す
                Timer = 0;
                FO.TimerText.text = Timer.ToString("f0");
                Debug.Log("仕入れタイマー終了");
            }
        }
    }
    public void Salary()//お給料
    {
        int num;
        if (Player[0].GetDeath() == false)
        {
            num = Player[0].GetMoney();
            num += (int)SalaryNumber.薬剤師給料;
            Player[0].SetMoney(num);
        }
        if (Player[1].GetDeath() == false)
        {
            num = Player[1].GetMoney();
            num += (int)SalaryNumber.食べ物屋給料;
            Player[1].SetMoney(num);
        }
        if (Player[2].GetDeath() == false)
        {
            num = Player[2].GetMoney();
            num += (int)SalaryNumber.水屋給料;
            Player[2].SetMoney(num);
        }
        if (Player[3].GetDeath() == false)
        {
            num = Player[3].GetMoney();
            num += (int)SalaryNumber.道具屋給料;
            Player[3].SetMoney(num);
        }

        UIM.TableUpdate();
        Debug.Log("給料を全員に配布");
    }

    public void TimerON()//制限時間のタイマー計測を始める　
    {
        sw = true;
        MM.LogOut("仕入れタイマースイッチ起動", false);
        Debug.Log("仕入れタイマースイッチ起動");
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
        Debug.Log("仕入れ数を0にリセット");
    }

    public void AllSuppliesMinus()//物資を-1する
    {
        for (int i = 0; i < Player.Length; i++)
        {
            Player[i].AllSuppliesMinus();
        }
        Debug.Log("全員の全物資を-1した。");
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
            FO.IbentAll.SetActive(true);//情勢イベントボックスを表示

            switch (n)
            {
                case 0:
                    now = news.発見;
                    //効果特になし
                    break;
                case 1:
                    now = news.クラスター;
                    MainManeger.Infectionprobability = (int)newsNumber.感染確率;//感染確率
                    break;
                case 2:
                    now = news.給付金;
                    for (int i = 0; i < Player.Length; i++)
                    {
                        if (Player[i].GetDeath() == false)//プレイヤーが生存していたら
                        {
                            num = Player[i].GetMoney();//現在の金額を収納
                            num += (int)newsNumber.給付金額;//給付金額をプラス
                            Player[i].SetMoney(num);//それを反映
                        }
                    }
                    break;
                case 3:
                    now = news.変異;
                    MainManeger.InfectionStage = (int)newsNumber.感染増加;//感染確率
                    break;
                case 4:
                    now = news.体調不良;
                    num = RandomDice.DiceRoll(4)-1;//0-3が入る
                    UIM.InfectionIndication(num);
                    FO.PCR.SetActive(true);//ゲームオブジェクトPCRを表示
                    //Invoke("OFFPCR", 3.5f);//3.5秒後に表示を消す
                    break;
                case 5:
                    now = news.支援;
                    MainManeger.InfectionControl = (int)newsNumber.感染対策;//感染確率
                    break;
                case 6:
                    now = news.医療崩壊;
                    MainManeger.DrugPurchaseRestrictions = (int)newsNumber.薬最大数;//薬仕入れ上限
                    break;
            }
            UIM.NewsDisplay(now);//選択された情勢イベントをテキストとして出力させる
            MM.LogOut(now.ToString(), false);
            MM.PlaySE(4);
            Debug.Log(now + "で情勢イベント内容決定");
        }
        else
        {
            Debug.LogError("Cord_301-情勢イベント選択でエラー");
        }
    }

    public void NewsOFF()//情勢イベントの効果を打ち消す
    {
        FO.IbentAll.SetActive(false);//情勢イベントボックスを表示
        switch (now)
        {
            case news.発見:
                //特になし
                break;
            case news.クラスター:
                MainManeger.Infectionprobability = (int)FirstNumber.感染確率;//感染確率
                break;
            case news.給付金:
                //特になし
                break;
            case news.変異:
                MainManeger.InfectionStage = (int)FirstNumber.感染増加;//感染した際の増加率
                break;
            case news.体調不良:
                FO.PCR.SetActive(false);//ゲームオブジェクトPCRを非表示
                //特になし
                break;
            case news.支援:
                MainManeger.InfectionControl = (int)FirstNumber.感染対策;//感染対策に必要な費用
                break;
            case news.医療崩壊:
                MainManeger.DrugPurchaseRestrictions = (int)FirstNumber.薬最大数;//薬仕入れ上限
                break;
            default:
                Debug.LogError("Cord_302-情勢イベント取り消しでエラー");
                break;
        }
        now = news.何もない;
        Debug.Log("情勢イベント内容打ち消し");
    }
    
    public void PCROFF()
    {
        FO.PCR.SetActive(false);//ゲームオブジェクトPCRを非表示に戻す
        Debug.Log("PCRを非表示");
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
        Debug.Log("全プレイヤーの薬を使用");
    }
    public void Countermeasures()//全プレイヤーの感染対策をOFFにする
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
                Player[i].SetFood(0);
                Player[i].SetWater(0);
                Player[i].SetTool(0);
                Player[i].SetMoney(0);
                Player[i].SetDeath(true);//死亡判定
                MM.PlaySE(1);
                MM.LogOut(Player[i].GetName() + "が物資不足で死亡", true);
                Debug.Log(Player[i].GetName() + "が物資不足で死亡");
            }
        }
    }
    public void InfectionDeath ()//感染での死亡
    {
        for (int i = 0; i < Player.Length; i++)
        {
            if (Player[i].Getinfection() > (int)FirstNumber.感染死亡)//感染が死亡ラインを越えていたら
            {
                Player[i].SetFood(0);
                Player[i].SetWater(0);
                Player[i].SetTool(0);
                Player[i].SetMoney(0);//金を0にすれば実質仕入れが不可能になる
                Player[i].SetDeath(true);//死亡判定
                MM.PlaySE(1);
                MM.LogOut(Player[i].GetName() + "が感染により死亡", true);
                Debug.Log(Player[i].GetName() + "が感染により死亡");
            }
        }
    }

    public void PurchasingON()//仕入れボタンをすべて表示
    {
        for(int i = 0;i< FO.PurchasingGroup.GetLength(0); i++)
        {
            for (int l = 0; l < FO.PurchasingGroup.GetLength(1); l++)
            {
                FO.PurchasingGroup[i,l].SetActive(true);
            }
        }
        MM.LogOut("仕入れボタンを表示", false);
        Debug.Log("仕入れボタンを表示");
    }
    public void PurchasingOFF()//仕入れボタンをすべて非表示
    {
        for (int i = 0; i < FO.PurchasingGroup.GetLength(0); i++)
        {
            for (int l = 0; l < FO.PurchasingGroup.GetLength(1); l++)
            {
                FO.PurchasingGroup[i, l].SetActive(false);
            }
        }
        MM.LogOut("仕入れボタンを非表示", false);
        Debug.Log("仕入れボタンを非表示");
    }
    public void BusinessGroupON(int T)//購入ボタンをすべて表示
    {
        for (int i = 0; i < FO.BusinessGroup.GetLength(1); i++)
        {
            FO.BusinessGroup[T, i].SetActive(true);
        }
        MM.LogOut(T.ToString() + "の購入を表示", false);
        Debug.Log(T.ToString() + "の購入を表示");
    }
    public void BusinessGroupOFF(int T)//購入ボタンをすべて非表示
    {
        for (int i = 0; i < FO.BusinessGroup.GetLength(1); i++)
        {
            FO.BusinessGroup[T, i].SetActive(false);
        }
        MM.LogOut(T.ToString() + "の購入を非表示", false);
        Debug.Log(T.ToString() + "の購入を非表示");
    }
    public void TimerSwOFF()//10秒カウント初期化用CountermeasuresMask
    {
        for (int i = 0; i < TimerSw.Length; i++)
        {
            TimerSw[i] = true;
        }
        MM.LogOut("仕入れタイマー10秒用初期化", false);
        Debug.Log("仕入れタイマー10秒用初期化");
    }
    public void CountermeasuresMaskOFF()//感染対策適応をすべて非表示
    {
        for (int i = 0; i < FO.CountermeasuresMask.GetLength(0); i++)
        {
            FO.CountermeasuresMask[i].SetActive(false);
        }
        MM.LogOut("感染対策適応を非表示", false);
        Debug.Log("感染対策適応を非表示");
    }
}
