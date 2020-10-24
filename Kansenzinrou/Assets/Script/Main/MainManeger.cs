using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainManeger : Config
{
    FildObject FO;

    [HideInInspector] public Player[] Player;//プレイヤークラスを取得
    [HideInInspector] public static int PlayerNumber;//プレイヤーの人数を取得
    
    GetPlayerName GPN;

    [HideInInspector]　public bool FirstSet = false;

    [HideInInspector] public static int Infectionprobability;//感染確率
    [HideInInspector] public static int InfectionStage;//感染段階　感染した場合この数字から感染が始まる
    [HideInInspector] public static int InfectionControl;//感染対策費用　感染した場合この数字から感染が始まるDrug purchase restrictions
    [HideInInspector] public static int DrugPurchaseRestrictions;//薬を仕入れることのできる最大数

    [HideInInspector] public string[] Log;//LOG文章格納用の文字配列
    [HideInInspector] public string[] AllLog;//LOG文章格納用の文字配列
    [HideInInspector] public int LogCount;//LOG文章格納用の文字配列    
    [HideInInspector] public int AllLogCount;//LOG文章格納用の文字配列


    
    AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        try
        {
            PlayerNumber = GPN.PlayerName.Length;//プレイ人数を取得
        }
        catch
        {
            PlayerNumber = 4;
        }

        Infectionprobability = (int)FirstNumber.感染確率;
        InfectionStage = (int)FirstNumber.感染増加;
        InfectionControl = (int)FirstNumber.感染対策;
        DrugPurchaseRestrictions = (int)FirstNumber.薬最大数;
        AllLog = new string[300];
        Log = new string[100];
        AllLogCount = 0;
        LogCount = 0;
        audioSource = GetComponent<AudioSource>();//SE再生用の取得
    }
    void Start()
    {
        LogOut("初期起動",false);

        GPN = GetComponent<GetPlayerName>();

        FO = GetComponent<FildObject>();

        try
        {
            LogOut("プレイヤー名を取得しています\n" + GPN.PlayerName[0] + "\n" + GPN.PlayerName[1] + "\n" + GPN.PlayerName[2] + "\n" + GPN.PlayerName[3], false);
        }
        catch
        {
            GPN.PlayerName = new string[4];//4人分の名前空間を確保
            for (int l = 0; l < GPN.PlayerName.Length; l++)
            {
                GPN.PlayerName[l] = "Player " + l.ToString();//Plyer1 Playre2...
            }
            LogOut("デバックプレイヤー起動", false);
        }//もしプレイヤー名が入っていなかったら　主デバック用



        Player = new Player[PlayerNumber];//プレイヤー数で初期化を行う


        for (int l = 0; l < Player.Length; l++)
        {
            Player[l] = new Player(GPN.PlayerName[l], l);//プレイヤークラスに名前と役職を当て込む　薬剤師　食料　水　道具の順番
            Player[l].PlayerDate();//プレイヤーデータを各プレイヤーデバック表示
        }
        FirstSet = true;
        LogOut("初期値設定終了", false);
    }
    // Update is called once per frame

    public void LogOut(string log, bool t)//ログの書き出し　t=trueでLogにも書き出す
    {
        AllLog[AllLogCount] = log;
        AllLogCount++;
        if (t)
        {
            Log[LogCount] = log;
            LogCount++;
        }
    }

    public void PlaySE(int sound)//ログの書き出し　t=trueでLogにも書き出す
    {
        switch (sound)
        {
            case 0: audioSource.PlayOneShot(FO.SoundSE[0]); break;
            case 1: audioSource.PlayOneShot(FO.SoundSE[1]); break;
            case 2: audioSource.PlayOneShot(FO.SoundSE[2]); break;
            case 3: audioSource.PlayOneShot(FO.SoundSE[3]); break;
            case 4: audioSource.PlayOneShot(FO.SoundSE[4]); break;
            case 5: audioSource.PlayOneShot(FO.SoundSE[5]); break;
            case 6: audioSource.PlayOneShot(FO.SoundSE[6]); break;
        }

    }
}
