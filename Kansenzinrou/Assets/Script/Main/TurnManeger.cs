using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManeger : MonoBehaviour
{
    private int Turn;
    UIManger UIM;
    // Start is called before the first frame update
    void Start()
    {
        Turn = 1;
        UIM = GetComponent<UIManger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Turn == 1)
        {
            Debug.Log(Turn + "ターン目開始");
            UIM.TableUpdate();//表更新
            UIM.NewsDisplay(true);//情勢イベント表示
            UIM.InfectionDisplay();//感染状態表示
            Turn += 1;
        }
    }
}
