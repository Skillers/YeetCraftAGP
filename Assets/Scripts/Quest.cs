using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private List<ITask> tasks = new List<ITask>();

    int taskCounter;
    bool completed;

    public Quest(List<ITask> _tasks)
    {
        tasks = _tasks;
        completed = false;
       
        taskCounter = 0;
    }


   public void CheckProgression()
    {
        if (tasks[taskCounter].CheckTaskStatus())
        {
            Debug.Log("Task completed");
            taskCounter++;
        }
        if (taskCounter >= tasks.Count)
        {
            completed = true;
            Debug.Log("Quest completed");
        }
    }


    public void DebugQuest()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            Debug.Log(tasks[i].TaskDescription());
        }
    }
}
