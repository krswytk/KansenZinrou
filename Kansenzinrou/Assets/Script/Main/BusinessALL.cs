﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessALL : MonoBehaviour//取引関係のスクリプト//感染ガチャもこのなか
{
    MainManeger MM;
    TurnManeger TM;
    FildObject FO;
    IventAll IA;
    [HideInInspector] public bool sw;//取引開始のスイッチ

    [HideInInspector] public int Turn;//今取引をしている人のターン
    [HideInInspector] public int C;//交渉した人の人数保管用のカウンター
    [HideInInspector] public bool next;//次の人に取引を回すスイッチ

    [HideInInspector] public int[] S;//取引前の物資量
    [HideInInspector] public int[] NS;//取引後の物資量
    [HideInInspector] public int[] SI;//取引前の仕入れ数
    Player[] Player;
    Player[] CopyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        MM = GetComponent<MainManeger>();
        TM = GetComponent<TurnManeger>();
        FO = GetComponent<FildObject>();
        IA = GetComponent<IventAll>();
        sw = false;
        Turn = -1;
        C = 0;
        Allfalse();//関連ボタンをすべて隠す
        Player = MM.Player;
        FO.Countermeasures.SetActive(false);//感染症対策YESNOボタンのセット
        FO.Next.SetActive(false);//Nextボタンを非表示にする

        S = new int[4];
        NS = new int[4];
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
                next = true;//次に進む（交渉決定)ボタンをtrueにする
            }

            if (next)
            {
                if (Turn >= 4)//もし4になったら0(薬剤師)に戻す
                {
                    Turn = 0;
                }

                if (Turn == 0) FO.BusinessTurnText.text = "薬局";
                if (Turn == 1) FO.BusinessTurnText.text = "食べ物";
                if (Turn == 2) FO.BusinessTurnText.text = "水";
                if (Turn == 3) FO.BusinessTurnText.text = "道具";

                Player[Turn].SetNowSupplies(S);//取引前の物資量を保持しておく
                FO.Next.SetActive(true);//Nextボタンを表示にする
                SINOW();//取引前の仕入れ数を取得
                C++;

                if (Player[Turn].GetDeath() == false)//死亡してたら終了の処理を記述//もし死んでなければ
                {
                    FO.Countermeasures.SetActive(true);//感染対策を行うかのボタン表示
                    IA.BusinessGroupON(Turn);//順番に沿ったボタンを表示
                    next = false;
                }
                else
                {
                    Turn += 1;//1234のいずれかに　4なら↓
                }
            }
        }

        //ターン管理
        //ターンに適応したボタンの有効化

        
    }

    public void NextSW()//交渉決定用のボタン
    {
        Infection();// 感染の判定
        next = true;//次に進む（交渉決定)ボタンをtrueにする
        IA.BusinessGroupOFF(Turn);//対象取引ボタンを隠す
        FO.Next.SetActive(false);//Nextボタンを表示にする
        MM.PlaySE(2);
        if (C >= 4)
        {//4回繰り返したら//つまり全員取引を行ったら
            Allfalse();
            C = 0;
            sw = false;
            TM.SetBusinessSW();//ターンMの取引ボタンを終了に戻す
        }
        Turn += 1;//1234のいずれかに　4なら↓
        Debug.Log("交渉終了ボタンを押した");
    }
    public int GetTurn()//今の交渉順を返す
    {
        return Turn;
    }

    private void Allfalse()//交渉用のボタンをすべて隠す
    {
        for (int i = 0; i < MainManeger.PlayerNumber; i++)
        {
            IA.BusinessGroupOFF(i);
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
                            if ((MainManeger.Infectionprobability - 2) >= RandomDice.DiceRoll(10))//1,2で感染
                            { 
                                Debug.Log("感染");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" +"との取引で"+ Player[Turn].GetName() + "が感染",true);
                                Player[Turn].Setinfection(MainManeger.InfectionStage);
                            }
                        }
                        else//自分が感染している
                        {
                            if ((MainManeger.Infectionprobability) >= RandomDice.DiceRoll(10))//1,2,3,4で悪化
                            {
                                Debug.Log("悪化");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" + "との取引で" + Player[Turn].GetName() + "が悪化", true);
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
                            if ((MainManeger.Infectionprobability) >= RandomDice.DiceRoll(10))//1,2,3,4で感染
                            {
                                Debug.Log("感染");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" + "との取引で" + Player[Turn].GetName() + "が感染", true);
                                Player[Turn].Setinfection(MainManeger.InfectionStage);
                            }
                        }
                        else//自分が感染している
                        {
                            if ((MainManeger.Infectionprobability) >= RandomDice.DiceRoll(10))//1,2,3,4で悪化
                            {
                                Debug.Log("悪化");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" + "との取引で" + Player[Turn].GetName() + "が悪化", true);
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
                            if ((MainManeger.Infectionprobability) >= RandomDice.DiceRoll(10))//1,2,3,4で感染
                            {
                                Debug.Log("感染");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" + "との取引で" + Player[Turn].GetName() + "が感染", true);
                                Player[Turn].Setinfection(MainManeger.InfectionStage);
                            }
                            if ((MainManeger.Infectionprobability-2) >= RandomDice.DiceRoll(10))//1,2で感染
                            {
                                Debug.Log("相手が感染");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" + "との取引で" + Player[i].GetName() + "が感染", true);
                                Player[i].Setinfection(MainManeger.InfectionStage);//相手感染
                            }
                        }
                        else//自分が感染している
                        {
                            if ((MainManeger.Infectionprobability) >= RandomDice.DiceRoll(10))//1,2,3,4で悪化
                            {
                                Debug.Log("悪化");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" + "との取引で" + Player[Turn].GetName() + "が悪化", true);
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
                            if ((MainManeger.Infectionprobability + 2) >= RandomDice.DiceRoll(10))//1,2,3,4,5,6で感染
                            {
                                Debug.Log("感染");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" + "との取引で" + Player[Turn].GetName() + "が感染", true);
                                Player[Turn].Setinfection(MainManeger.InfectionStage);
                            }
                        }
                        else//自分が感染している
                        {
                            if ((MainManeger.Infectionprobability) >= RandomDice.DiceRoll(10))//1,2,3,4で悪化
                            {
                                Debug.Log("悪化");
                                MM.LogOut(Player[Turn].GetName() + "(購入者)" + Player[i].GetName() + "(販売者)" + "との取引で" + Player[Turn].GetName() + "が悪化", true);
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
