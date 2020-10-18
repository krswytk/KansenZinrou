﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Job
{
    INFECTION = 0,//薬剤師
    FOOD = 1,//食料
    WATER = 2,//水
    TOOL = 3//道具
}

//プレイヤーの情報を格納するクラス
public class Player {
    
    private string Name;//プレイヤ名
    private Job Job;
    private int Food;//食べ物
    private int Water;//水
    private int Tool;//道具
    private int Money;//お金
    private int Purchasing;//仕入れ数
    private int Sell;//売値
    private int infection;//感染状況
    private bool Countermeasures;//感染対策　trueで対策

    public Player(string name,int job)
    {
        int n = 5;
        this.Name = name;
        this.Job = (Job)Enum.ToObject(typeof(Job), job);
        while (true)
        {
            n = RandomDice.DiceRoll(4) - 1;//1D4-1
            this.Food = n;
            break;
        }
        while (true)
        {
            n = RandomDice.DiceRoll(4) - 1;//1D4-1
            if(this.Food != n)
            {
                this.Water = n;//1D4-1
                break;
            }
        }
        while (true)
        {
            n = RandomDice.DiceRoll(4) - 1;//1D4-1
            if (this.Water != n)
            {
                this.Tool = n;//1D4-1
                break;
            }
        }
        this.Purchasing = 0;//仕入れ数は0
        this.Sell = 0;//売値は0
        this.infection = 0;//感染状況は0
        this.Countermeasures = false;//感染対策はfalse
        switch (Job)
        {
            case Job.INFECTION:
                this.Money = (int)MainManeger.FirstNumber.初期マイナス金額 - (this.Food + this.Water + this.Tool);//初期金額の設定

                //Debug.Log("職業が" + this.Job.ToString() + "の" + this.Name + " が誕生した。");//最終確認用のデバックログ
                break;
            case Job.FOOD:
                this.Food = 1000;//食料なら事実状の無限にする
                this.Money = (int)MainManeger.FirstNumber.初期マイナス金額 - (this.Water + this.Tool);//初期金額の設定

                //Debug.Log("職業が" + this.Job.ToString() + "の" + this.Name + " が誕生した。");//最終確認用のデバックログ
                break;
            case Job.WATER:
                this.Water = 1000;//水なら事実状の無限にする
                this.Money = (int)MainManeger.FirstNumber.初期マイナス金額 - (this.Food + this.Tool);//初期金額の設定

                //Debug.Log("職業が" + this.Job.ToString() + "の" + this.Name + " が誕生した。");//最終確認用のデバックログ
                break;
            case Job.TOOL:
                this.Tool = 1000;//道具なら事実状の無限にする
                this.Money = (int)MainManeger.FirstNumber.初期マイナス金額 - (this.Food + this.Water);//初期金額の設定

                //Debug.Log("職業が" + this.Job.ToString() + "の" + this.Name + " が誕生した。");//最終確認用のデバックログ
                break;
            default:break;
        }
        /*
        Debug.Log(this.Food);
        Debug.Log(this.Water);
        Debug.Log(this.Tool);
        */
    }//プレイヤ生成用のコンストタクタ

    public void AllSuppliesMinus()//ターン終了時の全物資-1の処理
    {
        this.Food = this.Food - (int)MainManeger.FirstNumber.マイナス物資;//
        this.Water = this.Water - (int)MainManeger.FirstNumber.マイナス物資;//
        this.Tool = this.Tool - (int)MainManeger.FirstNumber.マイナス物資;//
    }//ターン終了時の全物資-1の処理

    public void PlayerDate()
    {
        Debug.Log(
            "職業" + this.Job + "\n" +
            "名前" + this.Name + "\n"+
            "食べ物" + this.Food + "\n" +
            "飲み物" + this.Water + "\n" +
            "お洋服" + this.Tool + "\n" +
            "お金" + this.Money + "\n" +
            "感染状況" + this.infection + "\n"
            );
    }
    

    //各ゲッターとセッター
    public string GetName()
    {
        return this.Name;
    }//プレイヤ名をリターン
    public int GetFood()
    {
        return this.Food;
    }//食料値をリターン
    public int GetWater()
    {
        return this.Water;
    }//水をリターン
    public int GetTool()
    {
        return this.Tool;
    }//道具をリターン
    public int GetMoney()
    {
        return this.Money;
    }//お金をリターン
    public int GetPurchasing()
    {
        return this.Purchasing;
    }//仕入れ数をリターン
    public int GetSell()
    {
        return this.Sell;
    }//売値をリターン
    public int Getinfection()
    {
        return this.infection;
    }//感染状況をリターン
    public bool GetCountermeasures()
    {
        return this.Countermeasures;
    }//対策状況をリターン
    public void SetName(string Name)
    {
        this.Name = Name;
    }//プレイヤ名を入れ込み
    public void SetFood(int Food)
    {
        this.Food = Food;
    }//食料値を入れ込み
    public void SetWater(int Water)
    {
        this.Water = Water;
    }//水を入れ込み
    public void SetTool(int Tool)
    {
        this.Tool = Tool;
    }//道具を入れ込み
    public void SetMoney(int Money)
    {
        this.Money = Money;
    }//お金を入れ込み
    public void SetPurchasing(int Purchasing)
    {
        this.Purchasing = Purchasing;
    }//仕入れ数を入れ込み
    public void SetSell(int Sell)
    {
        this.Sell = Sell;
    }//売値を入れ込み
    public void Setinfection(int infection)
    {
        this.infection = infection;
    }//感染状況を入れ込み
    public void SetCountermeasures(bool Countermeasures)
    {
        this.Countermeasures = Countermeasures;
    }//対策状況を入れ込み
}//Playerクラスの元