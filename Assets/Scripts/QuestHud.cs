using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHud : MonoBehaviour
{
    public GameObject QuestHudContent;
    public Button buttonPrefab;
    public SortedList<int, Button> ButtonsQuestsList = new SortedList<int, Button>();
    public SortedList<int, Button> ButtonsQuestsListCompleted = new SortedList<int, Button>();

    // Start is called before the first frame update
    void Start()
    {
        WorldData.changedTaskCompletedEvent += UpdateTasksQuestList;
        WorldData.changedQuestCompletedEvent += UpdateQuestCList;
        WorldData.changedQuestStartedEvent += UpdateQuestSList;
    }


    private void UpdateTasksQuestList()
    {

    }

    private void UpdateQuestCList()
    {
            foreach (Quest item in QuestLog.questCompletedLog)
            {
                if (ButtonsQuestsList.ContainsKey(item.questID))
                {
                    ButtonsQuestsListCompleted.Add(item.questID, ButtonsQuestsList[item.questID]);
                    ButtonsQuestsListCompleted[item.questID].transform.SetSiblingIndex(QuestHudContent.transform.childCount - ButtonsQuestsListCompleted.Count);
                    ButtonsQuestsList.Remove(item.questID);
                }
            }
    }

    private void UpdateQuestSList()
    {
            foreach (Quest item in QuestLog.questLog)
            {
                if (!ButtonsQuestsList.ContainsKey(item.questID))
                {
                    ButtonsQuestsList.Add(item.questID, Instantiate(buttonPrefab, QuestHudContent.transform));
                    ButtonsQuestsList[item.questID].transform.SetSiblingIndex(1);
                }
            }
    }
}
