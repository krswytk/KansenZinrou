using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private static int[] m_InfectedPerson = new int[6];
    private static int[] m_Money = new int[6];

    public static void setInfectedPerson(int InfectedPerson, int date)
    {
        m_InfectedPerson[date - 1] = InfectedPerson;
    }
    public static void setMoney(int Money, int date) { m_Money[date - 1] = Money; }

    public static int getInfectedPerson(int date)
    {
        return m_InfectedPerson[date - 1];
    }
}
