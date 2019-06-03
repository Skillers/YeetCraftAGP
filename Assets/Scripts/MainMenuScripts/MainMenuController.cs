using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Refs:")]
    public GameObject MainMenuObject;
    public GameObject QuestListsMenu;
    public GameObject QuestEditorMenu;
    private QuestEditorBehaviour editorBehaviour;

    public static MainMenuController Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MainMenuObject.SetActive(true);
        QuestListsMenu.SetActive(false);
        QuestEditorMenu.SetActive(false);

        editorBehaviour = QuestEditorMenu.GetComponent<QuestEditorBehaviour>();
    }

    public void OpenQuestEdit(Quest _editedQuest)
    {
        MainMenuObject.SetActive(false);
        QuestListsMenu.SetActive(false);
        QuestEditorMenu.SetActive(true);

        editorBehaviour.SetValues(_editedQuest);
    }

    public void QuestCreationMenuOpen()
    {
        MainMenuObject.SetActive(false);
        QuestListsMenu.SetActive(true);
        QuestEditorMenu.SetActive(false);
    }

    public void MainMenuOpen()
    {
        //open the mian menu
        MainMenuObject.SetActive(true);
        QuestListsMenu.SetActive(false);
        QuestEditorMenu.SetActive(false);
    }

    public void StartGame()
    {
        MainMenuObject.SetActive(false);
        QuestListsMenu.SetActive(false);
        QuestEditorMenu.SetActive(false);
        //Go to main scene game
        SceneManager.LoadScene(1);
    }
}
