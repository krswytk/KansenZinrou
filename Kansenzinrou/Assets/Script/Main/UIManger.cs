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

    public void Start()//表の更新を行う    
    {
        FO = GetComponent<FildObject>();
        MM = GetComponent<MainManeger>();
        Player = MM.Player;
        Config = GetComponent < Config >();
    }

    public void TableUpdate()//表の更新を行う    
    {
        for (int l = 0; l < FO.UIOBText.GetLength(0); l++)
        {
            FO.UIOBText[l, 0].text = Player[l].GetFood().ToString();//食料
            FO.UIOBText[l, 1].text = Player[l].GetWater().ToString();//飲料
            FO.UIOBText[l, 2].text = Player[l].GetTool().ToString();//道具
            FO.UIOBText[l, 3].text = Player[l].GetMedicine().ToString();//薬量
            FO.UIOBText[l, 4].text = Player[l].GetMoney().ToString();//お金
            FO.UIOBText[l, 5].text = Player[l].GetPurchasing().ToString();//仕入
            FO.UIOBText[l, 6].text = Player[l].GetSell().ToString();//売値
            FO.UIOBText[l, 7].text = Player[l].GetCountermeasures().ToString();//対策true or false
            switch (l)
            {
                case 1:
                    FO.UIOBText[l, 0].text = "∞";
                    break;
                case 2:
                    FO.UIOBText[l, 1].text = "∞";
                    break;
                case 3:
                    FO.UIOBText[l, 2].text = "∞";
                    break;
            }
        }
    }

    public void NewsDisplay(Config.news N)//ニュースの更新を行う
    {
        switch (N)
        {
            case Config.news.発見:
                FO.Ibenttext.text = "現在の情勢イベントは " + "この世界で新たな感染症が発見されました" + " です。";
                break;
            case Config.news.クラスター:
                FO.Ibenttext.text = "現在の情勢イベントは " + "このターンの感染率up" + " です。";
                break;
            case Config.news.給付金:
                FO.Ibenttext.text = "現在の情勢イベントは " + "全プレイヤーに金＋1" + " です。";
                break;
            case Config.news.変異:
                FO.Ibenttext.text = "現在の情勢イベントは " + "このターンに感染すると2から症状が始まる" + " です。";
                break;
            case Config.news.体調不良:
                FO.Ibenttext.text = "現在の情勢イベントは " + "PCR検査ランダムに1人の感染状況を開示" + " です。";
                break;
            case Config.news.支援:
                FO.Ibenttext.text = "現在の情勢イベントは " + "このターン中のみ感染対策の費用が1になる" + " です。";
                break;
            case Config.news.医療崩壊:
                FO.Ibenttext.text = "現在の情勢イベントは " + "このターン中のみ医者の用意出来るベッドが1になる" + " です。";
                break;
        }

    }

    public void InfectionDisplay()//感染状況の表示更新を行う
    {
        int num;
        string Str = "";
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
                        case 1: Str = "元気"; break;
                        case 2: Str = "元気"; break;
                        case 3: Str = "元気"; break;
                        case 4: Str = "元気"; break;
                        case 5: Str = "元気"; break;
                        case 6: Str = "少し具合が悪い"; break;
                        case 7: Str = "少し具合が悪い"; break;
                        case 8: Str = "少し具合が悪い"; break;
                        case 9: Str = "風邪っぽい"; break;
                        case 10: Str = "風邪っぽい"; break;
                        default: Debug.LogError("Cord_101-感染表示で想定外の発生"); break;
                    }
                    break;
                case 1:
                    switch (r)
                    {
                        case 1: Str = "元気"; break;
                        case 2: Str = "元気"; break;
                        case 3: Str = "元気"; break;
                        case 4: Str = "元気"; break;
                        case 5: Str = "少し具合が悪い"; break;
                        case 6: Str = "少し具合が悪い"; break;
                        case 7: Str = "少し具合が悪い"; break;
                        case 8: Str = "風邪っぽい"; break;
                        case 9: Str = "風邪っぽい"; break;
                        case 10: Str = "吐き気がする"; break;
                        default: Debug.LogError("Cord_102-感染表示で想定外の発生"); break;
                    }
                    break;
                case 2:
                    switch (r)
                    {
                        case 1: Str = "風邪っぽい"; break;
                        case 2: Str = "風邪っぽい"; break;
                        case 3: Str = "風邪っぽい"; break;
                        case 4: Str = "吐き気がする"; break;
                        case 5: Str = "吐き気がする"; break;
                        case 6: Str = "吐き気がする"; break;
                        case 7: Str = "吐き気がする"; break;
                        case 8: Str = "死にそう"; break;
                        case 9: Str = "死にそう"; break;
                        case 10: Str = "死にそう"; break;
                        default: Debug.LogError("Cord_103-感染表示で想定外の発生"); break;
                    }
                    break;
                default: Debug.LogError("Cord_104-感染表示で想定外の発生"); break;
            }
            FO.InfectionText[l].text = Str;
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
}
