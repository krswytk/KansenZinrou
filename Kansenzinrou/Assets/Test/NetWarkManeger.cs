using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class NetWarkManeger : MonoBehaviourPunCallbacks, IPunObservable
{
    public int[] num;

    private void Start()
    {
        num = new int[2];
        num[0] = 0;
        num[1] = 0;

        t1 = GameObject.Find("Text1").GetComponent<Text>();
        t2 = GameObject.Find("Text2").GetComponent<Text>();
        UPText();
    }


    //数値変更で値を同期させる
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //値を送る
            stream.SendNext(num);
        }
        else
        {
            //値を受け取る
            num = (int[])stream.ReceiveNext();
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
