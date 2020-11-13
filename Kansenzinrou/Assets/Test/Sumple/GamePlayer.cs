using Photon.Pun;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承すると、photonViewプロパティが使えるようになる
public class GamePlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField]
    private Projectile projectilePrefab = default; // ProjectileのPrefabの参照

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
        if (photonView.IsMine)
        {
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

            // 左クリックでカーソルの方向に弾を発射する処理を行う
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(transform.position);
                //今の自分の座標
                var playerWorldPosition = transform.position;

                Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                //多分クリックした座標かな
                var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var dp = mouseWorldPosition - playerWorldPosition;
                float angle = Mathf.Atan2(dp.y, dp.x);

                // FireProjectile(angle)をRPCで実行する
                photonView.RPC(nameof(FireProjectile), RpcTarget.All, angle);
            }
        }
    }

    // データを送受信するメソッド
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //Debug.Log("データー送信");
            // 自身側が生成したオブジェクトの場合は
            // 色相値と移動中フラグのデータを送信する
            stream.SendNext(hue);
            stream.SendNext(isMoving);
        }
        else
        {
            //Debug.Log("データー受信");
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータから色相値と移動中フラグを更新する
            hue = (float)stream.ReceiveNext();
            isMoving = (bool)stream.ReceiveNext();
            //色の変更処理
            ChangeBodyColor();
        }
    }

    //移動時の色変更用関数
    private void ChangeBodyColor()
    {
        float h = hue;
        float s = 1f;
        float v = (isMoving) ? 1f : 0.5f;
        spriteRenderer.color = Color.HSVToRGB(h, s, v);
    }

    // 弾を発射するメソッド
    // [PunRPC]属性をつけると、RPCでの実行が有効になる
    [PunRPC]
    private void FireProjectile(float angle)
    {
        var projectile = Instantiate(projectilePrefab);
        projectile.Init(transform.position, angle);
    }
}