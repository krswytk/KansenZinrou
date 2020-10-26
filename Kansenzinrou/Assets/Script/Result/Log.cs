using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Log : MonoBehaviour
{
    public Text LogText;
    string[] stringLog;
    // Start is called before the first frame update
    void Start() {
        /*string[] text = new string[2];
        text[0] = "道具屋 2噛め";
        text[1] = "あ";
        
        InfrctionLog.setInfectedPerson(text);*/

        LogText.text = "";

        stringLog = InfrctionLog.getInfectedLog();
        for (int i = 0; i < stringLog.Length; i++)
            LogText.text += stringLog[i] + "\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
