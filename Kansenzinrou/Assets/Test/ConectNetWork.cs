using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;

//ネットワーク接続用のscript　初期設定を含む


public class ConectNetWork : MonoBehaviourPunCallbacks
{

    // Use this for initialization
    void Start()
    {
        ConnectPhoton(false);//サーバ接続処理を呼び出す　falseでオンライン　trueでオフラインで実行する
    }

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
    
    public override void OnConnectedToMaster()//サーバ接続時のコールバック　サーバ接続と同時に呼び出し、ロビーに接続する
    {
        PhotonNetwork.JoinLobby();//ランダムに部屋に入る　ない場合は生成する
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        //PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }
    public override void OnJoinedLobby()//ロビー接続時のコールバック　ロビー接続と同時に呼び出し、ルームに接続する
    {
        base.OnJoinedLobby();
    }









    public void DisConnectPhoton()
    {
        PhotonNetwork.Disconnect();
    }




    //ルームに入室後に呼び出される
    /*public override void OnJoinedRoom()
    {
        //生成座標をランダムで決定
        var v = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
        //キャラクターを生成
        //GameObject NetTextOB = PhotonNetwork.Instantiate("NetTextOB", v, Quaternion.identity, 0);
        //自分だけが操作できるようにスクリプトを有効にする
    }*/


    void OnGUI()
    {
        //ログインの状態を画面上に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

}
