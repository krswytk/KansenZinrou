using Photon.Pun;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承すると、photonViewプロパティが使えるようになる
public class GamePlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    private SpriteRenderer spriteRenderer;
    private float hue = 0f; // 色相値
    private bool isMoving = false; // 移動中フラグ

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ChangeBodyColor();
    }

    private void Update()
    {
        //自分の生成オブジェクトか判断
       // if (photonView.IsMine)
       // {
            //移動入力量を保持
            var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            //時間で距離を算出
            var dv = 6f * Time.deltaTime * direction;
            //移動量を反映
            transform.Translate(dv.x, dv.y, 0f);

            // 移動中なら色相値を変化させていく
            //direction.magnitude移動ベクトル　移動する　＝　ベクトルが発生する　> 0  つまり移動したことになる
            isMoving = direction.magnitude > 0f;
            if (isMoving)
            {
                //色を変更
                hue = (hue + Time.deltaTime) % 1f;
            }

            ChangeBodyColor();
       // }
    }

    // データを送受信するメソッド
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            Debug.Log("データー送信");
            // 自身側が生成したオブジェクトの場合は
            // 色相値と移動中フラグのデータを送信する
            stream.SendNext(hue);
            stream.SendNext(isMoving);
        }
        else
        {
            Debug.Log("データー受信");
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータから色相値と移動中フラグを更新する
            hue = (float)stream.ReceiveNext();
            isMoving = (bool)stream.ReceiveNext();
            //色の変更処理
            ChangeBodyColor();
        }
    }

    private void ChangeBodyColor()
    {
        float h = hue;
        float s = 1f;
        float v = (isMoving) ? 1f : 0.5f;
        spriteRenderer.color = Color.HSVToRGB(h, s, v);
    }
}