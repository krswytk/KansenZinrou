using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButton : MonoBehaviour
{
    public GameObject gameobject;
    public void OnClick()
    {
        if (RuleH.x > 0)
            gameobject.GetComponent<RuleH>().Up();
    }
}
