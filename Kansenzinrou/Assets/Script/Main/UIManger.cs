using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour//UI表示全般を行うクラス
{
    private GameObject INFECTIONFood;//薬局の食料
    private GameObject INFECTIONWater;//薬局の飲料
    private GameObject INFECTIONTool;//薬局の道具
    private GameObject INFECTIONMoney;//薬局のお金
    private GameObject INFECTIONPurchasing;//薬局の仕入
    private GameObject INFECTIONSell;//薬局の売値
    private GameObject INFECTIONCountermeasures;//薬局の対策

    private GameObject FOODFood;//食べ物屋の食料
    private GameObject FOODWater;//食べ物屋の飲料
    private GameObject FOODTool;//食べ物屋の道具
    private GameObject FOODMoney;//食べ物屋のお金
    private GameObject FOODPurchasing;//食べ物屋の仕入
    private GameObject FOODSell;//食べ物屋の売値
    private GameObject FOODCountermeasures;//食べ物屋の対策

    private GameObject WATERFood;//水屋の食料
    private GameObject WATERWater;//水屋の飲料
    private GameObject WATERTool;//水屋の道具
    private GameObject WATERMoney;//水屋のお金
    private GameObject WATERPurchasing;//水屋の仕入
    private GameObject WATERSell;//水屋の売値
    private GameObject WATERCountermeasures;//水屋の対策

    private GameObject TOOLFood;//道具屋の食料
    private GameObject TOOLWater;//道具屋の飲料
    private GameObject TOOLTool;//道具屋の道具
    private GameObject TOOLMoney;//道具屋のお金
    private GameObject TOOLPurchasing;//道具屋の仕入
    private GameObject TOOLSell;//道具屋の売値
    private GameObject TOOLCountermeasures;//道具屋の対策private GameObject 

    private Text INFECTIONFoodText;//薬局の食料
    private Text INFECTIONWaterText;//薬局の飲料
    private Text INFECTIONToolText;//薬局の道具
    private Text INFECTIONMoneyText;//薬局のお金
    private Text INFECTIONPurchasingText;//薬局の仕入
    private Text INFECTIONSellText;//薬局の売値
    private Text INFECTIONCountermeasuresText;//薬局の対策

    private Text FOODFoodText;//食べ物屋の食料
    private Text FOODWaterText;//食べ物屋の飲料
    private Text FOODToolText;//食べ物屋の道具
    private Text FOODMoneyText;//食べ物屋のお金
    private Text FOODPurchasingText;//食べ物屋の仕入
    private Text FOODSellText;//食べ物屋の売値
    private Text FOODCountermeasuresText;//食べ物屋の対策

    private Text WATERFoodText;//水屋の食料
    private Text WATERWaterText;//水屋の飲料
    private Text WATERToolText;//水屋の道具
    private Text WATERMoneyText;//水屋のお金
    private Text WATERPurchasingText;//水屋の仕入
    private Text WATERSellText;//水屋の売値
    private Text WATERCountermeasuresText;//水屋の対策

    private Text TOOLFoodText;//道具屋の食料
    private Text TOOLWaterText;//道具屋の飲料
    private Text TOOLToolText;//道具屋の道具
    private Text TOOLMoneyText;//道具屋のお金
    private Text TOOLPurchasingText;//道具屋の仕入
    private Text TOOLSellText;//道具屋の売値
    private Text TOOLCountermeasuresText;//道具屋の対策

    Player[] player;


    private GameObject Ibent;//情勢イベントprivate GameObject 
    private Text Ibenttext;//情勢イベントprivate Text 

    public void Awake()//表の初期設定を行う    
    {
        INFECTIONFood = GameObject.Find("INFECTIONFood");//薬局の食料
        INFECTIONWater = GameObject.Find("INFECTIONWater");//薬局の飲料
        INFECTIONTool = GameObject.Find("INFECTIONTool");//薬局の道具
        INFECTIONMoney = GameObject.Find("INFECTIONMoney");//薬局のお金
        INFECTIONPurchasing = GameObject.Find("INFECTIONPurchasing");//薬局の仕入
        INFECTIONSell = GameObject.Find("INFECTIONSell");//薬局の売値
        INFECTIONCountermeasures = GameObject.Find("INFECTIONCountermeasures");//薬局の対策

        FOODFood = GameObject.Find("FOODFood");//食べ物屋の食料
        FOODWater = GameObject.Find("FOODWater");//食べ物屋の飲料
        FOODTool = GameObject.Find("FOODTool");//食べ物屋の道具
        FOODMoney = GameObject.Find("FOODMoney");//食べ物屋のお金
        FOODPurchasing = GameObject.Find("FOODPurchasing");//食べ物屋の仕入
        FOODSell = GameObject.Find("FOODSell");//食べ物屋の売値
        FOODCountermeasures = GameObject.Find("FOODCountermeasures");//食べ物屋の対策

        WATERFood = GameObject.Find("WATERFood");//水屋の食料
        WATERWater = GameObject.Find("WATERWater");//水屋の飲料
        WATERTool = GameObject.Find("WATERTool");//水屋の道具
        WATERMoney = GameObject.Find("WATERMoney");//水屋のお金
        WATERPurchasing = GameObject.Find("WATERPurchasing");//水屋の仕入
        WATERSell = GameObject.Find("WATERSell");//水屋の売値
        WATERCountermeasures = GameObject.Find("WATERCountermeasures");//水屋の対策

        TOOLFood = GameObject.Find("TOOLFood");//道具屋の食料
        TOOLWater = GameObject.Find("TOOLWater");//道具屋の飲料
        TOOLTool = GameObject.Find("TOOLTool");//道具屋の道具
        TOOLMoney = GameObject.Find("TOOLMoney");//道具屋のお金
        TOOLPurchasing = GameObject.Find("TOOLPurchasing");//道具屋の仕入
        TOOLSell = GameObject.Find("TOOLSell");//道具屋の売値
        TOOLCountermeasures = GameObject.Find("TOOLCountermeasures");//道具屋の対策

        INFECTIONFoodText = INFECTIONFood.GetComponent<Text>();//薬局の食料
        INFECTIONWaterText = INFECTIONWater.GetComponent<Text>();//薬局の飲料
        INFECTIONToolText = INFECTIONTool.GetComponent<Text>();//薬局の道具
        INFECTIONMoneyText = INFECTIONMoney.GetComponent<Text>();//薬局のお金
        INFECTIONPurchasingText = INFECTIONPurchasing.GetComponent<Text>();//薬局の仕入
        INFECTIONSellText = INFECTIONSell.GetComponent<Text>();//薬局の売値
        INFECTIONCountermeasuresText = INFECTIONCountermeasures.GetComponent<Text>();//薬局の対策

        FOODFoodText = FOODFood.GetComponent<Text>();//食べ物屋の食料
        FOODWaterText = FOODWater.GetComponent<Text>();//食べ物屋の飲料
        FOODToolText = FOODTool.GetComponent<Text>();//食べ物屋の道具
        FOODMoneyText = FOODMoney.GetComponent<Text>();//食べ物屋のお金
        FOODPurchasingText = FOODPurchasing.GetComponent<Text>();//食べ物屋の仕入
        FOODSellText = FOODSell.GetComponent<Text>();//食べ物屋の売値
        FOODCountermeasuresText = FOODCountermeasures.GetComponent<Text>();//食べ物屋の対策

        WATERFoodText = WATERFood.GetComponent<Text>();//水屋の食料
        WATERWaterText = WATERWater.GetComponent<Text>();//水屋の飲料
        WATERToolText = WATERTool.GetComponent<Text>();//水屋の道具
        WATERMoneyText = WATERMoney.GetComponent<Text>();//水屋のお金
        WATERPurchasingText = WATERPurchasing.GetComponent<Text>();//水屋の仕入
        WATERSellText = WATERSell.GetComponent<Text>();//水屋の売値
        WATERCountermeasuresText = WATERCountermeasures.GetComponent<Text>();//水屋の対策

        TOOLFoodText = TOOLFood.GetComponent<Text>();//道具屋の食料
        TOOLWaterText = TOOLWater.GetComponent<Text>();//道具屋の飲料
        TOOLToolText = TOOLTool.GetComponent<Text>();//道具屋の道具
        TOOLMoneyText = TOOLMoney.GetComponent<Text>();//道具屋のお金
        TOOLPurchasingText = TOOLPurchasing.GetComponent<Text>();//道具屋の仕入
        TOOLSellText = TOOLSell.GetComponent<Text>();//道具屋の売値
        TOOLCountermeasuresText = TOOLCountermeasures.GetComponent<Text>();//道具屋の対策


        Ibent = GameObject.Find("Ibent");//道具屋の対策
        Ibenttext = Ibent.GetComponent<Text>();//道具屋の対策
    }

    public void TableUpdate()//表の更新を行う    
    {
        player = GetComponent<MainManeger>().player;
        //Debug.Log(player[0].GetFood().ToString());
        //Debug.Log(INFECTIONFood);
        INFECTIONFoodText.text = player[0].GetFood().ToString();//薬局の食料
        INFECTIONWaterText.text = player[0].GetWater().ToString();//薬局の飲料
        INFECTIONToolText.text = player[0].GetTool().ToString();//薬局の道具
        INFECTIONMoneyText.text = player[0].GetMoney().ToString();//薬局のお金
        INFECTIONPurchasingText.text = player[0].GetPurchasing().ToString();//薬局の仕入
        INFECTIONSellText.text = player[0].GetSell().ToString();//薬局の売値
        INFECTIONCountermeasuresText.text = player[0].GetCountermeasures().ToString();//薬局の対策

        FOODFoodText.text = "∞";//食べ物屋の食料
        FOODWaterText.text = player[1].GetWater().ToString();//食べ物屋の飲料
        FOODToolText.text = player[1].GetTool().ToString();//食べ物屋の道具
        FOODMoneyText.text = player[1].GetMoney().ToString();//食べ物屋のお金
        FOODPurchasingText.text = player[1].GetPurchasing().ToString();//食べ物屋の仕入
        FOODSellText.text = player[1].GetSell().ToString();//食べ物屋の売値
        FOODCountermeasuresText.text = player[1].GetCountermeasures().ToString();//食べ物屋の対策

        WATERFoodText.text = player[2].GetFood().ToString();//水屋の食料
        WATERWaterText.text = "∞";//水屋の飲料
        WATERToolText.text = player[2].GetTool().ToString();//水屋の道具
        WATERMoneyText.text = player[2].GetMoney().ToString();//水屋のお金
        WATERPurchasingText.text = player[2].GetPurchasing().ToString();//水屋の仕入
        WATERSellText.text = player[2].GetSell().ToString();//水屋の売値
        WATERCountermeasuresText.text = player[2].GetCountermeasures().ToString();//水屋の対策

        TOOLFoodText.text = player[3].GetFood().ToString();//道具屋の食料
        TOOLWaterText.text = player[3].GetWater().ToString();//道具屋の飲料
        TOOLToolText.text = "∞";//道具屋の道具
        TOOLMoneyText.text = player[3].GetMoney().ToString();//道具屋のお金
        TOOLPurchasingText.text = player[3].GetPurchasing().ToString();//道具屋の仕入
        TOOLSellText.text = player[3].GetSell().ToString();//道具屋の売値
        TOOLCountermeasuresText.text = player[3].GetCountermeasures().ToString();//道具屋の対策
    }
    public enum news
    {
        クラスター = 1,//このターンの感染率up（クラスター発生）
        給付金 = 2,//全プレイヤーに金＋1（給付金）
        変異 = 3,//このターンに感染すると2から症状が始まる（ウィルス変異）
        体調不良 = 4,//PCR検査ランダムに1人の感染状況を開示（体調不良）
        支援 = 5,//このターン中のみ感染対策の費用が1になる(国からの支援)
        医療崩壊 = 6//このターン中のみ医者の用意出来るベッドが1になる（医療崩壊）
    }
    news now;
    public void NewsDisplay()//ニューズの更新を行う
    {
        int n = RandomDice.DiceRoll(6);//1D6 123456
        switch (n)
        {
            case 1:
                now = news.クラスター;
                Ibenttext.text = "現在の情勢イベントは " + "このターンの感染率up" + " です。";
                break;
            case 2:
                now = news.給付金;
                Ibenttext.text = "現在の情勢イベントは " + "全プレイヤーに金＋1" + " です。";
                break;
            case 3:
                now = news.変異;
                Ibenttext.text = "現在の情勢イベントは " + "このターンに感染すると2から症状が始まる" + " です。";
                break;
            case 4:
                now = news.体調不良;
                Ibenttext.text = "現在の情勢イベントは " + "PCR検査ランダムに1人の感染状況を開示" + " です。";
                break;
            case 5:
                now = news.支援;
                Ibenttext.text = "現在の情勢イベントは " + "このターン中のみ感染対策の費用が1になる" + " です。";
                break;
            case 6:
                now = news.医療崩壊;
                Ibenttext.text = "現在の情勢イベントは " + "このターン中のみ医者の用意出来るベッドが1になる" + " です。";
                break;
        }

    }
}
