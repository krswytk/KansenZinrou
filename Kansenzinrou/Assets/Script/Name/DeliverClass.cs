using UnityEngine;

public class DeliverClass : MonoBehaviour
{
    //GMの名前はdeliverString他のプレイヤーの名前はNamescenePN1,NamescenePN2,NamescenePN3,NamescenePN4に入ってます
    //このスクリプトはDeliverの中に入っているのでそこから持ってきてください
    //現状の配列は機能していないです
    [HideInInspector] public string deliverString;
    [HideInInspector] public string NamescenePN1;
    [HideInInspector] public string NamescenePN2;
    [HideInInspector] public string NamescenePN3;
    [HideInInspector] public string NamescenePN4;
    [HideInInspector] public string[] NamescenePNM=new string[4];
    private void Start()
    {
        DontDestroyOnLoad(this);
        NamescenePNM[0] = NamescenePN1;
        NamescenePNM[1] = NamescenePN2;
        NamescenePNM[2] = NamescenePN3;
        NamescenePNM[3] = NamescenePN4;
        for (int i = 0; i < NamescenePNM.Length; i++)
        {
            string tmp = NamescenePNM[i];
            int randomIndex = Random.Range(i, NamescenePNM.Length);
            NamescenePNM[i] = NamescenePNM[randomIndex];
            NamescenePNM[randomIndex] = tmp;
        }
        Debug.Log(deliverString);
        Debug.Log(NamescenePNM[0]);
        Debug.Log(NamescenePNM[1]);
        Debug.Log(NamescenePNM[2]);
        Debug.Log(NamescenePNM[3]);
    }
}