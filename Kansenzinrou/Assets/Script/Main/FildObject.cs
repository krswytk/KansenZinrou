using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Hierachyから各オブジェクトを検索取得を行う
public class FildObject : Config
{
    [HideInInspector] public GameObject[,] UIOB;//各数値のprivate GameObject 
    [HideInInspector] public Text[,] UIOBText;//各数値のprivate Text //数値用テキストオブジェクト
                                              /*
                                               1次元　0 薬局　1 食べ物 　2 水屋 　3 道具
                                               2次元　0 食料　1 飲料　2 道具　3 薬 4 お金　5 仕入れ　6 売値
                                               */

    [HideInInspector] public GameObject IbentAll;//情勢イベントprivate GameObject 
    [HideInInspector] public GameObject Ibent;//情勢イベントprivate GameObject 
    [HideInInspector] public Text Ibenttext;//情勢イベントprivate Text 

    [HideInInspector] public GameObject[] Infection;//感染情報推測のオブジェクト
    [HideInInspector] public Sprite[] InfectionMark;//感染情報推測のオブジェクト
    [HideInInspector] public Image[] InfectionImage;//感染情報推測のテキストオブジェクト


    [HideInInspector] public GameObject TimerAll;//時間表示のオブジェクト
    [HideInInspector] public GameObject Timer;//時間表示のオブジェクト
    [HideInInspector] public Text TimerText;//時間表示のタイマー

    [HideInInspector] public GameObject PCR;//感染情報確定の複数格納オブジェクト
    [HideInInspector] public GameObject InfectionIndication;//感染情報確定のオブジェクト
    [HideInInspector] public Text InfectionIndicationText;//感染情報確定のテキストオブジェクト


    [HideInInspector] public GameObject[,] PurchasingGroup;//仕入れボタンのセット


    [HideInInspector] public GameObject[,] BusinessGroup;//取引ボタンの各役職ごとのセット
    [HideInInspector] public GameObject Next;//全取引を確定させるボタン

    [HideInInspector] public GameObject Countermeasures;//感染対策ボタンのセット
    [HideInInspector] public GameObject[] CountermeasuresMask;//感染対策ボタンのセット


    [HideInInspector] public AudioClip[] SoundSE;//感染対策ボタンのセット

    MainManeger MM;



    FirstNumber FN;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("全ボタン、テキストオブジェクトの取得");
        MM = GetComponent<MainManeger>();

        /////////////////////////////////////////////////////////////////////////////
        UIOB = new GameObject[MainManeger.PlayerNumber, 7];
        UIOBText = new Text[MainManeger.PlayerNumber, 7];
        UIOB[0, 0] = GameObject.Find("DDN");//薬局の薬//I = 薬局　I = 薬 N = 数字テキスト
        UIOB[0, 1] = GameObject.Find("DFN");//薬局の食料
        UIOB[0, 2] = GameObject.Find("DWN");//薬局の飲料
        UIOB[0, 3] = GameObject.Find("DTN");//薬局の道具
        UIOB[0, 4] = GameObject.Find("DMN");//薬局のお金
        UIOB[0, 5] = GameObject.Find("DPN");//薬局の仕入
        UIOB[0, 6] = GameObject.Find("DSN");//薬局の売値

        UIOB[1, 0] = GameObject.Find("FDN");//食べ物屋の薬
        UIOB[1, 1] = GameObject.Find("FFN");//食べ物屋の食料
        UIOB[1, 2] = GameObject.Find("FWN");//食べ物屋の飲料
        UIOB[1, 3] = GameObject.Find("FTN");//食べ物屋の道具
        UIOB[1, 4] = GameObject.Find("FMN");//食べ物屋のお金
        UIOB[1, 5] = GameObject.Find("FPN");//食べ物屋の仕入
        UIOB[1, 6] = GameObject.Find("FSN");//食べ物屋の売値

        UIOB[2, 0] = GameObject.Find("WDN");//水屋の薬
        UIOB[2, 1] = GameObject.Find("WFN");//水屋の食料
        UIOB[2, 2] = GameObject.Find("WWN");//水屋の飲料
        UIOB[2, 3] = GameObject.Find("WTN");//水屋の道具
        UIOB[2, 4] = GameObject.Find("WMN");//水屋のお金
        UIOB[2, 5] = GameObject.Find("WPN");//水屋の仕入
        UIOB[2, 6] = GameObject.Find("WSN");//水屋の売値

