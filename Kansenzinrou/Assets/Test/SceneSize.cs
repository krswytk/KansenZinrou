using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSize : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen  height: " + Screen.height);
        Screen.SetResolution(960, 540, false, 60);
    }
}
