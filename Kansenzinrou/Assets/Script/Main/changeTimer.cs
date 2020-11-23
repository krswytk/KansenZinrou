using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTimer : MonoBehaviour
{
    MainManeger MM;
    TurnManeger TM;
    [SerializeField] GameObject text;
    bool txton = true;
    [HideInInspector] public float span = 5f;
    private float currentTime = 0f;
    [HideInInspector] public int Turn;//今取引をしている人のターン
    Player[] Player;
    bool PLchack = true;
    void Start()
    {
        TM= GameObject.Find("Maneger").GetComponent<TurnManeger>();
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        Player = MM.Player;
        //TM = GetComponent<TurnManeger>();
        //MM = GetComponent<MainManeger>();
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (TM.GetBusinessSW()) //取引開始スイッチがONになっていたら
        {
            text.SetActive(false);
            txton = false;
            PLchack = true;
        }
        else
        {
            if (currentTime > span)
            {
                if (txton == true)
                {
                    text.SetActive(false);
                    txton = false;
                }
                else if (txton == false)
                {
                    text.SetActive(true);
                    txton = true;
                }
                Debug.LogFormat("{0}秒経過", span);
                currentTime = 0f;
            }
            if (PLchack == true)
            {
                PLchack = false;
                Debug.Log("一度だけ");
                switch (TM.GetTurn())//現在が何ターン目なのか取得
                {
                    case 1:
                        Turn = 0;//薬局から
                        //PLchack = false;
                        break;
                    case 2:
                        Turn = 1;//食べ物から
                        //PLchack = false;
                        break;
                    case 3:
                        Turn = 2;//水から
                        //PLchack = false;
                        break;
                    case 4:
                        Turn = 3;//道具から
                        //PLchack = false;
                        break;
                    case 5:
                        Turn = 0;//薬局から
                        //PLchack = false;
                        break;
                    case 6:
                        Turn = 1;//食べ物から
                        //PLchack = false;
                        break;
                    default:
                        Debug.LogError("Cord_501-交渉にて想定外のターンを取得");
                        //PLchack = false;
                        break;

                }
            }
        }
        
        while (Player[Turn].GetDeath() != false)//死亡してたら終了の処理を記述//もし死んでなければ
        {
            Debug.Log("お前はもう死んでいいる");
            Debug.Log(Turn);
            Turn++;
            Debug.Log(Turn);
            if (Turn >= 4)
                Turn = 0;
            break;
        }
        /*switch (TM.GetTurn())//現在が何ターン目なのか取得
        {
            case 1:
                Turn = 0;//薬局から
                PLchack = false;
                break;
            case 2:
                Turn = 1;//食べ物から
                PLchack = false;
                break;
            case 3:
                Turn = 2;//水から
                PLchack = false;
                break;
            case 4:
                Turn = 3;//道具から
                PLchack = false;
                break;
            case 5:
                Turn = 0;//薬局から
                PLchack = false;
                break;
            case 6:
                Turn = 1;//食べ物から
                PLchack = false;
                break;
            default:
                Debug.LogError("Cord_501-交渉にて想定外のターンを取得");
                PLchack = false;
                break;

        }//誰から始めるのか判断*/

    }
}