using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessALL : MonoBehaviour//取引関係のスクリプト
{
    MainManeger MM;
    TurnManeger TM;
    private bool sw;
    // Start is called before the first frame update
    void Start()
    {
        MM = GetComponent<MainManeger>();
        TM = GetComponent<TurnManeger>();
        sw = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TM.GetBusinessSW()) //取引開始スイッチがONになっていたら
        {
            if(sw == false){//スイッチがONになったら1度呼ばれる


                sw = true;
            }
        }

        //ターン管理
        //ターンに適応したボタンの有効化

        
    }
}
