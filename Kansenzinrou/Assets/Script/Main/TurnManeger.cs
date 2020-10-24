using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManeger : MonoBehaviour
{
    private int Turn;
    UIManger UIM;
    MainManeger MM;
    IventAll IA;


    Player[] Player;
    

    Config.Stage stage;

    private bool TSW;
    private float Timer;
    private float NowTime;

    private bool BusinessSW;

    // Start is called before the first frame update
    void Start()
    {
        Turn = 1;
        UIM = GetComponent<UIManger>();
        IA = GetComponent<IventAll>();
        MM = GetComponent<MainManeger>();
        Player = MM.Player;
        stage = Config.Stage.待機;//0が入っている
        TSW = true;
        Timer = 0;
        BusinessSW = false;
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;

        if (MM.FirstSet)//初期設定がすべて完了していたら
        {
            switch (stage)
            {
                case Config.Stage.待機:
                    ////////////////////////////////////////////////
                    if(TSW){
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn.ToString() + "ターン目開始", false);
                        Debug.Log(Turn.ToString() + "ターン目開始");
                        IA.CountermeasuresMaskOFF();
                    }
                    if((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.表更新;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.表更新:               
                    ///////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn.ToString() + "ターン目表を更新", false);
                        Debug.Log(Turn.ToString() + "ターン目表を更新");
                        //表更新
                        UIM.TableUpdate();
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.情勢イベント表示;//次のステージへ
                    }
                    ////////////////////////////////////////////////

                    break;

                case Config.Stage.情勢イベント表示://ここでガチャ+効果の反映を行う               
                    //////////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目情勢イベント設定", false);
                        Debug.Log(Turn.ToString() + "ターン目情勢イベント設定");
                        //情勢イベント表示
                        if (Turn == 1)
                        {
                            IA.NewsON(true);//trueなため確定で感染症発見が表示される
                        }
                        else
                        {
                            IA.NewsON(false);//falseなため6種類の中から表示される
                        }
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        IA.PCROFF();//PCRだった場合表示を消す
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.感染状態表示;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.感染状態表示:            
                    /////////////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目感染状態表示", false);
                        Debug.Log(Turn.ToString() + "ターン目感染状態表示");
                        //感染状態表示
                        UIM.InfectionDisplay();
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.給料配布;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.給料配布:
                    /////////////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目給料配布", false);
                        Debug.Log(Turn.ToString() + "ターン目給料配布");
                        //給料配布
                        IA.Salary();
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.仕入れを0にする;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.仕入れを0にする:
                    /////////////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目仕入れ値リセット", false);
                        Debug.Log(Turn.ToString() + "ターン目仕入れ値リセット");
                        //仕入れを0にする
                        IA.PurchasingRiset();
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.仕入れ時間開始;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.仕入れ時間開始:
                    ////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目仕入れ開始", false);
                        Debug.Log(Turn.ToString() + "ターン目仕入れ開始");
                        //1：30秒間の仕入れ時間
                        IA.TimerON();//カウントダウン始め
                        IA.PurchasingON();//仕入れボタンを表示
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.仕入れ中;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.仕入れ中:
                    ////////////////////////////////////////////////
                    if (IA.GetTimerSW() == false)
                    {//タイマーが終わっていたら
                        MM.LogOut(Turn + "ターン目仕入れ中（最後に1回呼び出される", false);
                        Debug.Log(Turn.ToString() + "ターン目仕入れ中（最後に1回呼び出される");

                        stage = Config.Stage.仕入れ終了;//次の段階に移行
                    }
                    else//仕入れ中なら
                    {
                        //ボタン操作が可能
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.仕入れ終了:
                    ////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目仕入れ終了", false);
                        Debug.Log(Turn.ToString() + "ターン目仕入れ終了");
                        IA.PurchasingOFF();//仕入れボタンを非表示表示
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.取引;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.取引:
                    ////////////////////////////////////////////////                    
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目取引開始", false);
                        Debug.Log(Turn.ToString() + "ターン目取引開始");
                        BusinessSW = true;
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage && BusinessSW == false)//一定時間経過したら
                    {
                        UIM.MaskOFF();//全員の感染対策を無効
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.情勢イベント削除;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;


                case Config.Stage.情勢イベント削除:
                    ////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目情勢イベント削除", false);
                        Debug.Log(Turn.ToString() + "ターン目情勢イベント削除");
                        IA.NewsOFF();// 情勢イベントの効果を元に戻す
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.全ターン終了;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;


                case Config.Stage.全ターン終了:
                    ////////////////////////////////////////////////
                    if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        CountInfection();//毎ターンの感染者数を格納
                        MM.LogOut(Turn + "ターン目全行程終了", false);
                        Debug.Log(Turn.ToString() + "ターン目全行程終了");
                        IA.AllSuppliesMinus();//全物資-1
                        IA.MedicineConsumption();//薬品使用
                        IA.Countermeasures();//感染対策無効化
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.判定;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                case Config.Stage.判定:
                    ////////////////////////////////////////////////                    
                    ///if (TSW)
                    {
                        TSW = false;//一回のみ呼び出す処理
                        NowTime = Timer;
                        MM.LogOut(Turn + "ターン目敗北勝利判定", false);
                        IA.ShortageOfSupplies();//物資不足での死亡判定
                        IA.InfectionDeath();//感染での死亡判定
                        //死者が出ていた場合、取引ができなくなる、仕入れもできなくなる、すべての値が０になる

                        if (Turn >= 6)
                        {
                            SceneManager.sceneLoaded += CountInfectionGameSceneLoaded;
                            feadSC.fade("Result");//6ターン目ならゲーム終了
                        }

                        Turn += 1;

                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
                        TSW = true;//スイッチを起動可能状態に戻す
                        stage = Config.Stage.待機;//次のステージへ
                    }
                    ////////////////////////////////////////////////
                    break;

                default:
                    Debug.LogError("Cord_401-ターン処理にて想定外のステージが生成されています");
                    break;
            }








            //仕入れフェイズ　ここまで///////////////

            //行動フェイズ///////////////

            //初手の人を決定

            //その人から順に取引

            //購入した場合感染ガチャ

            //もしくは悪化ガチャ

            //全プレイヤー終了後に全物資-1

            //行動フェイズここまで///////////////

            //判定フェイズ///////////////

            //いずれかの物資が0未満のプレイヤーは死亡(敗北)してしまう
            //感染状態が3以上のプレイヤーは死亡(敗北)してしまう
            //6ターン終了時に上記を満たしていないプレイヤーは勝利する

            //判定フェイズここまで///////////////


        }
    }

    public bool GetBusinessSW()
    {
        return BusinessSW;
    }
    public void SetBusinessSW()
    {
        BusinessSW = false;
    }
    public int GetTurn()
    {
        return Turn;
    }

    public int[] InfectionCounter = new int[6];
    public void CountInfection()//感染対策適応をすべて非表示
    {
        int c = 0;
        for (int i = 0; i < MM.Player.Length; i++)
        {
            if(Player[i].Getinfection() != 0)
            {
                c++;
            }
        }
        InfectionCounter[Turn - 1] = c;
        MM.LogOut(Turn + "ターン目の感染者数は" + c + "人です。", true);
        Debug.Log("感染者数をカウント");
    }


    private void CountInfectionGameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        for (int i = 0; i < MM.Player.Length; i++)
        {

            Point.setInfectedPerson(InfectionCounter[i], i + 1);
        }
        SceneManager.sceneLoaded -= CountInfectionGameSceneLoaded;
    }
    /*
    private static int[] m_InfectedPerson = new int[6];
    public static void setInfectedPerson(int InfectedPerson, int date)
    {
        m_InfectedPerson[date - 1] = InfectedPerson;
    }
    */

}
