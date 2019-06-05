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
    public InputField questMainText;
    public Text CurrentSelectedIndexText;
    public GameObject taskListParent;
    public Dropdown taskTypeDropDownMenu;

    public QuestHolder questHolder;

    public Text currentTaskTitleText;
    public GameObject currentTaskEditor;

    [Space]
    public GameObject goToEditPanel;
    public GameObject gatherEditPanel;
    public GameObject buildEditPanel;

    [Space]
    public GoToTaskEditBehaviour goTotaskEditPanel;

    public int currentTaskIndex = 0;

    private ITask currentEditedTask;

    public Quest currentEditableQuest; //used to reffer back to orgin quest
    private TaskHolder currentTaskHolder;

    public void SetValues(Quest _newQuest)
    {
        //Empty all create objects
        foreach (Transform item in taskListParent.transform)
        {
            Destroy(item.gameObject);
        }

        currentEditableQuest = _newQuest;

        currentTaskTitleText.text = "";
        CurrentSelectedIndexText.text = currentTaskIndex.ToString();
        questMainText.text = currentEditableQuest.GetTitle();

        //Add all tasks
        for (int i = 0; i < currentEditableQuest.GetTasks.Count; i++)
        {
            GameObject _taskButton = Instantiate(taskPrefab, transform.position, Quaternion.identity, taskListParent.transform);
            _taskButton.transform.localPosition = new Vector3(0, 85 - (30 * i), 0);

            _taskButton.GetComponent<TaskHolder>().SetValues(currentEditableQuest.GetTasks[i], this, i);

            if (i == currentTaskIndex)
            {
                currentTaskHolder = _taskButton.GetComponent<TaskHolder>();
            }
        }

        currentTaskHolder.HighlightTask();
        //Disable all panels
        goToEditPanel.SetActive(false);
        gatherEditPanel.SetActive(false);
        buildEditPanel.SetActive(false);

        currentTaskEditor.SetActive(false);
    }

    /// <summary>
    /// Opens a sub menu that let you edit the tasks
    /// </summary>
    /// <param name="_task"></param>
    public void SetTaskEditor(ITask _task)
    {
        currentTaskEditor.SetActive(true);
        //Enable al type of task editable things
        currentTaskTitleText.text = (currentTaskIndex+1) + " - " + _task.TaskDescriptionBuilder();

        //Keep track of current task
        currentEditedTask = _task;

        UpdateTaskPanel(_task);
    }

    /// <summary>
    /// Called when a task is pressed
    /// Update the edit panel
    /// </summary>
    /// <param pressed task="_task"></param>
    public void UpdateTaskPanel(ITask _task)
    {
        goToEditPanel.SetActive(false);
        gatherEditPanel.SetActive(false);
        buildEditPanel.SetActive(false);

        //set the dropdown on the right type
        taskTypeDropDownMenu.value = _task.TaskID() - 1;

        //Update panel
        switch (_task.TaskID() - 1)
        {
            case 0://go to task
                goToEditPanel.SetActive(true);
                goTotaskEditPanel.SetValues(_task.GoalPos());
                //Debug.Log("go");
                break;
            case 1: //gather task
                gatherEditPanel.SetActive(true);
                // Debug.Log("gather");
                break;
            case 2: //build task
                buildEditPanel.SetActive(true);
                // Debug.Log("build");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Call this when the dropdown edit type is changed
    /// 
    /// 1 = go to
    /// 2 = gather
    /// 3 =  build
    /// 
    /// </summary>
    /// <param the task id="_taskNumber"></param>
    public void TaskTypeDropDownChanged(Dropdown _dropDownPanel)
    {
        if (currentEditedTask == null)
            return;

        goToEditPanel.SetActive(false);
        gatherEditPanel.SetActive(false);
        buildEditPanel.SetActive(false);

        switch (_dropDownPanel.value)
        {
            case 0: // go to
                goToEditPanel.SetActive(true);
                break;
            case 1: // gather
                gatherEditPanel.SetActive(true);
                break;
            case 2: // build
                buildEditPanel.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void QuestNameChanged()
    {
        //string newName = questMainText.text;
        currentEditableQuest.EditTitle(questMainText.text);
    }

    /// <summary>
    /// Add an task to the quest,
    /// basic task that is added is always a go to task
    /// </summary>
    public void AddTask()
    {
        //we copy the quest en replace it with a replica, with an extra task
        currentEditableQuest.GetTasks.Add(new GoToTask(new Vector3(0, 0, 0)));

        //Highlight the last created task
        currentTaskIndex = currentEditableQuest.GetTasks.Count - 1;

        SetValues(currentEditableQuest);
        currentTaskHolder.HighlightTask();
    }

    /// <summary>
    /// Switch two tasks
    /// </summary>
    /// <param The way you want to change="_increase"></param>
    public void SwitchTasks(int _increase)
    {
        if (_increase + currentTaskIndex < 0 || _increase + currentTaskIndex >= currentEditableQuest.GetTasks.Count)
        {
            Debug.LogWarning("Index out of range");
            return;
        }

        ITask tempTask = currentEditableQuest.GetTasks[currentTaskIndex];
        currentEditableQuest.GetTasks[currentTaskIndex] = currentEditableQuest.GetTasks[currentTaskIndex + _increase];
        currentEditableQuest.GetTasks[currentTaskIndex + _increase] = tempTask;

        //update index text
        currentTaskIndex += _increase;
        SetValues(currentEditableQuest);
        currentTaskHolder.HighlightTask();
    }

    public void RemoveTask()
    {
        //remove the task on index
        currentEditableQuest.GetTasks.RemoveAt(currentTaskIndex);
        SetValues(currentEditableQuest);
    }

    public void DoneWithQuest()
    {
        MainMenuController.Instance.QuestCreationMenuOpen();
    }

    public void DeleteQuest()
    {
        //remove quest
        questHolder.quests.Remove(currentEditableQuest);

        //go back to quest menu
        MainMenuController.Instance.QuestCreationMenuOpen();
    }

    /// <summary>
    /// Get the new edited quest
    /// </summary>
    /// <returns>the new quest</returns>
    public Quest GetNewQuest()
    {
        return currentEditableQuest;
    }
}
