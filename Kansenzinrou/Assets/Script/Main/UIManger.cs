using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManger : MonoBehaviour//UI表示全般を行うクラス
{
    FildObject FO;
    MainManeger MM;
    Player[] Player;
    Config Config;

    public void Start()//   
    {
        FO = GetComponent<FildObject>();
        MM = GetComponent<MainManeger>();
        Player = MM.Player;
        Config = GetComponent < Config >();
    }

    public void TableUpdate()//表の更新を行う    
    {
        for (int l = 0; l < FO.UIOBText.GetLength(0)-1; l++)
        {
            FO.UIOBText[l, 0].text = Player[l].GetMedicine().ToString();//薬量
            FO.UIOBText[l, 1].text = Player[l].GetFood().ToString();//食料
            FO.UIOBText[l, 2].text = Player[l].GetWater().ToString();//飲料
            FO.UIOBText[l, 3].text = Player[l].GetTool().ToString();//道具
            FO.UIOBText[l, 4].text = Player[l].GetMoney().ToString();//お金
            FO.UIOBText[l, 5].text = Player[l].GetPurchasing().ToString();//仕入
            FO.UIOBText[l, 6].text = Player[l].GetSell().ToString();//売値

            if (Player[l].GetFood() > 100)
            {
                FO.UIOBText[l, 1].text = "∞";
            }
            if (Player[l].GetWater() > 100)
            {
                FO.UIOBText[l, 2].text = "∞";
            }
            if (Player[l].GetTool() > 100)
            {
                FO.UIOBText[l, 3].text = "∞";
            }
        }
    }

    public void NewsDisplay(Config.news N)//ニュースの更新を行う
    {
        switch (N)
        {
            case Config.news.発見:
                FO.Ibenttext.text = "情勢イベントは\n\r" + "この世界で新たな感染症が発見されました";
                break;
            case Config.news.クラスター:
                FO.Ibenttext.text = "情勢イベントは\n\r" + "このターンの感染率up";
                break;
            case Config.news.給付金:
                FO.Ibenttext.text = "情勢イベントは\n\r" + "全プレイヤーに金＋1";
                break;
            case Config.news.変異:
                FO.Ibenttext.text = "情勢イベントは\n\r" + "このターンに感染すると2から症状が始まる";
                break;
            case Config.news.体調不良:
                FO.Ibenttext.text = "情勢イベントは\n\r" + "PCR検査ランダムに1人の感染状況を開示";
                break;
            case Config.news.支援:
                FO.Ibenttext.text = "情勢イベントは\n\r" + "このターン中のみ感染対策の費用が1になる";
                break;
            case Config.news.医療崩壊:
                FO.Ibenttext.text = "情勢イベントは\n\r" + "このターン中のみ医者の用意出来るベッドが1になる";
                break;
        }

    }

    public void InfectionDisplay()//感染状況の表示更新を行う
    {
        int num;
        Sprite S = FO.InfectionMark[0];
        int r;

        for (int l = 0; l < Player.Length; l++)
        {
            num = Player[l].Getinfection();
            r = RandomDice.DiceRoll(10);
            switch (num)
            {
                case 0:
                    switch (r)
                    {
                        case 1: S = FO.InfectionMark[0]; break;
                        case 2: S = FO.InfectionMark[0]; break;
                        case 3: S = FO.InfectionMark[0]; break;
                        case 4: S = FO.InfectionMark[0]; break;
                        case 5: S = FO.InfectionMark[0]; break;
                        case 6: S = FO.InfectionMark[1]; break;
                        case 7: S = FO.InfectionMark[1]; break;
                        case 8: S = FO.InfectionMark[1]; break;
                        case 9: S = FO.InfectionMark[2]; break;
                        case 10: S = FO.InfectionMark[2]; break;
                        default: Debug.LogError("Cord_101-感染表示で想定外の発生"); break;
                    }
                    break;
                case 1:
                    switch (r)
                    {
                        case 1: S = FO.InfectionMark[0]; break;
                        case 2: S = FO.InfectionMark[0]; break;
                        case 3: S = FO.InfectionMark[0]; break;
                        case 4: S = FO.InfectionMark[0]; break;
                        case 5: S = FO.InfectionMark[1]; break;
                        case 6: S = FO.InfectionMark[1]; break;
                        case 7: S = FO.InfectionMark[1]; break;
                        case 8: S = FO.InfectionMark[2]; break;
                        case 9: S = FO.InfectionMark[2]; break;
                        case 10: S = FO.InfectionMark[3]; break;
                        default: Debug.LogError("Cord_102-感染表示で想定外の発生"); break;
                    }
                    break;
                case 2:
                    switch (r)
                    {
                        case 1: S = FO.InfectionMark[2]; break;
                        case 2: S = FO.InfectionMark[2]; break;
                        case 3: S = FO.InfectionMark[2]; break;
                        case 4: S = FO.InfectionMark[3]; break;
                        case 5: S = FO.InfectionMark[3]; break;
                        case 6: S = FO.InfectionMark[3]; break;
                        case 7: S = FO.InfectionMark[3]; break;
                        case 8: S = FO.InfectionMark[4]; break;
                        case 9: S = FO.InfectionMark[4]; break;
                        case 10: S = FO.InfectionMark[4]; break;
                        default: Debug.LogError("Cord_103-感染表示で想定外の発生"); break;
                    }
                    break;
                default: Debug.LogError("Cord_104-感染表示で想定外の発生"); break;
            }
            FO.InfectionImage[l].sprite = S;
            MM.PlaySE(FO.SoundSE[6]);
        }
    }

    public void InfectionIndication(int num)//感染状態の完全表示　情勢イベントでのPCRで使用するもの
    {
        int n = Player[num].Getinfection();//感染状態を格納
        switch (n)
        {
            case 0:
                FO.InfectionIndicationText.text = Player[num].GetName() + ":健康体そのものです";
                break;
            case 1:
                FO.InfectionIndicationText.text = Player[num].GetName() + ":あなたは軽症です";
                break;
            case 2:
                FO.InfectionIndicationText.text = Player[num].GetName() + ":あなたは重症です";
                break;
            case 3:
                FO.InfectionIndicationText.text = Player[num].GetName() + ":このままでは死にます";
                break;
            default:
                Debug.LogError("Cord_105-PRC検査表示で想定外の発生");
                break;
        }
    }

    public void MaskON(int t)
    {
        FO.CountermeasuresMask[t].SetActive(true);
    }

    public void MaskOFF()
    {
        for (int l = 0; l < Player.Length; l++)
        {
            FO.CountermeasuresMask[l].SetActive(false);
        }
    }
}