        UIOB[3, 0] = GameObject.Find("TDN");//道具屋の薬
        UIOB[3, 1] = GameObject.Find("TFN");//道具屋の食料
        UIOB[3, 2] = GameObject.Find("TWN");//道具屋の飲料
        UIOB[3, 3] = GameObject.Find("TTN");//道具屋の道具
        UIOB[3, 4] = GameObject.Find("TMN");//道具屋のお金
        UIOB[3, 5] = GameObject.Find("TPN");//道具屋の仕入
        UIOB[3, 6] = GameObject.Find("TSN");//道具屋の売値

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
        IbentAll = GameObject.Find("IbentAll");//情勢イベント
        Ibent = GameObject.Find("Ibent");//情勢イベント
        Ibenttext = Ibent.GetComponent<Text>();//情勢イベントテキスト
        /////////////////////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////////////////////////
        Infection = new GameObject[4];
        InfectionMark = new Sprite[5];
        InfectionImage = new Image[4];
        Infection[0] = GameObject.Find("DI");//薬の感染
        Infection[1] = GameObject.Find("FI");//食べ物の感染
        Infection[2] = GameObject.Find("WI");//水屋の感染
        Infection[3] = GameObject.Find("TI");//道具屋の感染      
        InfectionMark[0] = Resources.Load<Sprite>("元気");//元気
        InfectionMark[1] = Resources.Load<Sprite>("少し具合がわるい");//少し具合がわるい
        InfectionMark[2] = Resources.Load<Sprite>("風邪っぽい");//風邪っぽい
        InfectionMark[3] = Resources.Load<Sprite>("吐き気がする");//吐き気がする
        InfectionMark[3] = Resources.Load<Sprite>("死にそう");//死にそう
        for (int l = 0; l < Infection.GetLength(0); l++)
        {
            InfectionImage[l] = Infection[l].GetComponent<Image>();
        }
        /////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////
        TimerAll = GameObject.Find("TimerAll");//情勢イベント
        Timer = GameObject.Find("Timer");//情勢イベント
        TimerText = Timer.GetComponent<Text>();//情勢イベントテキスト
        /////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        PCR = GameObject.Find("PCR");//感染情報確定の複数格納オブジェクト
        InfectionIndication = GameObject.Find("InfectionIndication");//感染情報確定のオブジェクト
        InfectionIndicationText = Timer.GetComponent<Text>();//感染情報確定のテキストオブジェクト
        ////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        PurchasingGroup = new GameObject[4, 4];//売り物ー＋売値ー＋  

        PurchasingGroup[0, 0] = GameObject.Find("DPBM");//薬の売り物ー//D = 薬  P = 売り物  B = ボタン P = プラス
        PurchasingGroup[0, 1] = GameObject.Find("DPBP");//薬の売り物＋
        PurchasingGroup[0, 2] = GameObject.Find("DSBM");//薬の売値ー
        PurchasingGroup[0, 3] = GameObject.Find("DSBP");//薬の売値＋

        PurchasingGroup[1, 0] = GameObject.Find("FPBM");//食料の売り物ー
        PurchasingGroup[1, 1] = GameObject.Find("FPBP");//食料の売り物＋
        PurchasingGroup[1, 2] = GameObject.Find("FSBM");//食料の売値ー
        PurchasingGroup[1, 3] = GameObject.Find("FSBP");//食料の売値＋

        PurchasingGroup[2, 0] = GameObject.Find("WPBM");//水の売り物ー
        PurchasingGroup[2, 1] = GameObject.Find("WPBP");//水の売り物＋
        PurchasingGroup[2, 2] = GameObject.Find("WSBM");//水の売値ー
        PurchasingGroup[2, 3] = GameObject.Find("WSBP");//水の売値＋

        PurchasingGroup[3, 0] = GameObject.Find("TPBM");//道具の売り物ー
        PurchasingGroup[3, 1] = GameObject.Find("TPBP");//道具の売り物＋
        PurchasingGroup[3, 2] = GameObject.Find("TSBM");//道具の売値ー
        PurchasingGroup[3, 3] = GameObject.Find("TSBP");//道具の売値＋


        ////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////
        BusinessGroup = new GameObject[MainManeger.PlayerNumber, 8];//食料ー＋水ー＋道具ー＋薬ー＋

        BusinessGroup[0, 0] = GameObject.Find("DDBM");//薬の取引薬ー//I = 薬局  P = 売り物  B = ボタン P = プラス
        BusinessGroup[0, 1] = GameObject.Find("DDBP");//薬の取引薬＋
        BusinessGroup[0, 2] = GameObject.Find("DFBM");//薬の取引食料ー
        BusinessGroup[0, 3] = GameObject.Find("DFBP");//薬の取引食料＋
        BusinessGroup[0, 4] = GameObject.Find("DWBM");//薬の取引水ー
        BusinessGroup[0, 5] = GameObject.Find("DWBP");//薬の取引水＋        
        BusinessGroup[0, 6] = GameObject.Find("DTBM");//薬の取引道具ー
        BusinessGroup[0, 7] = GameObject.Find("DTBP");//薬の取引道具＋

