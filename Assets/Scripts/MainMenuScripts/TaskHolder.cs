using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskHolder : MonoBehaviour
{
    public Text taskName;
    ITask currentTask;

    QuestEditorBehaviour editor;

    public void SetValues(ITask _task, QuestEditorBehaviour _editor)
    {
        editor = _editor;
        currentTask = _task;
        taskName.text = _task.TaskDescription();
    }

    /// <summary>
    /// Called from the editor in a linked button
    /// </summary>
    public void HighlightTask()
    {
        //Set all the editable things active in the menu
        editor.SetTaskEditor(currentTask);
    }
}
