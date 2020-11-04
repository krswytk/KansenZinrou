using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDice : MonoBehaviour//ランダム生成用の関数　どこからでも参照可能
{
    public static int DiceRoll(int Max)//引数以下の数字が返る　10 なら　1~10までの値が返る
    {
        int num;
        //Debug.Log("ダイスロールを行いました");
        //Random.InitState(System.DateTime.Now.Millisecond);

        num = Random.Range(1, Max + 1);
        Debug.Log("ダイスの値は:" + num);
        return num;
    }
}
