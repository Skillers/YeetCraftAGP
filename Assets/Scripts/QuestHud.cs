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
        
    }

    // Update is called once per frame
    void Update()
    {

        if(QuestLog.questLog.Count > QuestHudContent.transform.childCount)
        {
            Instantiate(buttonPrefab, QuestHudContent.transform);
        }                
    }
}
