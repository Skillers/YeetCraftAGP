using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GatherTask : ITask
{
    public Goal taskGoal;

    int currentCount;
    int countNeeded;

    string materialString;

    private string taskDescription;

    public GatherTask(int _neededAmount, string goalname)
    {
        taskGoal = Goal.Gather;
        countNeeded = _neededAmount;
        materialString = goalname;
    }

    public bool Completed()
    {
        return currentCount >= countNeeded;
    }

    public string TaskDescription()
    {
        string _ret = "";
        if (taskGoal == Goal.Gather)
        {
            _ret += "Gather ";
            _ret += countNeeded;
            _ret += " " + materialString;
            _ret += " (" + currentCount + ")";
        }
        return _ret;
    }
}
