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
    Config.Stage Stage;


    // Start is called before the first frame update
    void Start()
    {
        Turn = 1;
        UIM = GetComponent<UIManger>();
        IA = GetComponent<IventAll>();
        MM = GetComponent<MainManeger>();
        Player = MM.Player;
        Stage = Config.Stage.待機;//0が入っている
    }

    // Update is called once per frame
    void Update()
    {/*
            public enum Stage
    {
        待機 = 0,
        表更新 = 1,
        情勢イベント表示  = 2,
        感染状態表示  = 3,
        情勢イベント  = 4,
        給料配布  = 5,
        仕入れを0にする  = 6,
        仕入れ時間開始  = 7,
        仕入れ中  = 8,
        仕入れ終了  = 9,
        取引  = 10,
        全ターン終了  = 11,
        判定  = 12,
    }*/
        if (MM.FirstSet)//初期設定がすべて完了していたら
            Debug.Log(Turn + "ターン目開始");
        {

            //表更新
            UIM.TableUpdate();

            //情勢イベント表示
            UIM.NewsDisplay(true);//trueなため確定で感染症発見が表示される

            //感染状態表示
            UIM.InfectionDisplay();

            //給料配布
            IA.Salary();

            //仕入れを0にする
            IA.PurchasingRiset();

            //1：30秒間の仕入れ時間
            IA.TimerON();//カウントダウン始め
            PurchasingTime = true;

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



            Turn += 1;
        }
    }
}
