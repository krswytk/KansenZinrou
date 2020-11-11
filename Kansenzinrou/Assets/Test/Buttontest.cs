using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Buttontest : MonoBehaviourPunCallbacks
{
    public void UP1()
    {
        int num = GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().Get(0);
        num++;
        GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().Set(0,num);
        GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().UPText();
    }
    public void DOWN1()
    {
        int num = GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().Get(0);
        num--;
        GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().Set(0, num);
        GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().UPText();
    }
    public void UP2()
    {
        int num = GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().Get(1);
        num++;
        GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().Set(1, num);
        GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().UPText();
    }
    public void DOWN2()
    {
        int num = GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().Get(1);
        num--;
        GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().Set(1, num);
        GameObject.Find("NetWorkManeger").GetComponent<NetWarkManeger>().UPText();
    }
}
