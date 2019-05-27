using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class is used to generate everything needed to be shown on the menu
/// Also will this change everything etc
/// </summary>
public class QuestEditorBehaviour : MonoBehaviour
{
    [Header("Values:")]
    public GameObject taskPrefab;


    [Header("Refs:")]
    public Text questMainText;
    public GameObject taskListParent;

    public Text currentTaskTitleText;
    public GameObject currentTaskEditor;

    private Quest currentEditableQuest;
    private Quest newQuest;

    public void SetValues(Quest _newQuest)
    {
        //Empty all create objects
        foreach (Transform item in taskListParent.transform)
        {
            Destroy(item.gameObject);
        }

        currentEditableQuest = _newQuest;

        currentTaskTitleText.text = "";
        
        questMainText.text = "Edit: " + _newQuest.GetDescription();

        //Add all tasks
        for (int i = 0; i < _newQuest.GetTasks().Count; i++)
        {
            GameObject _taskButton = Instantiate(taskPrefab, transform.position, Quaternion.identity, taskListParent.transform);
            _taskButton.transform.localPosition = new Vector3(0, 85 - (30 * i), 0);

            _taskButton.GetComponent<TaskHolder>().SetValues(_newQuest.GetTasks()[i], this);
        }
    }


    public void SetTaskEditor(ITask _task)
    {
        //Enable al type of task editable things
        currentTaskTitleText.text = _task.TaskDescription();
        Debug.Log(_task.TaskDescription());
    }


    public Quest GetNewQuest()
    {
        return newQuest;
    }
}
