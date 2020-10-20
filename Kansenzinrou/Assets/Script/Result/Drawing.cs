using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Drawing : MonoBehaviour
{
    //ローカル座標
    private struct drawX
    {
        public const float FirstX = -2.148f;
        public const float SecondX = -1.279f;
        public const float ThirdX = -0.449f;
        public const float FourthX = 0.409f;
        public const float FifthX = 1.429f;
        public const float SixthX = 2.428097f;
    }
    private struct drawY 
    {
        public const float ZeroY = -1.9f;
        public const float FirstY = -0.868f;
        public const float SecondY = 0.155f;
        public const float ThirdY = 1.187f;
        public const float FourthY = 2.168f;
        
    }

    public Text SurvivorText;
    public GameObject orizinalPoint;
    public GameObject chart1;

    int count = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        SurvivorText.text += "　" + Survivor.getSurvivor().ToString() + "人";

        //デバック用
        Point.setInfectedPerson(0, 1);
        Point.setInfectedPerson(1, 2);
        Point.setInfectedPerson(2, 3);
        Point.setInfectedPerson(3, 4);
        Point.setInfectedPerson(4, 5);
        Point.setInfectedPerson(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクト複製
        if (count < 7)
        {
            GameObject copyPoint = Instantiate(orizinalPoint,
            Vector3.zero,
            Quaternion.identity,
            chart1.transform) as GameObject;

            Transform thisTransform = copyPoint.transform;
            Vector2 pos = thisTransform.localPosition;
            switch (Point.getInfectedPerson(count))
            {
                case 0:
                    pos.y = drawY.ZeroY;
                    break;
                case 1:
                    pos.y = drawY.FirstY;
                    break;
                case 2:
                    pos.y = drawY.SecondY;
                    break;
                case 3:
                    pos.y = drawY.ThirdY;
                    break;
                case 4:
                    pos.y = drawY.FourthY;
                    break;
            }
            switch (count)
            {
                case 1:
                    pos.x = drawX.FirstX;
                    break;
                case 2:
                    pos.x = drawX.SecondX;
                    break;
                case 3:
                    pos.x = drawX.ThirdX;
                    break;
                case 4:
                    pos.x = drawX.FourthX;
                    break;
                case 5:
                    pos.x = drawX.FifthX;
                    break;
                case 6:
                    pos.x = drawX.SixthX;
                    break;
            }
            
            thisTransform.localPosition = pos;
            count++;
        }
        
    }
}
