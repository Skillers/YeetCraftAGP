using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    public static int QuestIdCounter = 0;
    public static List<Quest> questLog = new List<Quest>();
    public static List<Quest> questCompletedLog = new List<Quest>();

    public static int GetNextQuestID()
    {
        return QuestIdCounter++;
    }
    
}
