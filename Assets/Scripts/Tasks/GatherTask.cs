using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GatherTask : ITask
{
    Quest owningQuest;
    public Goal taskGoal;

    Block.BlockType blockToMine;

    bool completed;

    public int currentCount;
    private int countNeeded;



    private string taskDescription;

    public GatherTask(int _neededAmount, Block.BlockType _blockToMine)
    {
 
        taskGoal = Goal.Gather;

        blockToMine = _blockToMine;

        completed = false;

        countNeeded = _neededAmount;
        currentCount = 0;

    }

    public void StartTask(Quest _owningQuest)
    {
        Debug.Log("New task started: Gather: " + blockToMine.ToString().ToLower() + TaskProgression());
        owningQuest = _owningQuest;
        WorldData.changedLastMinedBlockEvent += UpdateTask;
    }

    public void UpdateTask(Block.BlockType blockMined)
    {
        if (!completed)
        {
            if (blockMined == blockToMine)
            {
                currentCount++;
                if (currentCount < countNeeded)
                {
                    
                    Debug.Log("Task Progression: Gather: " + blockToMine.ToString().ToLower() + TaskProgression());
                }
                else
                {
                    Debug.Log("Task Complete: Gather: " + blockToMine.ToString().ToLower() + TaskProgression());
                    completed = true;
                    UpdateQuest();
                }
            }
        }



    }

    public void UpdateQuest()
    {
        WorldData.changedLastMinedBlockEvent -= UpdateTask;
        owningQuest.NextTask();
    }

    //Task Description is used in quest Log
    public string TaskDescription()
    {
        string _ret = "";
        _ret += "Gather: ";
        _ret += blockToMine.ToString().ToLower();
        _ret += " ";
        _ret += TaskProgression();
        return _ret;
    }

    public string TaskProgression()
    {
        string _ret = "(" + currentCount + "/" + countNeeded + ")";
        return _ret;
    }
}
