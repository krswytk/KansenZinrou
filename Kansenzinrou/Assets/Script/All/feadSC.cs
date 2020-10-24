using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class feadSC : MonoBehaviour
{
    private static GameObject fadeimage;
    private static GameObject F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void fade(string name)
    {
        fadeimage = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/fade.prefab");
        SceneManager.sceneLoaded += GameSceneLoaded;
        F = Instantiate(fadeimage, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
        F.GetComponent<fadeob>().ONfade(name);
    }
    

    private static void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        F = Instantiate(fadeimage, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
        F.GetComponent<fadeob>().OFFfade();
    }
    
}
