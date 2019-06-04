using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTask : ITask
{
    Quest owningQuest;
    public Goal taskGoal;

    Block.BlockType blockToPlace;

    bool completed;

    public int currentCount;
    private int countNeeded;

    public BuildTask(int _neededAmount, Block.BlockType _blockType)
    {
        taskGoal = Goal.Build;

        blockToPlace = _blockType;
        completed = false;
        currentCount = 0;
        countNeeded = _neededAmount;
    }

    public void UpdateQuest()
    {
        WorldData.changedLastPlacedBlockEvent -= UpdateTask;
        owningQuest.NextTask();
    }

    public Vector3 GoalPos()
    {
        Debug.LogWarning("Currently not used by tasks");
        return Vector3.zero;
    }

    public void StartTask(Quest _owningQuest)
    {
        Debug.Log("New task started: Build: " + blockToPlace.ToString().ToLower() + TaskProgression());
        owningQuest = _owningQuest;

        WorldData.changedLastPlacedBlockEvent += UpdateTask;
    }

    public void UpdateTask(Block.BlockType blockPlaced)
    {
        if (!completed)
        {
            if (blockPlaced == blockToPlace)
            {
                currentCount++;
                if (currentCount < countNeeded)
                {
                    Debug.Log("Task Progression Build: " + blockToPlace.ToString().ToLower() + TaskProgression());
                }
                else
                {
                    Debug.Log("Task Complete: Gather: " + blockToPlace.ToString().ToLower() + TaskProgression());
                    completed = true;
                    UpdateQuest();
                }
            }
        }
    }

    public string TaskDescription()
    {
        string _ret = "";
        _ret += "Build: ";
        _ret += blockToPlace.ToString().ToLower();
        _ret += " ";
        _ret += TaskProgression();
        return _ret;
    }

    public int TaskID()
    {
        return 3;
    }

    public string TaskProgression()
    {
        string _ret = "(" + currentCount + "/" + countNeeded + ")";
        return _ret;
    }

    
}
