using Photon.Pun;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承すると、photonViewプロパティが使えるようになる
public class GamePlayer : MonoBehaviourPunCallbacks
{
    private GameObject TestSprite;//宣言
    private void Start()
    {
        //テスト用オブジェクト生成
        TestSprite = Instantiate(Resources.Load<GameObject>("Test/TestSprite"),Vector2.zero,Quaternion.identity);

    }
    private void Update()
    {
        // 自身が生成したオブジェクトだけに移動処理を行う
      // if (photonView.IsMine)
       // {
            var dx = 0.1f * Input.GetAxis("Horizontal");
            var dy = 0.1f * Input.GetAxis("Vertical");
            TestSprite.transform.Translate(dx, dy, 0f);
      //  }
    }
}