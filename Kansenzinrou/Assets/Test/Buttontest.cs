using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttontest : MonoBehaviour
{
    private static int num;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        text.text = num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UP()
    {
        num++;
        text.text = num.ToString();
    }
    public void DOWN()
    {
        num--;
        text.text = num.ToString();
    }
}
