using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskEditor : MonoBehaviour
{
    public QuestEditorBehaviour editor;

    private Quest currentQuest;

    public void UpdateCurrentTask(ITask _newTask)
    {
        //Edit task in quest
        editor.currentEditableQuest.SetTaskOn(editor.currentTaskIndex, _newTask);

        editor.SetValues(editor.currentEditableQuest);
    }
    

}
