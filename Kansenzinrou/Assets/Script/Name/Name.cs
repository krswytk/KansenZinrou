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
        SceneManager.LoadScene("Main");
        Debug.Log(anotherScript.deliverString);
        Debug.Log(anotherScript.NamescenePN1);
        Debug.Log(anotherScript.NamescenePN2);
        Debug.Log(anotherScript.NamescenePN3);
        Debug.Log(anotherScript.NamescenePN4);
    }
}