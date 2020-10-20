using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessALL : MonoBehaviour//取引関係のスクリプト
{
    MainManeger MM;
    TurnManeger TM;
    FildObject FO;
    private bool sw;

    private int Turn;
    private static bool next;
    // Start is called before the first frame update
    void Start()
    {
        MM = GetComponent<MainManeger>();
        TM = GetComponent<TurnManeger>();
        FO = GetComponent<FildObject>();
        sw = false;
        Turn = -1;
        for(int i = 0; i < MM.PlayerNumber; i++)
        {
            FO.BusinessGroup[i].SetActive(false);//隠す
        }
        FO.Next.SetActive(false);//隠す
    }

    // Update is called once per frame
    void Update()
    {
        if (TM.GetBusinessSW()) //取引開始スイッチがONになっていたら
        {
            if(sw == false){//スイッチがONになったら1度呼ばれる
                sw = true;
                switch (TM.GetTurn())//現在が何ターン目なのか取得
                {
                    case 1:
                        Turn = 0;//薬局から
                        break;
                    case 2:
                        Turn = 1;//食べ物から
                        break;
                    case 3:
                        Turn = 2;//水から
                        break;
                    case 4:
                        Turn = 3;//道具から
                        break;
                    case 5:
                        Turn = 0;//薬局から
                        break;
                    case 6:
                        Turn = 1;//食べ物から
                        break;
                    default:
                        Debug.LogError("Cord_501-交渉にて想定外のターンを取得");
                        break;

                }//誰から始めるのか判断
                FO.BusinessGroup[Turn].SetActive(true);//最初の順番のものを表示

            }
        }

        //ターン管理
        //ターンに適応したボタンの有効化

        
    }

    public void NextSW()//交渉決定用のボタン
    {
        next = true;//次に進む（交渉決定)ボタンをtrueにする
    }
}
