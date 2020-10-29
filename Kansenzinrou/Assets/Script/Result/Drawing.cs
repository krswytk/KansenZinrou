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
    //ワールド座標
    private struct worldDrawX
    {
        public const float FirstX = -6.749f;
        public const float SecondX = -5.812f;
        public const float ThirdX = -4.909f;
        public const float FourthX = -4.005f;
        public const float FifthX = -2.92f;
        public const float SixthX = -1.862f;

    }
    private struct worldDrawY
    {
        public const float ZeroY = -3.447f;
        public const float FirstY = -2.402f;
        public const float SecondY = -1.405f;
        public const float ThirdY = -0.401f;
        public const float FourthY = 0.596f;

    }

    public Text SurvivorText;
    public GameObject orizinalPoint;
    public GameObject Chart1;

    int count = 1;

    Vector3[] sumPoint = new Vector3[6];
    // Start is called before the first frame update
    void Start()
    {
        SurvivorText.text += "　" + Survivor.getSurvivor().ToString() + "人";

        //デバック用
        /*Point.setInfectedPerson(0, 1);
        Point.setInfectedPerson(1, 2);
        Point.setInfectedPerson(2, 3);
        Point.setInfectedPerson(3, 4);
        Point.setInfectedPerson(4, 5);
        Point.setInfectedPerson(3, 6);*/
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
            Chart1.transform) as GameObject;

            Transform thisTransform = copyPoint.transform;
            Vector3 pos = thisTransform.localPosition;
            switch (Point.getInfectedPerson(count))
            {
                case 0:
                    pos.y = drawY.ZeroY;
                    sumPoint[count - 1].y = worldDrawY.ZeroY;
                    break;
                case 1:
                    pos.y = drawY.FirstY;
                    sumPoint[count - 1].y = worldDrawY.FirstY;
                    break;
                case 2:
                    pos.y = drawY.SecondY;
                    sumPoint[count - 1].y = worldDrawY.SecondY;
                    break;
                case 3:
                    pos.y = drawY.ThirdY;
                    sumPoint[count - 1].y = worldDrawY.ThirdY;
                    break;
                case 4:
                    pos.y = drawY.FourthY;
                    sumPoint[count - 1].y = worldDrawY.FourthY;
                    break;
            }
            switch (count)
            {
                case 1:
                    pos.x = drawX.FirstX;
                    sumPoint[count - 1].x = worldDrawX.FirstX;
                    break;
                case 2:
                    pos.x = drawX.SecondX;
                    sumPoint[count - 1].x = worldDrawX.SecondX;
                    break;
                case 3:
                    pos.x = drawX.ThirdX;
                    sumPoint[count - 1].x = worldDrawX.ThirdX;
                    break;
                case 4:
                    pos.x = drawX.FourthX;
                    sumPoint[count - 1].x = worldDrawX.FourthX;
                    break;
                case 5:
                    pos.x = drawX.FifthX;
                    sumPoint[count - 1].x = worldDrawX.FifthX;
                    break;
                case 6:
                    pos.x = drawX.SixthX;
                    sumPoint[count - 1].x = worldDrawX.SixthX;
                    break;
            }
            pos.z = -11.0f;
            thisTransform.localPosition = pos;
            
            if (count > 1)
            {
                LineRenderer lRend;
                GameObject newLine = new GameObject("Line");
                lRend = newLine.AddComponent<LineRenderer>();
                //lRend.transform.SetParent(Chart1.transform, false);
                //lRend.sortingOrder = 1;
                lRend.SetWidth(0.05f, 0.05f);
                // 頂点の数
                lRend.SetVertexCount(2);

                lRend.SetPosition(0, sumPoint[count - 2]);
                lRend.SetPosition(1, sumPoint[count - 1]);
            }
            //sumPoint[count - 1] = thisTransform.localPosition;
            Debug.Log(count);
          
            count++;

        }

    }
}
