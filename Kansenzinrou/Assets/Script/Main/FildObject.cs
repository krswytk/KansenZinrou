using System.Collections;
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
     2次元　0 食料　1 飲料　2 道具　3 薬 4 お金　5 仕入れ　6 売値　7対策 
     */

    [HideInInspector] public GameObject Ibent;//情勢イベントprivate GameObject 
    [HideInInspector] public Text Ibenttext;//情勢イベントprivate Text 

    [HideInInspector] public GameObject[] Infection;//感染情報推測のオブジェクト
    [HideInInspector] public Text[] InfectionText;//感染情報推測のテキストオブジェクト


    [HideInInspector] public GameObject Timer;//時間表示のオブジェクト
    [HideInInspector] public Text TimerText;//時間表示のタイマー

    [HideInInspector] public GameObject PCR;//感染情報確定の複数格納オブジェクト
    [HideInInspector] public GameObject InfectionIndication;//感染情報確定のオブジェクト
    [HideInInspector] public Text InfectionIndicationText;//感染情報確定のテキストオブジェクト


    [HideInInspector] public GameObject PurchasingGroup;//仕入れボタンのセット


    [HideInInspector] public GameObject[] BusinessGroup;//取引ボタンの各役職ごとのセット
    [HideInInspector] public GameObject Next;//全取引を確定させるボタン

    [HideInInspector] public GameObject Countermeasures;//感染対策ボタンのセット


    MainManeger MM;

    FirstNumber FN;
    // Start is called before the first frame update
    void Awake()
    {
        MM = GetComponent<MainManeger>();
        
        /////////////////////////////////////////////////////////////////////////////
        UIOB = new GameObject[MainManeger.PlayerNumber, 8];
        UIOBText = new Text[MainManeger.PlayerNumber, 8];
        UIOB[0, 0] = GameObject.Find("INFECTIONFood");//薬局の食料
        UIOB[0, 1] = GameObject.Find("INFECTIONWater");//薬局の飲料
        UIOB[0, 2] = GameObject.Find("INFECTIONTool");//薬局の道具
        UIOB[0, 3] = GameObject.Find("INFECTIONMedicine");//薬局の薬
        UIOB[0, 4] = GameObject.Find("INFECTIONMoney");//薬局のお金
        UIOB[0, 5] = GameObject.Find("INFECTIONPurchasing");//薬局の仕入
        UIOB[0, 6] = GameObject.Find("INFECTIONSell");//薬局の売値
        UIOB[0, 7] = GameObject.Find("INFECTIONCountermeasures");//薬局の対策

        UIOB[1, 0] = GameObject.Find("FOODFood");//食べ物屋の食料
        UIOB[1, 1] = GameObject.Find("FOODWater");//食べ物屋の飲料
        UIOB[1, 2] = GameObject.Find("FOODTool");//食べ物屋の道具
        UIOB[1, 3] = GameObject.Find("FOODMedicine");//食べ物屋の薬
        UIOB[1, 4] = GameObject.Find("FOODMoney");//食べ物屋のお金
        UIOB[1, 5] = GameObject.Find("FOODPurchasing");//食べ物屋の仕入
        UIOB[1, 6] = GameObject.Find("FOODSell");//食べ物屋の売値
        UIOB[1, 7] = GameObject.Find("FOODCountermeasures");//食べ物屋の対策

        UIOB[2, 0] = GameObject.Find("WATERFood");//水屋の食料
        UIOB[2, 1] = GameObject.Find("WATERWater");//水屋の飲料
        UIOB[2, 2] = GameObject.Find("WATERTool");//水屋の道具
        UIOB[2, 3] = GameObject.Find("WATERMedicine");//水屋の薬
        UIOB[2, 4] = GameObject.Find("WATERMoney");//水屋のお金
        UIOB[2, 5] = GameObject.Find("WATERPurchasing");//水屋の仕入
        UIOB[2, 6] = GameObject.Find("WATERSell");//水屋の売値
        UIOB[2, 7] = GameObject.Find("WATERCountermeasures");//水屋の対策

        UIOB[3, 0] = GameObject.Find("TOOLFood");//道具屋の食料
        UIOB[3, 1] = GameObject.Find("TOOLWater");//道具屋の飲料
        UIOB[3, 2] = GameObject.Find("TOOLTool");//道具屋の道具
        UIOB[3, 3] = GameObject.Find("TOOLMedicine");//道具屋の薬
        UIOB[3, 4] = GameObject.Find("TOOLMoney");//道具屋のお金
        UIOB[3, 5] = GameObject.Find("TOOLPurchasing");//道具屋の仕入
        UIOB[3, 6] = GameObject.Find("TOOLSell");//道具屋の売値
        UIOB[3, 7] = GameObject.Find("TOOLCountermeasures");//道具屋の対策

        for (int l = 0; l < UIOB.GetLength(0); l++)
        {
            for (int i = 0; i < UIOB.GetLength(1); i++)
            {
                //Debug.Log(UIOB[l, i]);
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

        /////////////////////////////////////////////////////////////////////////////
        PCR = GameObject.Find("PCR");//感染情報確定の複数格納オブジェクト
        InfectionIndication = GameObject.Find("InfectionIndication");//感染情報確定のオブジェクト
        InfectionIndicationText = Timer.GetComponent<Text>();//感染情報確定のテキストオブジェクト
        ////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        PurchasingGroup = GameObject.Find("PurchasingGroup");//感染情報確定の複数格納オブジェクト
        ////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        BusinessGroup = new GameObject[MainManeger.PlayerNumber];
        BusinessGroup[0] = GameObject.Find("INFECTIONB");//薬局の取引ボタンセット
        BusinessGroup[1] = GameObject.Find("FOODB");//食べ物屋の取引ボタンセット
        BusinessGroup[2] = GameObject.Find("WATERB");//水屋の取引ボタンセット
        BusinessGroup[3] = GameObject.Find("TOOLB");//道具屋の取引ボタンセット
        Next = GameObject.Find("Next");//道具屋の取引ボタンセット
        ////////////////////////////////////////////////////////////////////////////
        ///
        /////////////////////////////////////////////////////////////////////////////
        Countermeasures = GameObject.Find("Countermeasures");//感染情報確定の複数格納オブジェクト
        ////////////////////////////////////////////////////////////////////////////
    }
}