using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHud : MonoBehaviour
{
    public GameObject QuestHudContent;
    public Button buttonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        WorldData.changedTaskCompletedEvent += UpdateQuestList;
    }

    private void UpdateQuestList()
    {
        for (int i = 0; i < QuestLog.questLog.Count; i++)
        {
            GameObject questHudItem = QuestHudContent.transform.Find(QuestLog.questLog[i].questID.ToString()).gameObject;
            if (QuestLog.questLog[i].completed)
            {
                questHudItem.transform.GetChild(0).GetComponent<Text>().text = QuestLog.questLog[i].questTitle + " | DONE |";
            }
            else
            {
                questHudItem.transform.GetChild(0).GetComponent<Text>().text = QuestLog.questLog[i].GetDescription();
               // questHudItem.transform.position
            }
        }
        foreach (Quest item in QuestLog.questLog)
        {
            GameObject questHudItem = QuestHudContent.transform.Find(item.questID.ToString()).gameObject;
           if (item.completed)
            {
                questHudItem.transform.GetChild(0).GetComponent<Text>().text = item.questTitle + " | DONE |";
            }
            else
            {
                questHudItem.transform.GetChild(0).GetComponent<Text>().text = item.GetDescription();

           }
       }
    }

    // Update is called once per frame
    void Update()
    {

        if(QuestLog.questLog.Count > QuestHudContent.transform.childCount)
        {
            for (int i = 0; i < QuestLog.questLog.Count; i++)
            {
                Button tempButton = Instantiate(buttonPrefab, QuestHudContent.transform) as Button;
                tempButton.name = QuestLog.questLog[i].questID.ToString();
                tempButton.transform.GetChild(0).GetComponent<Text>().text = QuestLog.questLog[i].GetDescription();
                //Set button position
                tempButton.transform.localPosition = new Vector3(107, (-100)+(-20 * i), 0);
            }
            //foreach (Quest item in QuestLog.questLog)
            //{
            //    Button tempButton = Instantiate(buttonPrefab, QuestHudContent.transform) as Button;
            //    tempButton.name = item.questID.ToString();
            //    tempButton.transform.GetChild(0).GetComponent<Text>().text = item.GetDescription();
            //    //Set button position
            //}
        }     
        
    }
}
