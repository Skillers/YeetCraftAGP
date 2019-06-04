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
       
    }

    public void StartQuest()
    {
        Debug.Log("Quest started: " + questTitle + "| 0/" + tasks.Count + " Steps |");
        WorldData.changedQuestStarted(this);
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
        if (completed)
        {
            WorldData.changedQuestCompleted(this);
        }
    }
    
    public string GetTitle()
    {
        return questTitle;
    }

    public string GetDescription()
    {
        return questTitle + " (" + (taskCounter) + "/" + tasks.Count + ")";
    }

   public string GetTasksCount()
    {
        return " (" + (taskCounter) + "/" + tasks.Count + ")";
    }

    public string GetTasksDisc()
    {
        string temp = "";
        for (int i = 0; i < tasks.Count; i++)
        {
            temp += (i+1)+":" + tasks[i].TaskDescription() + "\n";
        }
        return temp;
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

    /// <summary>
    /// Change the tasks
    /// </summary>
    /// <param name="_index"></param>
    /// <param name="_task"></param>
    public void SetTaskOn(int _index, ITask _task)
    {
        tasks[_index] = _task;
    }
}
