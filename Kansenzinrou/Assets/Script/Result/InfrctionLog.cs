using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrctionLog : MonoBehaviour
{
    private static string[] InfectionLog;
    
    
    public static void setInfectedPerson(string[] Log)
    {
        InfectionLog = Log;
    }
    
    public static string[] getInfectedLog()
    {
        return InfectionLog;
    }
}