        BusinessGroup[1, 0] = GameObject.Find("FDBM");//食料の取引薬ー//I = 薬局  P = 売り物  B = ボタン P = プラス
        BusinessGroup[1, 1] = GameObject.Find("FDBP");//食料の取引薬＋
        BusinessGroup[1, 2] = GameObject.Find("FFBM");//食料の取引食料ー
        BusinessGroup[1, 3] = GameObject.Find("FFBP");//食料の取引食料＋
        BusinessGroup[1, 4] = GameObject.Find("FWBM");//食料の取引水ー
        BusinessGroup[1, 5] = GameObject.Find("FWBP");//食料の取引水＋        
        BusinessGroup[1, 6] = GameObject.Find("FTBM");//食料の取引道具ー
        BusinessGroup[1, 7] = GameObject.Find("FTBP");//食料の取引道具＋

        BusinessGroup[2, 0] = GameObject.Find("WDBM");//水の取引薬ー//I = 薬局  P = 売り物  B = ボタン P = プラス
        BusinessGroup[2, 1] = GameObject.Find("WDBP");//水の取引薬＋
        BusinessGroup[2, 2] = GameObject.Find("WFBM");//水の取引食料ー
        BusinessGroup[2, 3] = GameObject.Find("WFBP");//水の取引食料＋
        BusinessGroup[2, 4] = GameObject.Find("WWBM");//水の取引水ー
        BusinessGroup[2, 5] = GameObject.Find("WWBP");//水の取引水＋        
        BusinessGroup[2, 6] = GameObject.Find("WTBM");//水の取引道具ー
        BusinessGroup[2, 7] = GameObject.Find("WTBP");//水の取引道具＋

        BusinessGroup[3, 0] = GameObject.Find("TDBM");//道具の取引薬ー//I = 薬局  P = 売り物  B = ボタン P = プラス
        BusinessGroup[3, 1] = GameObject.Find("TDBP");//道具の取引薬＋
        BusinessGroup[3, 2] = GameObject.Find("TFBM");//道具の取引食料ー
        BusinessGroup[3, 3] = GameObject.Find("TFBP");//道具の取引食料＋
        BusinessGroup[3, 4] = GameObject.Find("TWBM");//道具の取引水ー
        BusinessGroup[3, 5] = GameObject.Find("TWBP");//道具の取引水＋        
        BusinessGroup[3, 6] = GameObject.Find("TTBM");//道具の取引道具ー
        BusinessGroup[3, 7] = GameObject.Find("TTBP");//道具の取引道具＋

        Next = GameObject.Find("Next");//道具屋の取引ボタンセット
        ////////////////////////////////////////////////////////////////////////////
        ///
        /////////////////////////////////////////////////////////////////////////////
        CountermeasuresMask = new GameObject[4];
        Countermeasures = GameObject.Find("Countermeasures");//感染対策の複数格納オブジェクト
        CountermeasuresMask[0] = GameObject.Find("DCN");//薬局の対策
        CountermeasuresMask[1] = GameObject.Find("FCN");//食べ物屋の対策
        CountermeasuresMask[2] = GameObject.Find("WCN");//水屋の対策
        CountermeasuresMask[3] = GameObject.Find("TCN");//道具屋の対策
        ////////////////////////////////////////////////////////////////////////////
        ///
        ////////////////////////////////////////////////////////////////////////////
        SoundSE = new AudioClip[8];//SEの格納
        SoundSE[0] = Resources.Load<AudioClip>("SE/4nin_Buy etc");
        SoundSE[1] = Resources.Load<AudioClip>("SE/4nin_Death");
        SoundSE[2] = Resources.Load<AudioClip>("SE/4nin_NextPlayer");
        SoundSE[3] = Resources.Load<AudioClip>("SE/4nin_NotBuy etc");
        SoundSE[4] = Resources.Load<AudioClip>("SE/4nin_Nyu-su");
        SoundSE[5] = Resources.Load<AudioClip>("SE/4nin_TimeCount");
        SoundSE[6] = Resources.Load<AudioClip>("SE/4nin_Ton");
        SoundSE[7] = Resources.Load<AudioClip>("SE/4nin_Ave");
    }
}