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
    public string[] nameholde=new string [4];
    public string gmnameholde;
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
        // DeliverClassを取得
        //DeliverClass deliver = FindObjectOfType<DeliverClass>();
        // InputFieldの文字列をDeliverに渡す
        gmnameholde = inputField.ToString();
        nameholde[0] = inputField0.ToString();
        nameholde[1] = inputField1.ToString();
        nameholde[2] = inputField2.ToString();
        nameholde[3] = inputField3.ToString();
        // シーンを20190304_02に移動
        feadSC.fade("Main");
        Debug.Log(gmnameholde);
        Debug.Log(nameholde[0]);
        Debug.Log(nameholde[1]);
        Debug.Log(nameholde[2]);
        Debug.Log(nameholde[3]);
    }

    private void NamePass(Scene next, LoadSceneMode mode)
    {
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName = new string[4];
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().GMName = "GMプレイヤーの名前ー";
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().GMName = inputField.ToString();
        for (int i = 0;i < 4; i++)
        {
            GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[i] = "プレイヤーの名前ー";
            GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[i] = nameholde[i];
        }
        for (int i = 0; i < GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName.Length; i++)
        {
            string tmp = GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[i];
            int randomIndex = Random.Range(i, GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName.Length);
            GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[i] = GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[randomIndex];
            GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[randomIndex] = tmp;
        }
        SceneManager.sceneLoaded -= NamePass;
    }
}