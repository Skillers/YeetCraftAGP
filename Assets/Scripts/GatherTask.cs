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

    public bool CheckTaskStatus()
    {
        return currentCount >= countNeeded;
    }

    public string TaskDescription()
    {
        string _ret = "";
        _ret += "Gather ";
        _ret += TaskProgression();
        _ret += " " + materialString;
        return _ret;
    }

    public string TaskProgression()
    {
        string _ret = currentCount + "/" + countNeeded;
        return _ret;
    }

}
