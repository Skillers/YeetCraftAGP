using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHolder : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();


    List<ITask> questTasks = new List<ITask>();
    private void Awake()
    {
        questTasks.Add(new GoToTask(new Vector3(0, 0, 0)));
        questTasks.Add(new GatherTask(69, Block.BlockType.CRACK1));
        //3 place holder quests

        quests.Add(new Quest(questTasks, "Koalo coole dingen"));
        quests.Add(new Quest(questTasks, "Nog meer coole dingen"));
        quests.Add(new Quest(questTasks, "Joinkers"));
        quests.Add(new Quest(questTasks, "Yeetcraft"));
    }

}
