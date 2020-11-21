using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

//ネットワーク接続用のscript　初期設定を含む


public class ConectNetWork : MonoBehaviourPunCallbacks
{
    private string OnlineRoomName = "Room";

    int[] num = new int[4];
    public GameObject[] t; 

    public void Start()//シーンの最初に呼び出す
    {
        PhotonNetwork.GameVersion = "1.0";
        Debug.Log("全接続を開始");//サーバー接続をデバックログで出力
        ConnectPhoton(false);//鯖、ロビー、ルーム接続処理を開始 trueでオフラインでスタート
        num[0] = 0; num[1] = 0; num[2] = 0; num[3] = 0;
        UPText(1);
        UPText(2);
    }


    // Photonサーバ接続処理
    public void ConnectPhoton(bool boolOffline)
    {
        if (boolOffline)
        {
            // オフラインモードを設定 //絶対に実行させることはないはず
            PhotonNetwork.OfflineMode = true; // OnConnectedToMaster()が呼ばれる
            return;
        }
        // Photonサーバに接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // Photonサーバ切断処理
    public void DisConnectPhoton()
    {
        Debug.Log("サーバーから切断");//サーバー接続をデバックログで出力
        PhotonNetwork.Disconnect();
    }

    // コールバック：Photonサーバ接続失敗
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("サーバーへの接続失敗");//サーバー接続をデバックログで出力
        base.OnDisconnected(cause);
    }

    // コールバック：Photonサーバ接続完了
    public override void OnConnectedToMaster()
    {
        Debug.Log("サーバーへの接続完了");//サーバー接続をデバックログで出力
        // ロビーに接続
        PhotonNetwork.JoinLobby();
        //PhotonNetwork.LeaveLobby();//ロビーから退出する処理
    }

    // コールバック：ロビー接続完了
    public override void OnJoinedLobby()
    {
        Debug.Log("ロビーへの接続完了");//ロビー接続をデバックログで出力
        CreateRoom(OnlineRoomName);//ルームの作成または接続//設定されたルーム名でルームを制作
    }

    // コールバック：ロビー離脱完了
    public override void OnLeftLobby()
    {
        Debug.Log("ロビーから離脱");//ロビー接続をデバックログで出力
        base.OnLeftLobby();
    }

    // ルーム作成,入室処理
    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    // ルーム入室処理
    public void ConnectToRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    // コールバック：ルーム作成完了
    public override void OnCreatedRoom()
    {
        Debug.Log("ルームの作成");//ルームの作成をデバックログで出力

        base.OnCreatedRoom();
    }

    // コールバック：ルーム作成失敗
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("ルームの作成が失敗");//ルームの作成が失敗をデバックログで出力
        //今回の場合ルームがすでに制作されていたということ//なので作成ではなく、入室処理を行う
        ConnectToRoom(OnlineRoomName);

        base.OnCreateRoomFailed(returnCode, message);
    }

    // コールバック：ルームに入室した時
    public override void OnJoinedRoom()
    {
        Debug.Log("ルーム入室");//ルーム入室をデバックログで出力
        base.OnJoinedRoom();
    }

    public int Get(int i)
    {
        return num[i-1];
    }
    public void Set(int num ,int i)
    {
        this.num[i - 1] = num;
    }
    public void UPText(int i)
    {
        t[i-1].GetComponent<Text>().text = num[i-1].ToString();
    }
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
}
