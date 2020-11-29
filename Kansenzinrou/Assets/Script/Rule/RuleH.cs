using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RuleH: MonoBehaviour
{
   // GameObject ClickObject;
    public float dy;
    static public int x;
    public GameObject t1, t2, t3, t4, t5, t6, t7;
    public GameObject s1, s2, s3, s4, s5, s6, s7;
    static public List<GameObject> tlist = new List<GameObject>();
    static public List<GameObject> slist = new List<GameObject>();
    public AudioClip soundad;//
    AudioSource audioSource;//
    int count = 0;
    bool isCalledOnce = false;

    public void Start()
    {
        tlist.Add(t1);
        tlist.Add(t2);
        tlist.Add(t3);
        tlist.Add(t4);
        tlist.Add(t5);
        tlist.Add(t6);
        tlist.Add(t7);
        slist.Add(s1);
        slist.Add(s2);
        slist.Add(s3);
        slist.Add(s4);
        slist.Add(s5);
        slist.Add(s6);
        slist.Add(s7);
        x = 0;
        tlist[x].SetActive(true);
        audioSource = GetComponent<AudioSource>();//
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && x < 6)
        {
                Down();

        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && x > 0)
        {
            Up();
        }
    }
    public void Down()
    {
        //this.transform.position += new Vector3(0, dy, 0);
            x++;
            tlist[x].SetActive(true);
            tlist[x - 1].SetActive(false);
            slist[x].SetActive(true);
            slist[x - 1].SetActive(false);
            audioSource.PlayOneShot(soundad);//
            isCalledOnce = true;
    }
    public void Up()
    {
        //this.transform.position -= new Vector3(0, dy, 0);
        x--;
        tlist[x].SetActive(true);
        tlist[x + 1].SetActive(false);
        slist[x].SetActive(true);
        slist[x + 1].SetActive(false);
        audioSource.PlayOneShot(soundad);//
    }



}
