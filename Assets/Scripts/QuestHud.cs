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
        for (int i = 0; i < QuestLog.questLog.Count; i++)
        {
            GameObject questHudItem = QuestHudContent.transform.Find(QuestLog.questLog[i].questID.ToString()).gameObject;
            if (QuestLog.questLog[i].completed)
            {
                questHudItem.transform.GetChild(0).GetComponent<Text>().text = QuestLog.questLog[i].questTitle;
            }
            else
            {
                questHudItem.transform.GetChild(0).GetComponent<Text>().text = QuestLog.questLog[i].GetDescription();
            }
        }
    }

    private void UpdateQuestCList(Quest completedQuest)
    {
        ButtonsQuestsListCompleted.Add(completedQuest.questID, ButtonsQuestsList[completedQuest.questID]);
        ButtonsQuestsListCompleted[completedQuest.questID].transform.SetSiblingIndex(QuestHudContent.transform.childCount);
        ButtonsQuestsList.Remove(completedQuest.questID);
    }

    private void UpdateQuestSList(Quest startedQuest)
    {                
                Button tempButton = Instantiate(buttonPrefab, QuestHudContent.transform) as Button;
                ButtonsQuestsList.Add(startedQuest.questID, tempButton);
                tempButton.transform.SetSiblingIndex(1);
                tempButton.name = startedQuest.questID.ToString();
                tempButton.transform.GetChild(0).GetComponent<Text>().text = startedQuest.GetDescription();     
    }

}
