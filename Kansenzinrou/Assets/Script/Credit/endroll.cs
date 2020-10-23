using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endroll : MonoBehaviour
{
    //文字移動速度
    [SerializeField]
    private int Scspeed = 50;
    //文の表示限界
    [SerializeField]
    private float limpos = 730f;
    //ロール終了判定
    private bool rolend;
    //シーン移動用に使うよ
    private Coroutine seenmove;
    // Update is called once per frame
    void Update()
    {
        if (rolend)
        {
            seenmove = StartCoroutine(Gotitle());
        }
        else
        {

            if (transform.position.y <= limpos)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Scspeed * Time.deltaTime);
            }
            else
            {
                rolend = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene("Start");
            feadSC.fade("Start");
        }
    }
    IEnumerator Gotitle()
    {//タイトルへの移行に使うよ
        yield return new WaitForSeconds(2f);
        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(seenmove);
            //SceneManager.LoadScene("Start");
            feadSC.fade("Start");
        }
        yield return null;
    }
}