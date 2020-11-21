using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Buttontest : MonoBehaviourPunCallbacks
{

    [PunRPC]
    public void UP1()
    {
        int num = GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().Get(1);
        num++;
        GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().Set(num, 1);
        GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().UPText(1);
    }

    [PunRPC]
    public void DOWN1()
    {
        int num = GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().Get(1);
        num--;
        GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().Set(num, 1);
        GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().UPText(1);
    }

    [PunRPC]
    public void UP2()
    {
        int num = GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().Get(2);
        num++;
        GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().Set(num, 2);
        GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().UPText(2);
    }

    [PunRPC]
    public void DOWN2()
    {
        int num = GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().Get(2);
        num--;
        GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().Set(num, 2);
        GameObject.Find("NetWorkManeger").GetComponent<ConectNetWork>().UPText(2);
    }

    public void BUP1()
    {
        photonView.RPC(nameof(UP1), RpcTarget.All);
    }
    public void BDOWN1()
    {
        photonView.RPC(nameof(DOWN1), RpcTarget.All);
    }
    public void BUP2()
    {
        photonView.RPC(nameof(UP2), RpcTarget.All);
    }
    public void BDOWN2()
    {
        photonView.RPC(nameof(DOWN2), RpcTarget.All);
    }
}
