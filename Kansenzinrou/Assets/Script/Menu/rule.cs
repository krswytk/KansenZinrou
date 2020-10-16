using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule : MonoBehaviour
{
    public static bool Rule_sw;
    Scene scene_open;
    Scene scene_close;

    // Start is called before the first frame update
    void Start()
    {
        Rule_sw = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rule_open()
    {
        if (Rule_sw)//あったら削除
        {
            scene_open = SceneManager.GetSceneByName("Rule");
            SceneManager.UnloadSceneAsync(scene_open);
        }
        else//ないので表示
        {
            SceneManager.LoadScene("Rule", LoadSceneMode.Additive);
            Rule_sw = true;
        }
    }

    public void rule_close()
    {
        scene_close = SceneManager.GetSceneByName("Rule");//合体しているうちの、こっちだけ
        SceneManager.UnloadSceneAsync(scene_close);
        Rule_sw = false;
    }

    public void title_back()
    {
        //feadSC.fade("Title");//タイトルに移動
    }

    public void GameStart()
    {
        //feadSC.fade("Title");//ゲームスタート
    }
}
