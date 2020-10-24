using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    BusinessALL BA;
    // Start is called before the first frame update
    void Start()
    {
        BA = GameObject.Find("Maneger").GetComponent<BusinessALL>();
    }

    public void NextSW()//交渉決定用のボタン
    {
        BA.NextSW();
    }
}
