﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Hierachyから各オブジェクトを検索取得を行う
public class FildObject : Config
{
    [HideInInspector] public GameObject[,] UIOB;//各数値のprivate GameObject 
    [HideInInspector] public Text[,] UIOBText;//各数値のprivate Text 
    /*
     1次元　0 薬局　1 食べ物 　2 水屋 　3 道具
     2次元　0 食料　1 飲料　2 道具　3 お金　3 仕入れ　5 売値　6対策 
     */

    [HideInInspector] public GameObject Ibent;//情勢イベントprivate GameObject 
    [HideInInspector] public Text Ibenttext;//情勢イベントprivate Text 

    [HideInInspector] public GameObject[] Infection;//情勢イベントprivate GameObject 4人分？
    [HideInInspector] public Text[] InfectionText;//情勢イベントprivate Text 


    [HideInInspector] public GameObject Timer;//時間表示のオブジェクト
    [HideInInspector] public Text TimerText;//時間表示のタイマー
    

    MainManeger MM;

    FirstNumber FN;
    // Start is called before the first frame update
    void Awake()
    {
        MM = GetComponent<MainManeger>();
        
        /////////////////////////////////////////////////////////////////////////////
        UIOB = new GameObject[MM.PlayerNumber, 7];
        UIOBText = new Text[MM.PlayerNumber, 7];
        UIOB[0, 0] = GameObject.Find("INFECTIONFood");//薬局の食料
        UIOB[0, 1] = GameObject.Find("INFECTIONWater");//薬局の飲料
        UIOB[0, 2] = GameObject.Find("INFECTIONTool");//薬局の道具
        UIOB[0, 3] = GameObject.Find("INFECTIONMoney");//薬局のお金
        UIOB[0, 4] = GameObject.Find("INFECTIONPurchasing");//薬局の仕入
        UIOB[0, 5] = GameObject.Find("INFECTIONSell");//薬局の売値
        UIOB[0, 6] = GameObject.Find("INFECTIONCountermeasures");//薬局の対策

        UIOB[1, 0] = GameObject.Find("FOODFood");//食べ物屋の食料
        UIOB[1, 1] = GameObject.Find("FOODWater");//食べ物屋の飲料
        UIOB[1, 2] = GameObject.Find("FOODTool");//食べ物屋の道具
        UIOB[1, 3] = GameObject.Find("FOODMoney");//食べ物屋のお金
        UIOB[1, 4] = GameObject.Find("FOODPurchasing");//食べ物屋の仕入
        UIOB[1, 5] = GameObject.Find("FOODSell");//食べ物屋の売値
        UIOB[1, 6] = GameObject.Find("FOODCountermeasures");//食べ物屋の対策

        UIOB[2, 0] = GameObject.Find("WATERFood");//水屋の食料
        UIOB[2, 1] = GameObject.Find("WATERWater");//水屋の飲料
        UIOB[2, 2] = GameObject.Find("WATERTool");//水屋の道具
        UIOB[2, 3] = GameObject.Find("WATERMoney");//水屋のお金
        UIOB[2, 4] = GameObject.Find("WATERPurchasing");//水屋の仕入
        UIOB[2, 5] = GameObject.Find("WATERSell");//水屋の売値
        UIOB[2, 6] = GameObject.Find("WATERCountermeasures");//水屋の対策

        UIOB[3, 0] = GameObject.Find("TOOLFood");//道具屋の食料
        UIOB[3, 1] = GameObject.Find("TOOLWater");//道具屋の飲料
        UIOB[3, 2] = GameObject.Find("TOOLTool");//道具屋の道具
        UIOB[3, 3] = GameObject.Find("TOOLMoney");//道具屋のお金
        UIOB[3, 4] = GameObject.Find("TOOLPurchasing");//道具屋の仕入
        UIOB[3, 5] = GameObject.Find("TOOLSell");//道具屋の売値
        UIOB[3, 6] = GameObject.Find("TOOLCountermeasures");//道具屋の対策

        for (int l = 0; l < UIOB.GetLength(0); l++)
        {
            for (int i = 0; i < UIOB.GetLength(1); i++)
            {
                UIOBText[l, i] = UIOB[l, i].GetComponent<Text>();
            }
        }
        /////////////////////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////////////////////////
        Ibent = GameObject.Find("Ibent");//情勢イベント
        Ibenttext = Ibent.GetComponent<Text>();//情勢イベントテキスト
        /////////////////////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////////////////////////
        Infection = new GameObject[4];
        InfectionText = new Text[4];
        Infection[0] = GameObject.Find("INFECTIONinfection");//薬局の感染
        Infection[1] = GameObject.Find("FOODinfection");//食べ物の感染
        Infection[2] = GameObject.Find("WATERinfection");//水屋の感染
        Infection[3] = GameObject.Find("TOOLinfection");//道具屋の感染
        for (int l = 0; l < Infection.GetLength(0); l++)
        {
            InfectionText[l] = Infection[l].GetComponent<Text>();
        }
        /////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////
        Timer = GameObject.Find("Timer");//情勢イベント
        TimerText = Timer.GetComponent<Text>();//情勢イベントテキスト
        /////////////////////////////////////////////////////////////////////////////
    }
}