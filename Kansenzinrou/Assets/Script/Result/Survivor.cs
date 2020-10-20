using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : MonoBehaviour
{
    private static int m_Survivor = 4;//感染者数

    public static void setSurvivor(int Survivor) { m_Survivor = Survivor; }
    public static int getSurvivor() { return m_Survivor; }
}
