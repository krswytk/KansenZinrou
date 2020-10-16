using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainManeger : MonoBehaviour
{
    
    public enum FirstNumber
    {
        初期マイナス金額 = 12,//12-2D4or3D4
        マイナス物資 = 1,//毎ターン終了時にマイナスされる物資量
        薬剤必要金 = 2,//仕入れに必要な金額
        食料必要金 = 1,
        飲料必要金 = 1,
        道具必要金 = 1,
    }

    [HideInInspector] public string GMName;//名前入力シーンからもらったゲームマスターの名前が格納される
    [HideInInspector] public string[] PlayerName = null;//名前入力シーンからもらった名前が格納される


    public Player[] player;

    UIManger UIM;


    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        Debug.Log("初期起動");
        UIM = GetComponent<UIManger>();

        try
        {
            Debug.Log("プレイヤー名を取得しています\n" + PlayerName[0] + "\n" + PlayerName[1] + "\n" + PlayerName[2] + "\n" + PlayerName[3]);
        }
        catch
        {
            PlayerName = new string[4]; for (int l = 0; l < PlayerName.Length; l++)
            {
                PlayerName[l] = "Player " + l.ToString();
            }
            Debug.Log("デバックプレイヤー起動");
            //もしプレイヤー名が入っていなかったら　主デバック用
        }
        
        player = new Player[PlayerName.Length];//プレイヤー数で初期化を行う


        for (int l = 0; l < PlayerName.Length; l++)
        {
            player[l] = new Player(PlayerName[l], l);//プレイヤークラスに名前と役職を当て込む　薬剤師　食料　水　道具の順番
            player[l].PlayerDate();
        }

        //Debug.Log(player[0].GetName());
        UIM.TableUpdate();
        Turn = 0;
        Debug.Log("初期値設定終了");
        Turn = 1;
    }
    // Update is called once per frame


    private int Turn;
    void Update()
    {
        if (Turn == 1)
        {
            Debug.Log(Turn + "ターン目開始");
            UIM.TableUpdate();
            UIM.NewsDisplay();
            Turn++;
        }


    }
}
