﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTask : ITask
{
    Quest owningQuest;
    public Goal taskGoal;

    //Height doesnt matter for being near a point.
    Vector3 Location;
    int acuracyToLocation;

    bool completed;

    public GoToTask(Vector3 ToGoLocation)
    {

        taskGoal = Goal.Go;

        Location = ToGoLocation; // new Vector3(ToGoLocation.x, ToGoLocation.z);

        completed = false;


    }

    public void StartTask(Quest _owningQuest)
    {
       // Debug.Log("New task started: Go to: X" + Location.x + ", Y" + Location.y + " | Current Location: " + TaskProgression() + " |");
        owningQuest = _owningQuest;
        WorldData.changedLatestPlayerPositionEvent += UpdateTask;
    }

    public void UpdateTask(Vector3 Postion)
    {
        if (!completed)
        {
            if (Postion.x <= Location.x + 1 && Postion.x >= Location.x - 1)
            {
                if (Postion.y <= Location.y + 1 && Postion.y >= Location.y - 1)
                {
                    if (Postion.z <= Location.z + 1 && Postion.z >= Location.z - 1)
                    {
                        Debug.Log("Task Complete: Go to: X" + Location.x + ", Y" + Location.y + ", Z" + Location.z);
                        completed = true;
                        UpdateQuest();
                    }
                    else
                    {
                        Debug.Log("Task status: Go to: X" + Location.x + ", Y" + Location.y + ", Z" + Location.z + " | Current Location: " + TaskProgression() + " |");
                    }
                }
                else
                {
                        Debug.Log("Task status: Go to: X" + Location.x + ", Y" + Location.y + ", Z" + Location.z + " | Current Location: " + TaskProgression() + " |");
                }

            }
            else
            {
                Debug.Log("Task status: Go to: X" + Location.x + ", Y" + Location.y + ", Z" + Location.z + " | Current Location: " + TaskProgression() + " |");
            }
        }
    }

    public void UpdateQuest()
    {
        WorldData.changedLatestPlayerPositionEvent -= UpdateTask;
        owningQuest.NextTask();
    }


    //Task Description is used in quest Log
    public string TaskDescription()
    {
        if (completed) {
            return "Go to " + Location + " / Done";

        } else
        {
            return "Go to " + Location + " / " + WorldData.lastPlayerPosition;
        }
        
    }

    public string TaskProgression()
    { 
        string _ret = "X"+ WorldData.lastPlayerPosition.x + ", Y" + WorldData.lastPlayerPosition.y + ", Z" + WorldData.lastPlayerPosition.z;
        return _ret;
    }

    public int TaskID()
    {
        return 1;
    }

    public Vector3 GoalPos()
    {
        return Location;
    }
}
