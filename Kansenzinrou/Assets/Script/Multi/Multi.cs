using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Multi : MonoBehaviour
{
    public Text[] inputField;

    public void OnClickButton()
    {
        Debug.Log(inputField[0].text.ToString());
        Debug.Log(inputField[1].text.ToString());
        SceneManager.sceneLoaded += NamePass;
        feadSC.fade("Main");
    }

    private void NamePass(Scene next, LoadSceneMode mode)
    {
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName = new string[4];
        GameObject.Find("Maneger").GetComponent<GetPlayerName>().GMName = inputField[0].text.ToString(); //ルームName？変数分からん
        for (int i = 0; i < inputField.Length - 1; i++)
        {
            GameObject.Find("Maneger").GetComponent<GetPlayerName>().PlayerName[i] = inputField[i + 1].text.ToString();
        }
        SceneManager.sceneLoaded -= NamePass;
    }
}