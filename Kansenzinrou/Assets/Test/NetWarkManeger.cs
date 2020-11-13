using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class NetWarkManeger : MonoBehaviourPunCallbacks, IPunObservable
{
    public int[] num;

    private void Start()
    {
        PhotonNetwork.SendRate = 20; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 10; // 1秒間にオブジェクト同期を行う回数

        num = new int[2];
        num[0] = 0;
        num[1] = 0;

        t1 = GameObject.Find("Text1").GetComponent<Text>();
        t2 = GameObject.Find("Text2").GetComponent<Text>();
        UPText();
    }

    private void Update()
    {
        var hashtable = new ExitGames.Client.Photon.Hashtable();
        hashtable["Score"] = 100;
        PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
    }


    //数値変更で値を同期させる
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("同期開始");
        //送信時
        if (stream.IsWriting)
        {
            Debug.Log("データ送信");
            //値を送る
            stream.SendNext(num);
        }//受信時
        else
        {
            Debug.Log("データ受信");
            //値を受け取る
            this.num = (int[])stream.ReceiveNext();
        }
        UPText();
    }

    private Text t1, t2;
    public void UPText()
    {
        t1.text = num[0].ToString();
        t2.text = num[1].ToString();
    }

    public int Get(int i)
    {
        return num[i];
    }

    public void Set(int i,int num)
    {
        this.num[i] = num;
    }
}
