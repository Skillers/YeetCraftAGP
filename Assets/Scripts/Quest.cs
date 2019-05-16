using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private List<ITask> tasks = new List<ITask>();

    int taskCounter;

    public Quest(List<ITask> _tasks)
    {
        tasks = _tasks;

        //Keep track on which task is currently active
        taskCounter = 0;
    }


   public void CheckTask()
    {
        if (tasks[taskCounter].Completed())
        {
            Debug.Log("Task completed");
            taskCounter++;
        }
        if (taskCounter >= tasks.Count)
        {
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
