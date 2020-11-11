using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Multi : MonoBehaviour
{
    public Text[] inputField;

    public void OnClickButton()
    {
        
        SceneManager.sceneLoaded += NamePass;
        Debug.Log(inputField[0].text.ToString());
        Debug.Log(inputField[1].text.ToString());
        if (string.IsNullOrWhiteSpace(inputField[0].text.ToString()) && string.IsNullOrWhiteSpace(inputField[1].text.ToString())) //何も入っていなかったら
        {
            Debug.Log("入力されてません");
        }
        else
        {
            feadSC.fade("Main");
        }
    }

    private void NamePass(Scene next, LoadSceneMode mode)
    {
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName = new string[1];
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().GMName = inputField[0].text.ToString(); //ルームName？変数分からん

        GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[0] = inputField[1].text.ToString();
        SceneManager.sceneLoaded -= NamePass;
    }
}