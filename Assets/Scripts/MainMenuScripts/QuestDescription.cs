using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDescription : MonoBehaviour
{

    public Quest currentQuest;

    public Text questDescriptionText;

    // Start is called before the first frame update
    void Start()
    {
        //questDescriptionText.text = "";
    }

    public void SetValues(Quest _newQuest)
    {
        currentQuest = _newQuest;

        questDescriptionText.text = currentQuest.GetDescription();
    }

    public void EditQuest()
    {
        //Edit quest

        if (currentQuest == null)
        {
            Debug.LogError("Quest is currently empty");
            return;
        }

        //disbale UI thing
        MainMenuController.Instance.OpenQuestEdit(currentQuest);

        //Enable quest editor

    }

}
