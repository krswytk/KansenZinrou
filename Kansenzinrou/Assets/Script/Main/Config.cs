using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public enum FirstNumber
    {
        初期マイナス金額 = 12,//12-2D4or3D4
        マイナス物資 = 1,//毎ターン終了時にマイナスされる物資量
        薬剤必要金 = 2,//仕入れに必要な金額
        食料必要金 = 1,
        飲料必要金 = 1,
        道具必要金 = 1,
        仕入れ時間 = 10
    }
    public enum news
    {
        発見 = 0,//この世界で新たな感染症が発見されました
        クラスター = 1,//このターンの感染率up（クラスター発生）
        給付金 = 2,//全プレイヤーに金＋1（給付金）
        変異 = 3,//このターンに感染すると2から症状が始まる（ウィルス変異）
        体調不良 = 4,//PCR検査ランダムに1人の感染状況を開示（体調不良）
        支援 = 5,//このターン中のみ感染対策の費用が1になる(国からの支援)
        医療崩壊 = 6//このターン中のみ医者の用意出来るベッドが1になる（医療崩壊）
    }
    public enum Job
    {
        INFECTION = 0,//薬剤師
        FOOD = 1,//食料
        WATER = 2,//水
        TOOL = 3//道具
    }
    public enum SalaryNumber
    {
        薬剤師給料 = 10,//薬剤師
        食べ物屋給料 = 1,//食料
        水屋給料 = 1,//水
        道具屋給料 = 1//道具
    }

}
