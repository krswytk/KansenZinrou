using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessButtons : MonoBehaviour//取引時に使用するボタンスクリプト
{
    MainManeger MM;
    FildObject FO;
    BusinessALL BA;//ここのint[]Sには現在取引中の役職の開始前の物資量が入っている//ここのint[]SIには仕入れ数が入っている
    UIManger UIM;

    Player[] Player;
    // Start is called before the first frame update
    void Start()
    {

        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        FO = GameObject.Find("Maneger").GetComponent<FildObject>();
        BA = GameObject.Find("Maneger").GetComponent<BusinessALL>();
        UIM = GameObject.Find("Maneger").GetComponent<UIManger>();
        Player = MM.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private int num;//汎用コピー用変数
    public void MP()//薬の購入
    {
        if (Player[0].GetPurchasing() > 0)//まず食料の仕入れがあるか確認
        {
            if (Player[BA.GetTurn()].GetMoney() >= Player[0].GetSell())//次に購入できるお金があるか確認//所持金が仕入れ以上ある
            {
                //全部問題なかったら
                num = Player[BA.GetTurn()].GetMedicine();//食料値取得
                num += 1;//食料値増加
                Player[BA.GetTurn()].SetMedicine(num);//食料値反映
                //食料＋

                num = Player[BA.GetTurn()].GetMoney();//お金取得
                num -= Player[0].GetSell();//お金減少
                Player[BA.GetTurn()].SetMoney(num);//お金反映
                //お金ー

                num = Player[0].GetPurchasing();//仕入れ取得
                num -= 1;//仕入れ減少
                Player[0].SetPurchasing(num);//仕入れ反映
                                             //仕入れマイナス-

                UIM.TableUpdate();
                MM.PlaySE(0);
            }
        }
    }
    public void FP()//食料の購入
    {
        //Debug.Log("食料購入を押した");
        if (Player[1].GetPurchasing() > 0)//まず食料の仕入れがあるか確認
        {
            //Debug.Log("食料仕入れ数十分");
            if (Player[BA.GetTurn()].GetMoney() >= Player[1].GetSell())//次に購入できるお金があるか確認//所持金が仕入れ以上ある
            {
                //Debug.Log("購入数に届く所持金を持っている");
                //全部問題なかったら
                num = Player[BA.GetTurn()].GetFood();//食料値取得
                num += 1;//食料値増加
                Player[BA.GetTurn()].SetFood(num);//食料値反映
                //食料＋

                num = Player[BA.GetTurn()].GetMoney();//お金取得
                num -= Player[1].GetSell();//お金減少
                Player[BA.GetTurn()].SetMoney(num);//お金反映
                //お金ー

                num = Player[1].GetPurchasing();//仕入れ取得
                num -= 1;//仕入れ減少
                Player[1].SetPurchasing(num);//仕入れ反映
                                             //仕入れマイナス-

                UIM.TableUpdate();
                MM.PlaySE(0);
            }
        }
    }
    public void WP()//水の購入
    {
        if (Player[2].GetPurchasing() > 0)//まず食料の仕入れがあるか確認
        {
            if (Player[BA.GetTurn()].GetMoney() >= Player[2].GetSell())//次に購入できるお金があるか確認//所持金が仕入れ以上ある
            {
                //全部問題なかったら
                num = Player[BA.GetTurn()].GetWater();//食料値取得
                num += 1;//食料値増加
                Player[BA.GetTurn()].SetWater(num);//食料値反映
                //食料＋

                num = Player[BA.GetTurn()].GetMoney();//お金取得
                num -= Player[2].GetSell();//お金減少
                Player[BA.GetTurn()].SetMoney(num);//お金反映
                //お金ー

                num = Player[2].GetPurchasing();//仕入れ取得
                num -= 1;//仕入れ減少
                Player[2].SetPurchasing(num);//仕入れ反映
                                             //仕入れマイナス-

                UIM.TableUpdate();
                MM.PlaySE(0);
            }
        }
    }
    public void TP()//道具の購入
    {
        if (Player[3].GetPurchasing() > 0)//まず食料の仕入れがあるか確認
        {
            if (Player[BA.GetTurn()].GetMoney() >= Player[3].GetSell())//次に購入できるお金があるか確認//所持金が仕入れ以上ある
            {
                //全部問題なかったら
                num = Player[BA.GetTurn()].GetTool();//食料値取得
                num += 1;//食料値増加
                Player[BA.GetTurn()].SetTool(num);//食料値反映
                //食料＋

                num = Player[BA.GetTurn()].GetMoney();//お金取得
                num -= Player[3].GetSell();//お金減少
                Player[BA.GetTurn()].SetMoney(num);//お金反映
                //お金ー

                num = Player[3].GetPurchasing();//仕入れ取得
                num -= 1;//仕入れ減少
                Player[3].SetPurchasing(num);//仕入れ反映
                                             //仕入れマイナス-

                UIM.TableUpdate();
                MM.PlaySE(0);
            }
        }
    }
    //SIー仕入れ数を格納

    public void MM_()//薬の返却
    {
        //もともと持っている数よりはマイナスできない
        //今の持っている数　－　もともと持っている数　＞　1以上　なら返却できる
        /*
        Debug.Log("Player[BA.GetTurn()].GetMedicine() : " + Player[BA.GetTurn()].GetMedicine());
        Debug.Log("BA.GetTurn() : " + BA.GetTurn());
        Debug.Log("BA.S[0] : " + BA.S[0]);
        */
        if (Player[BA.GetTurn()].GetMedicine() - BA.S[0] > 0)//取引後と取引前前の確認            //全部問題なかったら
        {
            num = Player[BA.GetTurn()].GetMedicine();//薬値取得
            num -= 1;//薬値減少
            Player[BA.GetTurn()].SetMedicine(num);//薬値反映
                                                  //薬-

            num = Player[BA.GetTurn()].GetMoney();//お金取得
            num += Player[0].GetSell();//お金増加
            Player[BA.GetTurn()].SetMoney(num);//お金反映
                                               //お金+

            num = Player[0].GetPurchasing();//仕入れ取得
            num += 1;//仕入れ増加
            Player[0].SetPurchasing(num);//仕入れ反映
                                         //仕入れ+元に戻す

            UIM.TableUpdate();
            MM.PlaySE(3);
        }
    }
    public void FM_()//食料の返却
    {
        if (Player[BA.GetTurn()].GetFood() - BA.S[1] > 0)//取引後と取引前前の確認            //全部問題なかったら
        {
            num = Player[BA.GetTurn()].GetFood();//薬値取得
            num -= 1;//薬値減少
            Player[BA.GetTurn()].SetFood(num);//薬値反映
                                                  //薬-

            num = Player[BA.GetTurn()].GetMoney();//お金取得
            num += Player[1].GetSell();//お金増加
            Player[BA.GetTurn()].SetMoney(num);//お金反映
                                               //お金+

            num = Player[1].GetPurchasing();//仕入れ取得
            num += 1;//仕入れ増加
            Player[1].SetPurchasing(num);//仕入れ反映
                                         //仕入れ+元に戻す

            UIM.TableUpdate();
            MM.PlaySE(3);
        }
    }
    public void WM_()//水の返却
    {
        if (Player[BA.GetTurn()].GetWater() - BA.S[2] > 0)//取引後と取引前前の確認            //全部問題なかったら
        {
            num = Player[BA.GetTurn()].GetWater();//薬値取得
            num -= 1;//薬値減少
            Player[BA.GetTurn()].SetWater(num);//薬値反映
                                                  //薬-

            num = Player[BA.GetTurn()].GetMoney();//お金取得
            num += Player[2].GetSell();//お金増加
            Player[BA.GetTurn()].SetMoney(num);//お金反映
                                               //お金+

            num = Player[2].GetPurchasing();//仕入れ取得
            num += 1;//仕入れ増加
            Player[2].SetPurchasing(num);//仕入れ反映
                                         //仕入れ+元に戻す

            UIM.TableUpdate();
            MM.PlaySE(3);
        }
    }
    public void TM_()//道具の返却
    {
        if (Player[BA.GetTurn()].GetTool() - BA.S[3] > 0)//取引後と取引前前の確認            //全部問題なかったら
        {
            num = Player[BA.GetTurn()].GetTool();//薬値取得
            num -= 1;//薬値減少
            Player[BA.GetTurn()].SetTool(num);//薬値反映
                                                  //薬-

            num = Player[BA.GetTurn()].GetMoney();//お金取得
            num += Player[3].GetSell();//お金増加
            Player[BA.GetTurn()].SetMoney(num);//お金反映
                                               //お金+

            num = Player[3].GetPurchasing();//仕入れ取得
            num += 1;//仕入れ増加
            Player[3].SetPurchasing(num);//仕入れ反映
                                         //仕入れ+元に戻す

            UIM.TableUpdate();
            MM.PlaySE(3);
        }
    }
}
