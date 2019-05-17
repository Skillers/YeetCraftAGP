using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private List<ITask> tasks = new List<ITask>();

    private string questTitle;
    int taskCounter;
    bool completed;

    public Quest(List<ITask> _tasks, string _questTilte)
    {
        questTitle = _questTilte;
        tasks = _tasks;
        completed = false;
        taskCounter = 0;

        Debug.Log("Quest started: " + questTitle + "| 0/" + tasks.Count+" Steps |");
        tasks[taskCounter].StartTask(this);
    }

    public void NextTask()
    {
        if (taskCounter < tasks.Count - 1)
        {
            taskCounter++;
            Debug.Log("Quest progressed: " + questTitle + "| " + taskCounter + "/" + tasks.Count + " Steps |");
            tasks[taskCounter].StartTask(this);
        }
        else
        {
            Debug.Log("Quest Complete: " + questTitle + "| " + tasks.Count + "/" + tasks.Count + " Steps |");
            completed = true;
        }
    }
}
