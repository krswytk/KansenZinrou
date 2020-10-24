using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasingButton : MonoBehaviour//仕入れ数調整用ボタンスクリプト//売り物の個数調整に使用
{
    MainManeger MM;
    UIManger UIM;
    FildObject FO;
    // Start is called before the first frame update
    void Start()
    {
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        UIM = GameObject.Find("Maneger").GetComponent<UIManger>();
        FO = GameObject.Find("Maneger").GetComponent<FildObject>();

    }

    public void DM()
    {
        int M = MM.Player[0].GetMoney();//対応プレイヤーの所持金を格納
        int P = MM.Player[0].GetPurchasing();//対応プレイヤーの仕入れ数を格納
        if(P >= 1)//1つ以上仕入れている
        {
            P -= 1;//仕入れ数を1つ減らす
            M += (int)Config.FirstNumber.薬仕入れ金;//仕入れ金を返却
            MM.Player[0].SetMoney(M);//所持金に反映
            MM.Player[0].SetPurchasing(P);//仕入れ数に反映
            MM.PlaySE(3);
        }
        UIM.TableUpdate();
    }
    public void DP()
    {
        int M = MM.Player[0].GetMoney();//対応プレイヤーの所持金を格納
        int P = MM.Player[0].GetPurchasing();//対応プレイヤーの仕入れ数を格納
        if (M >= (int)Config.FirstNumber.薬仕入れ金)//1つ以上仕入れられるお金がある
        { 
            P += 1;//仕入れ数を1つ増やす
            M -= (int)Config.FirstNumber.薬仕入れ金;//仕入れ金を徴収
            MM.Player[0].SetMoney(M);//所持金に反映
            MM.Player[0].SetPurchasing(P);//仕入れ数に反映
            MM.PlaySE(3);
        }
        UIM.TableUpdate();
    }
    public void FM()
    {
        int M = MM.Player[1].GetMoney();//対応プレイヤーの所持金を格納
        int P = MM.Player[1].GetPurchasing();//対応プレイヤーの仕入れ数を格納
        if (P >= 1)//1つ以上仕入れている
        {
            P -= 1;//仕入れ数を1つ減らす
            M += (int)Config.FirstNumber.食料仕入れ金;//仕入れ金を返却
            MM.Player[1].SetMoney(M);//所持金に反映
            MM.Player[1].SetPurchasing(P);//仕入れ数に反映
            MM.PlaySE(3);
        }
        UIM.TableUpdate();
    }
    public void FP()
    {
        int M = MM.Player[1].GetMoney();//対応プレイヤーの所持金を格納
        int P = MM.Player[1].GetPurchasing();//対応プレイヤーの仕入れ数を格納
        if (M >= (int)Config.FirstNumber.食料仕入れ金)//1つ以上仕入れられるお金がある
        {
            P += 1;//仕入れ数を1つ増やす
            M -= (int)Config.FirstNumber.食料仕入れ金;//仕入れ金を徴収
            MM.Player[1].SetMoney(M);//所持金に反映
            MM.Player[1].SetPurchasing(P);//仕入れ数に反映
            MM.PlaySE(3);
        }
        UIM.TableUpdate();
    }
    public void WM()
    {
        int M = MM.Player[2].GetMoney();//対応プレイヤーの所持金を格納
        int P = MM.Player[2].GetPurchasing();//対応プレイヤーの仕入れ数を格納
        if (P >= 1)//1つ以上仕入れている
        {
            P -= 1;//仕入れ数を1つ減らす
            M += (int)Config.FirstNumber.飲料仕入れ金;//仕入れ金を返却
            MM.Player[2].SetMoney(M);//所持金に反映
            MM.Player[2].SetPurchasing(P);//仕入れ数に反映
            MM.PlaySE(3);
        }
        UIM.TableUpdate();
    }
    public void WP()
    {
        int M = MM.Player[2].GetMoney();//対応プレイヤーの所持金を格納
        int P = MM.Player[2].GetPurchasing();//対応プレイヤーの仕入れ数を格納
        if (M >= (int)Config.FirstNumber.飲料仕入れ金)//1つ以上仕入れられるお金がある
        {
            P += 1;//仕入れ数を1つ増やす
            M -= (int)Config.FirstNumber.飲料仕入れ金;//仕入れ金を徴収
            MM.Player[2].SetMoney(M);//所持金に反映
            MM.Player[2].SetPurchasing(P);//仕入れ数に反映
            MM.PlaySE(3);
        }
        UIM.TableUpdate();
    }
    public void TM()
    {
        int M = MM.Player[3].GetMoney();//対応プレイヤーの所持金を格納
        int P = MM.Player[3].GetPurchasing();//対応プレイヤーの仕入れ数を格納
        if (P >= 1)//1つ以上仕入れている
        {
            P -= 1;//仕入れ数を1つ減らす
            M += (int)Config.FirstNumber.道具仕入れ金;//仕入れ金を返却
            MM.Player[3].SetMoney(M);//所持金に反映
            MM.Player[3].SetPurchasing(P);//仕入れ数に反映
            MM.PlaySE(3);
        }
        UIM.TableUpdate();
    }
    public void TP()
    {
        int M = MM.Player[3].GetMoney();//対応プレイヤーの所持金を格納
        int P = MM.Player[3].GetPurchasing();//対応プレイヤーの仕入れ数を格納
        if (M >= (int)Config.FirstNumber.道具仕入れ金)//1つ以上仕入れられるお金がある
        {
            P += 1;//仕入れ数を1つ増やす
            M -= (int)Config.FirstNumber.道具仕入れ金;//仕入れ金を徴収
            MM.Player[3].SetMoney(M);//所持金に反映
            MM.Player[3].SetPurchasing(P);//仕入れ数に反映
            MM.PlaySE(3);
        }
        UIM.TableUpdate();
    }
}
