using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private List<Task> tasks = new List<Task>();

    int taskCount;

    public Quest(List<Task> _tasks)
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
            Debug.Log(tasks[i].GetTaskDescription());
        }
    }
}
