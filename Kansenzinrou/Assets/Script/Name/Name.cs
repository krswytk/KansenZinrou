using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    InputField inputField;
    [HideInInspector] public string GMName;//名前入力シーンからもらったゲームマスターの名前が格納される
    [HideInInspector] public string[] PlayerName = null;//名前入力シーンからもらった名前が格納される
    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start()
    {
        DontDestroyOnLoad(this);
        GMName = null;
        Debug.Log(GMName);
        inputField = GetComponent<InputField>();

        InitInputField();
    }



    /// <summary>
    /// Log出力用メソッド
    /// 入力値を取得してLogに出力し、初期化
    /// </summary>


    public void InputLogger()
    {
        if (GMName == null)
        {
            GMName = inputField.text;

            

            InitInputField();
            Debug.Log(GMName);
        }
    }



    /// <summary>
    /// InputFieldの初期化用メソッド
    /// 入力値をリセットして、フィールドにフォーカスする
    /// </summary>


    void InitInputField()
    {

        // 値をリセット
        inputField.text = "";

        // フォーカス
        inputField.ActivateInputField();
    }
}
