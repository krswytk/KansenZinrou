using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnClickStartButton() //https://dianxnao.com/ボタンクリックでシーン間を遷移%ef%bc%88移動%ef%bc%89する/
    {
        Debug.Log("メニューへ");
        feadSC.fade("Menu");
    }

    public void Credit() //https://dianxnao.com/ボタンクリックでシーン間を遷移%ef%bc%88移動%ef%bc%89する/
    {
        feadSC.fade("Credit");
    }
}
