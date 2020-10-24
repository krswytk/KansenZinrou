using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButton : MonoBehaviour
{
    public GameObject gameobject;
    public void OnClick()
    {
        if (RuleH.x < 6)
            gameobject.GetComponent<RuleH>().Down();
    }
}
