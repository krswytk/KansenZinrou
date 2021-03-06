﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell : MonoBehaviour//売値の調整ボタン用スクリプト//売り物の売値調整でで使用　
{
    MainManeger MM;
    UIManger UIM;
    // Start is called before the first frame update
    void Start()
    {
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        UIM = GameObject.Find("Maneger").GetComponent<UIManger>();

    }

    public void SDM()
    {
        int M = MM.Player[0].GetSell();//対応プレイヤーの売値を格納
        if (M >= 1)//1以上の売値になっている
        {
            M -= 1;//仕入れ金を返却
            MM.Player[0].SetSell(M);//売値に反映
            UIM.TableUpdate();
            // Debug.Log("薬の売値を減少");
            MM.PlaySE(3);
        }
    }
    public void SDP()
    {
        int M = MM.Player[0].GetSell();//対応プレイヤーの売値を格納
        M += 1;
        MM.Player[0].SetSell(M);//売値に反映
        UIM.TableUpdate();
        //Debug.Log("薬の売値を上昇");
        MM.PlaySE(0);
    }
    public void SFM()
    {
        int M = MM.Player[1].GetSell();//対応プレイヤーの売値を格納
        if (M >= 1)//1以上の売値になっている
        {
            M -= 1;//仕入れ金を返却
            MM.Player[1].SetSell(M);//売値に反映
            UIM.TableUpdate();
            //Debug.Log("食料の売値を減少");
            MM.PlaySE(3);
        }
    }
    public void SFP()
    {
        int M = MM.Player[1].GetSell();//対応プレイヤーの売値を格納
        M += 1;
        MM.Player[1].SetSell(M);//売値に反映
        UIM.TableUpdate();
        //Debug.Log("食料の売値を上昇");
        MM.PlaySE(0);
    }
    public void SWM()
    {
        int M = MM.Player[2].GetSell();//対応プレイヤーの売値を格納
        if (M >= 1)//1以上の売値になっている
        {
            M -= 1;//仕入れ金を返却
            MM.Player[2].SetSell(M);//売値に反映
            UIM.TableUpdate();
            //Debug.Log("水の売値を減少");
            MM.PlaySE(3);
        }
    }
    public void SWP()
    {
        int M = MM.Player[2].GetSell();//対応プレイヤーの売値を格納
        M += 1;
        MM.Player[2].SetSell(M);//売値に反映
        UIM.TableUpdate();
        //Debug.Log("水の売値を上昇");
        MM.PlaySE(0);
    }
    public void STM()
    {
        int M = MM.Player[3].GetSell();//対応プレイヤーの売値を格納
        if (M >= 1)//1以上の売値になっている
        {
            M -= 1;//仕入れ金を返却
            MM.Player[3].SetSell(M);//売値に反映
            UIM.TableUpdate();
            //Debug.Log("道具の売値を減少");
            MM.PlaySE(3);
        }
    }
    public void STP()
    {
        int M = MM.Player[3].GetSell();//対応プレイヤーの売値を格納
        M += 1;
        MM.Player[3].SetSell(M);//売値に反映
        UIM.TableUpdate();
        //Debug.Log("道具の売値を上昇");
        MM.PlaySE(0);
    }
}
