using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countermeasures : MonoBehaviour//感染対策用のボタンスクリプト
{
    MainManeger MM;
    FildObject FO;
    BusinessALL BA;
    // Start is called before the first frame update
    void Start()
    {
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
        FO = GameObject.Find("Maneger").GetComponent<FildObject>();
        BA = GameObject.Find("Maneger").GetComponent<BusinessALL>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        MM.Player[BA.GetTurn()].SetCountermeasures(true);//該当プレイヤーの感染対策をONにする
        GameObject.Find("Maneger").GetComponent<UIManger>().MaskON(BA.GetTurn());
        FO.Countermeasures.SetActive(false);
        MM.PlaySE(FO.SoundSE[0]);
    }

    public void No()
    {
        FO.Countermeasures.SetActive(false);
        MM.PlaySE(FO.SoundSE[3]);
    }
}
