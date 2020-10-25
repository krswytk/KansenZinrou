﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    //値の設定に使用するもの
    public enum FirstNumber//初期設定の値
    {
        //ゲームの設定数値
        初期マイナス金額 = 12,//12-2D4or3D4
        マイナス物資 = 1,//毎ターン終了時にマイナスされる物資量
        薬仕入れ金= 2,//仕入れに必要な金額
        食料仕入れ金 = 1,
        飲料仕入れ金 = 1,
        道具仕入れ金 = 1,
        仕入れ時間 = 10,//秒で記入
        感染確率 = 4,//感染確率1-4で感染
        感染増加 = 1,//ウィルス変異時にいくつから感染が始まるか
        感染対策 = 2,//感染対策に必要な金額
        薬最大数 = 10,//薬剤師が仕入れられる最大数
        NextStage = 1,//次のフェイズに進む時間
        感染死亡 = 4,//この値以上で死ぬ

    }

    public enum newsNumber//情勢イベントで使用する数値
    {
        感染確率 = 5,//感染確率1-4で感染
        給付金額 = 1, 
        感染増加 = 2,//ウィルス変異時にいくつから感染が始まるか
        感染対策 = 1,//感染対策に必要な金額
        薬最大数 = 1//薬剤師が仕入れられる最大数
    }


    public enum SalaryNumber
    {
        薬剤師給料 = 10,//薬剤師
        食べ物屋給料 = 1,//食料
        水屋給料 = 1,//水
        道具屋給料 = 1//道具
    }

    //視認性を上げるためのeunu↓///////////////
    public enum Job
    {
        INFECTION = 0,//薬剤師
        FOOD = 1,//食料
        WATER = 2,//水
        TOOL = 3//道具
    }
    public enum Stage
    {
        //仕入れフェイズ///////////////
        待機 = 0,
        情勢イベント表示  = 1,
        感染状態表示  = 2,
        給料配布  = 3,
        仕入れを0にする  = 4,
        仕入れ時間開始  = 5,
        仕入れ中  = 6,
        仕入れ終了  = 7,
        取引  = 8,
        全ターン終了  = 9,//薬使用を含める
        判定  = 10,
        情勢イベント削除 = 11,
        シーン切り替え待機 = 12//ゲーム終了に移行　フェードを1回に抑えるために移動する
    }

    public enum news
    {
        何もない = -1,//情勢イベント待機の状態
        発見 = 0,//この世界で新たな感染症が発見されました
        クラスター = 1,//このターンの感染率up（クラスター発生）
        給付金 = 2,//全プレイヤーに金＋1（給付金）
        変異 = 3,//このターンに感染すると2から症状が始まる（ウィルス変異）
        体調不良 = 4,//PCR検査ランダムに1人の感染状況を開示（体調不良）
        支援 = 5,//このターン中のみ感染対策の費用が1になる(国からの支援)
        医療崩壊 = 6//このターン中のみ医者の用意出来るベッドが1になる（医療崩壊）
    }


    /////////////////メモ
    public enum Ero
    {
        UIマネージャー = 1,
        プレイヤークラス = 2,
        イベントオール = 3,
        ターンマネージャー = 4
    }

    /*
    public void setInfectedPerson(int InfectedPerson, int date) { m_InfectedPerson[date] = InfectedPerson; }
    public void setMoney(int Money, int date) { m_Money[date] = Money; }
    使い方　setInfectedPerspn(感染者数、日にち(1~6))
    setMoney(総合金額、日にち(1~6))
    */
}
