using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogOut : MonoBehaviour
{
    string s;
    MainManeger MM;
    private void Start()
    {
        MM = GameObject.Find("Maneger").GetComponent<MainManeger>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)){

            for (int i = 0; i < MM.AllLog.Length; i++) {
                s += MM.AllLog[i];
                s += "\n\r";
                if (MM.AllLog[i] == null || MM.AllLog[i] == "") break;
            }

            Debug.Log(s);

        }


    }
}
