using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerName : MonoBehaviour
{
    [HideInInspector] public string GMName;//名前入力シーンからもらったゲームマスターの名前が格納される
    [HideInInspector] public string[] PlayerName = null;//名前入力シーンからもらった名前が格納される
}
