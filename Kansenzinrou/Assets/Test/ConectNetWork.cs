using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;

//ネットワーク接続用のscript　初期設定を含む


public class ConectNetWork : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        ConnectPhoton(false);//鯖、ロビー、ルーム接続処理を開始 trueでオフラインでスタート
    }

    // Photonサーバ接続処理
    public void ConnectPhoton(bool boolOffline)
    {
        if (boolOffline)
        {
            // オフラインモードを設定
            PhotonNetwork.OfflineMode = true; // OnConnectedToMaster()が呼ばれる
            return;
        }
        // Photonサーバに接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // Photonサーバ切断処理
    public void DisConnectPhoton()
    {
        PhotonNetwork.Disconnect();
    }

    // コールバック：Photonサーバ接続失敗
    public override void OnDisconnected(DisconnectCause cause)
    {
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
        base.OnJoinedLobby();
    }

    // コールバック：ロビー離脱完了
    public override void OnLeftLobby()
    {
        base.OnLeftLobby();
    }

    // コールバック：ルーム一覧更新処理
    // (ロビーに入室した時、他のプレイヤーが更新した時のみ)
    
        /*
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        // ルーム一覧更新
        foreach (var info in roomList)
        {
            if (!info.RemovedFromList)
            {
                // 更新データが削除でない場合
                roomDispList.Add(info);
            }
            else
            {
                // 更新データが削除の場合
                roomDispList.Remove(info);
            }
        }
    }*/


    // ルーム作成・入室処理
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
        base.OnCreateRoomFailed(returnCode, message);
    }

    // コールバック：ルームに入室した時
    public override void OnJoinedRoom()
    {
        Debug.Log("ルーム入室");//ルーム入室をデバックログで出力
        base.OnJoinedRoom();
    }
}
