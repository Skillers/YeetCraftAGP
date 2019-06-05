using UnityEngine;

public enum Goal
{
    Go,
    Gather,
    Build
}


public interface ITask
{
    //Subscribe the task to a event
    void StartTask(Quest _owningQuest);
    //Tells the quest that the task is done.
    void UpdateQuest();
    //status text only
    string TaskProgression();
    //main text for quest
    string TaskDescription();
    //text for builder
    string TaskDescriptionBuilder();
    //Get the task id, used for the main menu
    int TaskID();

    Vector3 GoalPos();
}
