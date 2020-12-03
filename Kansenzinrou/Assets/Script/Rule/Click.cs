using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    GameObject ClickObject;
    public AudioClip soundad;//
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        ClickObject = this.gameObject;

        for (int c = 0; c < 6; c++)
        {
            RuleH.tlist[RuleH.x].SetActive(false);
            RuleH.slist[RuleH.x].SetActive(false);
        }

        if (ClickObject.name == "Click1")
            RuleH.x = 0;
        else if (ClickObject.name == "Click2")
            RuleH.x = 1;
        else if (ClickObject.name == "Click3")
            RuleH.x = 2;
        else if (ClickObject.name == "Click4")
            RuleH.x = 3;
        else if (ClickObject.name == "Click5")
            RuleH.x = 4;
        else if (ClickObject.name == "Click6")
            RuleH.x = 5;
        else if (ClickObject.name == "Click7")
            RuleH.x = 6;
        Debug.Log(ClickObject.name);
        RuleH.tlist[RuleH.x].SetActive(true);
        RuleH.slist[RuleH.x].SetActive(true);
       audioSource.PlayOneShot(soundad);

    }


}
