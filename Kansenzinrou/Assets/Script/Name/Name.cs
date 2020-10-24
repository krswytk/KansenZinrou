using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public InputField inputField;
    public InputField inputField0;
    public InputField inputField1;
    public InputField inputField2;
    public InputField inputField3;
    private DeliverClass anotherScript;
    GameObject anotherObject;

    private void Start()
    {
        // DeliverClassを取得
        //DeliverClass deliver = FindObjectOfType<DeliverClass>();
        // InputFieldの文字列をDeliverに渡す
        // deliver.deliverString = null;
        //anotherScript.NamescenePN = new string[4];
        //Debug.Log(deliver.deliverString);
        //Debug.Log(deliver.NamescenePN[2]);
        // シーンを20190304_02に移動
    }
    public void OnClickButton()
    {
        SceneManager.sceneLoaded += NamePass;
        anotherObject = GameObject.Find("Deliver");
         anotherScript = anotherObject.GetComponent<DeliverClass>();
        // DeliverClassを取得
        //DeliverClass deliver = FindObjectOfType<DeliverClass>();
        // InputFieldの文字列をDeliverに渡す
        anotherScript.deliverString = inputField.text;
        anotherScript.NamescenePN1 = inputField0.text;
        anotherScript.NamescenePN2 = inputField1.text;
        anotherScript.NamescenePN3 = inputField2.text;
        anotherScript.NamescenePN4 = inputField3.text;
        // シーンを20190304_02に移動
        feadSC.fade("Main");
        Debug.Log(anotherScript.deliverString);
        Debug.Log(anotherScript.NamescenePN1);
        Debug.Log(anotherScript.NamescenePN2);
        Debug.Log(anotherScript.NamescenePN3);
        Debug.Log(anotherScript.NamescenePN4);
    }

    private void NamePass(Scene next, LoadSceneMode mode)
    {
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName = new string[4];
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().GMName = "GMプレイヤーの名前ー";
        for (int i = 0;i < 4; i++)
        {
            GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[i] = "プレイヤーの名前ー";
        }

        SceneManager.sceneLoaded -= NamePass;
    }
}