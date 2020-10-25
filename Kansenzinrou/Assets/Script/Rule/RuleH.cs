using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RuleH: MonoBehaviour
{

    public float dy;
    static public int x;
    public GameObject t1, t2, t3, t4, t5, t6, t7;
    List<GameObject> list = new List<GameObject>();
    public AudioClip sound1;//
    AudioSource audioSource;//

    public void Start()
    {
        list.Add(t1);
        list.Add(t2);
        list.Add(t3);
        list.Add(t4);
        list.Add(t5);
        list.Add(t6);
        list.Add(t7);
        x = 0;
        list[x].SetActive(true);
        audioSource = GetComponent<AudioSource>();//
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S)) && x < 6)
            Down();

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && x > 0)
            Up();
    }
    public void Down()
    {
        this.transform.position += new Vector3(0, dy, 0);
        x++;
        list[x].SetActive(true);
        list[x - 1].SetActive(false);
        audioSource.PlayOneShot(sound1);//
    }
    public void Up()
    {
        this.transform.position -= new Vector3(0, dy, 0);
        x--;
        list[x].SetActive(true);
        list[x + 1].SetActive(false);
        audioSource.PlayOneShot(sound1);//
    }


}
