using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskHolder : MonoBehaviour
{
    public Text taskName;
    ITask currentTask;
    int taskCount;
    QuestEditorBehaviour editor;

    public void SetValues(ITask _task, QuestEditorBehaviour _editor, int _taskCount)
    {
        editor = _editor;
        currentTask = _task;
        taskName.text = _task.TaskDescriptionBuilder();
        taskCount = _taskCount;
    }

    /// <summary>
    /// Called from the editor in a linked button called from a task button
    /// </summary>
    public void HighlightTask()
    {
        //enable editor panel
        //Set all the editable things active in the menu
        editor.currentTaskIndex = taskCount;
        editor.SetTaskEditor(currentTask);

        editor.CurrentSelectedIndexText.text = (editor.currentTaskIndex + 1) + "";
    }
    
}
