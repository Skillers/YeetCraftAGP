using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHolder : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    
    List<ITask> questTasks = new List<ITask>();
    List<ITask> questTasks1 = new List<ITask>();
    List<ITask> questTasks2 = new List<ITask>();
    List<ITask> questTasks3 = new List<ITask>();

    public int AmountOfQuests;

    public static QuestHolder Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(this);


        AmountOfQuests = quests.Count;
    }

  
}
