using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private List<ITask> tasks = new List<ITask>();

    int taskCount;

    public Quest(List<ITask> _tasks)
    {
        tasks = _tasks;
        taskCount = 0;
    }


   public void CheckTask()
    {
        if (tasks[taskCount].Completed())
        {
            taskCount++;
        }
        if (taskCount >= tasks.Count)
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
