using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessALL : MonoBehaviour//取引関係のスクリプト//感染ガチャもこのなか
{
    MainManeger MM;
    TurnManeger TM;
    FildObject FO;
    private bool sw;

    private int Turn;
    private int C;
    private static bool next;

    private int[] S;//取引前の物資量
    private int[] NS;//取引後の物資量
    private int[] SI;//取引前の仕入れ数
    Player[] Player;
    Player[] CopyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        MM = GetComponent<MainManeger>();
        TM = GetComponent<TurnManeger>();
        FO = GetComponent<FildObject>();
        sw = false;
        Turn = -1;
        C = 0;
        allfalse();//関連ボタンをすべて隠す
        Player = MM.Player;
        FO.Countermeasures.SetActive(false);

        SI = new int[4];
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
                        Turn = 3;//薬局から
                        break;
                    case 2:
                        Turn = 0;//食べ物から
                        break;
                    case 3:
                        Turn = 1;//水から
                        break;
                    case 4:
                        Turn = 2;//道具から
                        break;
                    case 5:
                        Turn = 3;//薬局から
                        break;
                    case 6:
                        Turn = 0;//食べ物から
                        break;
                    default:
                        Debug.LogError("Cord_501-交渉にて想定外のターンを取得");
                        break;

                }//誰から始めるのか判断
                next = true;//次に進む（交渉決定)ボタンをtrueにする
                C++;
            }

            if (next)
            {
                Turn += 1;//1234のいずれかに　4なら↓
                if (Turn >= 4)//もし4になったら0(薬剤師)に戻す
                {
                    Turn = 0;
                }
                if (Player[Turn].GetDeath() == false)//死亡してたら終了の処理を記述
                {
                    Player[Turn].SetNowSupplies(S);//取引前の物資量を保持しておく
                    FO.Countermeasures.SetActive(true);//感染対策を行うかのボタン表示
                    FO.BusinessGroup[Turn].SetActive(true);//順番に沿ったボタンを表示
                    SINOW();
                    if (C == 4)
                    {//4回繰り返したら//つまり全員取引を行ったら
                        allfalse();
                        C = 0;
                        sw = false;
                        TM.SetBusinessSW();//ターンMの取引ボタンを終了に戻す
                    }
                    next = false;
                }
                else
                {
                    next = false;
                }
            }
        }

        //ターン管理
        //ターンに適応したボタンの有効化

        
    }

    public void NextSW()//交渉決定用のボタン
    {
        Infection();// 感染の判定
        FO.BusinessGroup[Turn].SetActive(false);//最初の順番のものを表示
        next = true;//次に進む（交渉決定)ボタンをtrueにする
        C++;
    }
    public int GetTurn()//今の交渉順を返す
    {
        return Turn;
    }

    private void allfalse()//交渉用のボタンをすべて隠す
    {
        for (int i = 0; i < MainManeger.PlayerNumber; i++)
        {
            FO.BusinessGroup[i].SetActive(false);//隠す
        }
        FO.Next.SetActive(false);//隠す
    }

    private void Infection()//前の物資量と現在の物資量を比較する//数が一致しなかった分感染ガチャ　および　プレイヤーに反映
    {
        Player[Turn].SetNowSupplies(NS);
        for(int i = 0; i < S.Length; i++)
        {
            if (S[i] != NS[i])//取引前の値と取引後の値が一致しなかったらガチャる
            {
                if (Player[Turn].GetCountermeasures())//trueならプレイヤーは感染対策を行っている
                {
                    if (Player[i].Getinfection() == 0)//0なら取引相手は感染していない//iが0なら薬品が一致しない＝薬剤師と取引した
                    {
                        if ( Player[Turn].Getinfection() == 0)//0なら自分は感染していない
                        {
                            if ((MainManeger.Infectionprobability - 2) <= RandomDice.DiceRoll(10))//1,2で感染
                            { 
                                Debug.Log("感染");
                                Player[Turn].Setinfection(MainManeger.InfectionStage);
                            }
                        }
                        else//自分が感染している
                        {
                            if ((MainManeger.Infectionprobability) <= RandomDice.DiceRoll(10))//1,2,3,4で悪化
                            {
                                Debug.Log("悪化");
                                int c = Player[Turn].Getinfection();//現在の感染段階取得
                                c += 1;
                                Player[Turn].Setinfection(c);
                            }
                        }
                    }
                    else//取引相手は感染している
                    {
                        if (Player[Turn].Getinfection() == 0)//0なら自分は感染していない
                        {
                            if ((MainManeger.Infectionprobability) <= RandomDice.DiceRoll(10))//1,2,3,4で感染
                            {
                                Debug.Log("感染");
                                Player[Turn].Setinfection(MainManeger.InfectionStage);
                            }
                        }
                        else//自分が感染している
                        {
                            if ((MainManeger.Infectionprobability) <= RandomDice.DiceRoll(10))//1,2,3,4で悪化
                            {
                                Debug.Log("悪化");
                                int c = Player[Turn].Getinfection();//現在の感染段階取得
                                c += 1;
                                Player[Turn].Setinfection(c);
                            }
                        }
                    }
                }
                else//elseはプレイヤーは感染対策を行っていない
                {
                    if (Player[i].Getinfection() == 0)//0なら取引相手は感染していない//iが0なら薬品が一致しない＝薬剤師と取引した
                    {

                        if (Player[Turn].Getinfection() == 0)//0なら自分は感染していない
                        {
                            if ((MainManeger.Infectionprobability) <= RandomDice.DiceRoll(10))//1,2で感染
                            {
                                Debug.Log("感染");
                                Player[Turn].Setinfection(MainManeger.InfectionStage);
                            }
                            if ((MainManeger.Infectionprobability-2) <= RandomDice.DiceRoll(10))//1,2で感染
                            {
                                Debug.Log("相手が感染");
                                Player[i].Setinfection(MainManeger.InfectionStage);//相手感染
                            }
                        }
                        else//自分が感染している
                        {
                            if ((MainManeger.Infectionprobability) <= RandomDice.DiceRoll(10))//1,2,3,4で悪化
                            {
                                Debug.Log("悪化");
                                int c = Player[Turn].Getinfection();//現在の感染段階取得
                                c += 1;
                                Player[Turn].Setinfection(c);
                            }
                            Player[i].Setinfection(MainManeger.InfectionStage);//自分が感染かつ相手が非感染　＝　相手感染
                        }
                    }
                    else//取引相手は感染している
                    {

                        if (Player[Turn].Getinfection() == 0)//0なら自分は感染していない
                        {
                            if ((MainManeger.Infectionprobability + 2) <= RandomDice.DiceRoll(10))//1,2で感染
                            {
                                Debug.Log("感染");
                                Player[Turn].Setinfection(MainManeger.InfectionStage);
                            }
                        }
                        else//自分が感染している
                        {
                            if ((MainManeger.Infectionprobability) <= RandomDice.DiceRoll(10))//1,2,3,4で悪化
                            {
                                Debug.Log("悪化");
                                int c = Player[Turn].Getinfection();//現在の感染段階取得
                                c += 1;
                                Player[Turn].Setinfection(c);
                            }
                        }
                    }
                }
            }
        }
    }

    private void SINOW()//仕入れ数の取得
    {
        for (int i = 0; i < Player.Length; i++)
        {
            SI[i] = Player[i].GetPurchasing();
        }
    }
}
