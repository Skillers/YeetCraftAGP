using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHolder : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    
    List<ITask> questTasks = new List<ITask>();
    List<ITask> questTasks1 = new List<ITask>();
    List<ITask> questTasks2 = new List<ITask>();
    List<ITask> questTasks3 = new List<ITask>();

    public int AmountOfQuests;

    public static QuestHolder Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        questTasks.Add(new GoToTask(new Vector3(12, 04, -470)));
        questTasks.Add(new GatherTask(69, Block.BlockType.CRACK1));

        questTasks1.Add(new GatherTask(69, Block.BlockType.GRASS));
        questTasks1.Add(new GoToTask(new Vector3(45, 1, -0)));
        //3 place holder quests

        questTasks2.Add(new GatherTask(69, Block.BlockType.GRASS));
        questTasks2.Add(new GoToTask(new Vector3(0, 0, 0)));
        questTasks2.Add(new GatherTask(69, Block.BlockType.STONE));
        questTasks2.Add(new GoToTask(new Vector3(4120, 12, 11)));

        questTasks3.Add(new GoToTask(new Vector3(0, 0, 1501)));

        quests.Add(new Quest(questTasks, "Koalo coole dingen"));
        quests.Add(new Quest(questTasks1, "Nog meer coole dingen"));
        quests.Add(new Quest(questTasks2, "Joinkers"));
        quests.Add(new Quest(questTasks3, "Yeetcraft"));

        DontDestroyOnLoad(this);


        AmountOfQuests = quests.Count;
    }

  
}
