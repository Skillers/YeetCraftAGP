using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentQuests : MonoBehaviour
{


    [Header("Refs:")]
    public GameObject questParentObject;
    public QuestHolder questHolder;

    public GameObject questPrefab;


    int listOffset = -11;

    private void Start()
    {

       
    }

    private void OnEnable()
    {
        //Generate new list etc

        //Get all child objects on parent
        foreach (Transform child in questParentObject.transform)
        {
            //child is your child transform
            Destroy(child.gameObject);
        }
        //destroy all child pbjects

        //find new quests
        for (int i = 0; i < questHolder.quests.Count; i++)
        {
            //create pos
            Vector3 _createPos = new Vector3(0, listOffset * i, 0);
            GameObject _newQuest = Instantiate(questPrefab, _createPos, Quaternion.identity, questParentObject.transform);
            _newQuest.transform.localPosition = _createPos;

            _newQuest.GetComponent<QuestDescription>().SetValues(questHolder.quests[i]);
            
        }

        //generate new quest things

    }
}
