using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToTaskEditBehaviour : MonoBehaviour
{
    public TaskEditor taskEditor;
    [Space]
    public InputField xPosition, yPosition, zPosition; //inpuyt fields
    public Text currentGoalPosText;

    Vector3 newPosition;
    /// <summary>
    /// Set the values of this thing from the current task
    /// </summary>
    public void SetValues(Vector3 _currentGoalPos)
    {
        xPosition.text = _currentGoalPos.x.ToString();
        yPosition.text = _currentGoalPos.y.ToString();
        zPosition.text = _currentGoalPos.z.ToString();

    }
    
    public void UpdatePosition()
    {
        newPosition = new Vector3(int.Parse( xPosition.text),int.Parse( yPosition.text), int.Parse(zPosition.text));

        //Debug.Log(newPosition);
    }

    public void DonePressed()
    {
        //Check if all is a good number
        ITask _newTask = new GoToTask(newPosition);

        //Go to task editor
        taskEditor.UpdateCurrentTask(_newTask);
        
    }
}
