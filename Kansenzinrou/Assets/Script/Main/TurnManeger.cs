﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                        MM.LogOut(Turn.ToString() + "表を更新", false);
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
                        MM.LogOut(Turn + "情勢イベント設定", false);
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
                        MM.LogOut(Turn + "感染状態表示", false);
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
                        MM.LogOut(Turn + "給料配布", false);
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
                        MM.LogOut(Turn + "仕入れ値リセット", false);
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
                        MM.LogOut(Turn + "仕入れ開始", false);
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
                        MM.LogOut(Turn + "仕入れ中（最後に1回呼び出される", false);
                        
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
                        MM.LogOut(Turn + "仕入れ終了", false);
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
                        MM.LogOut(Turn + "取引開始", false);
                        BusinessSW = true;
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
                        NowTime = Timer;//情勢イベントの効果を元に戻す
                        MM.LogOut(Turn + "情勢イベント削除", false);
                        IA.NewsOFF();
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
                        MM.LogOut(Turn + "全行程終了", false);
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
                        MM.LogOut(Turn + "敗北勝利判定", false);
                        IA.ShortageOfSupplies();//物資不足での死亡判定
                        IA.InfectionDeath();//感染での死亡判定
                        //死者が出ていた場合、取引ができなくなる、仕入れもできなくなる、すべての値が０になる

                        if (Turn >= 6) feadSC.fade("Result");//6ターン目ならゲーム終了

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
