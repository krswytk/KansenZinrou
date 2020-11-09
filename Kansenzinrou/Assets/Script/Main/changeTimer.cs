using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTimer : MonoBehaviour
{
    [SerializeField] GameObject text;
    bool txton = true;
    [HideInInspector] public float span = 5f;
    private float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            if (txton == true) { 
            text.SetActive(false);
                txton = false;
            }else if (txton == false)
            {
                text.SetActive(true);
                txton = true;
            }
            Debug.LogFormat("{0}秒経過", span);
            currentTime = 0f;
        }
    }
}