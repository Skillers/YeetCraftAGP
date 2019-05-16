using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Goal
{
    Go,
    Gather
}

public class Task : ITask
{

    public Goal taskGoal;

    int currentCount;
    int countNeeded;

    string materialString;

    private string taskDescription;

    public Task(Goal _taskGoal, int _neededAmount, string goalname)
    {
        taskGoal = _taskGoal;
        countNeeded = _neededAmount;
        materialString = goalname;
    }

    public bool Completed()
    {
        return currentCount >= countNeeded;
    }

    public string GetTaskDescription()
    {
        string _ret = "";
        if (taskGoal == Goal.Go)
        {
            _ret += "Go To ";
            //location?
        }
        else if (taskGoal == Goal.Gather)
        {
            _ret += "Gather ";
            _ret += countNeeded;
            _ret += " " + materialString;
            _ret += " (" + currentCount + ")";
        }
        return  _ret;
    }
}
