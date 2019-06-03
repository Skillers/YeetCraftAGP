using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatherTaskEditBehaviour : MonoBehaviour
{
    [Header("Refs:")]
    public Dropdown blockTypeDropDown;

    public InputField amountInputField;

    [Space]
    public TaskEditor taskEditor;

    Block.BlockType selectedBlockType = Block.BlockType.DIRT;

    //Set the right value of block
    public void DropDownChanged()
    {
        switch (blockTypeDropDown.value)
        {
            case 0:
                selectedBlockType = Block.BlockType.DIRT;
                break;
            case 1:
                selectedBlockType = Block.BlockType.GRASS;
                break;
            case 2:
                selectedBlockType = Block.BlockType.STONE;
                break;
            case 3:
                selectedBlockType = Block.BlockType.DIAMOND;
                break;
            default:
                break;
        }
    }

    public void EditClicked()
    {
        //Check if all is a good number
        ITask _newTask = new GatherTask(int.Parse(amountInputField.text), selectedBlockType);

        //Go to task editor
        taskEditor.UpdateCurrentTask(_newTask);
    }
}
