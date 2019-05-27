using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private List<ITask> tasks = new List<ITask>();

    public string questTitle;
    public int questID;
    int taskCounter;
    public bool completed;

    public Quest(List<ITask> _tasks, string _questTilte)
    {
        questTitle = _questTilte;
        tasks = _tasks;
        completed = false;
        taskCounter = 0;
        questID = QuestLog.GetNextQuestID();

        //Debug.Log("Quest started: " + questTitle + "| 0/" + tasks.Count + " Steps |");
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

        WorldData.changedTaskCompleted();
    }
    
    public string GetTitle()
    {
        return questTitle;
    }

    public string GetDescription()
    {
        return questTitle + " (" + (taskCounter) + "/" + tasks.Count + ")";
    }

    public List<ITask> GetTasks
    {
        get
        {
            return tasks;
        }
    }

    public void EditTitle(string _newTitle)
    {
        questTitle = _newTitle;
    }

    public void SetTaskOn(int _index, ITask _task)
    {
        tasks[_index] = _task;
    }
}
