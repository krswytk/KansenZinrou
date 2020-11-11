using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSkip : MonoBehaviour
{
    IventAll IA;
    // Start is called before the first frame update
    void Start()
    {
       IA= GameObject.Find("Maneger").GetComponent<IventAll>();
    }
    public void TimerSkipSW()
    {
        IA.Skip();
    }
}
