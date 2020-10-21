using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManeger : MonoBehaviour
{
    private int Turn;
    UIManger UIM;
    MainManeger MM;
    IventAll IA;


    Player[] Player;


    private bool PurchasingTime = false;

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
                        Debug.Log(Turn + "ターン目開始");
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
                        //表更新
                        UIM.TableUpdate();
                        Debug.Log(Turn + "表を更新");
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
                        //情勢イベント表示
                        if (Turn == 1)
                        {
                            IA.NewsON(true);//trueなため確定で感染症発見が表示される
                        }
                        else
                        {
                            IA.NewsON(false);//falseなため6種類の中から表示される
                        }
                        Debug.Log(Turn + "情勢イベント設定");
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage)//一定時間経過したら
                    {
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
                        //感染状態表示
                        UIM.InfectionDisplay();
                        Debug.Log(Turn + "感染状態表示");
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
                        //給料配布
                        IA.Salary();
                        Debug.Log(Turn + "給料配布");
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
                        //仕入れを0にする
                        IA.PurchasingRiset();
                        Debug.Log(Turn + "仕入れ値リセット");
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
                        //1：30秒間の仕入れ時間
                        IA.TimerON();//カウントダウン始め
                        PurchasingTime = true;//仕入れをONに
                        IA.PurchasingON();//仕入れボタンを表示
                        Debug.Log(Turn + "仕入れ開始");
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

                        PurchasingTime = true;//仕入れを終わりにする
                        stage = Config.Stage.仕入れ終了;//次の段階に移行
                        Debug.Log(Turn + "仕入れ中（最後に1回呼び出される");
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
                        IA.PurchasingOFF();//仕入れボタンを非表示表示
                        Debug.Log(Turn + "仕入れ終了");
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
                        BusinessSW = true;
                        Debug.Log(Turn + "取引開始");
                    }
                    if ((Timer - NowTime) > (int)Config.FirstNumber.NextStage && BusinessSW == false)//一定時間経過したら
                    {
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
                        NowTime = Timer;                    //情勢イベントの効果を元に戻す
                        IA.NewsOFF();
                        Debug.Log(Turn + "情勢イベント削除");
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
                        IA.AllSuppliesMinus();//全物資-1
                        //薬品使用
                        //感染対策無効化
                        Debug.Log(Turn + "全行程終了");
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
                        Debug.Log(Turn + "敗北勝利判定");

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
}
