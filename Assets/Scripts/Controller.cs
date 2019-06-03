using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Quest currentQuest;

    public CursorLockMode wantedMode;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);

        ////Creates a test quest.
        //List<ITask> tasks = new List<ITask>();
        //tasks.Add(new GoToTask(new Vector3(5,0,5)));
        //tasks.Add(new GatherTask(10 , Block.BlockType.GRASS));
        //tasks.Add(new GatherTask(10, Block.BlockType.DIRT));
        //tasks.Add(new GatherTask(10, Block.BlockType.STONE));
        //QuestLog.questLog.Add(currentQuest = new Quest(tasks, "Gatherings of Basics"));

        List<ITask> tasks = new List<ITask>();
        tasks.Add(new BuildTask(5, Block.BlockType.DIAMOND));
        QuestLog.questLog.Add(currentQuest = new Quest(tasks, "Gatherings of Basics"));
        //Get quest from the questholder
        //for (int i = 0; i < QuestHolder.Instance.quests.Count; i++)
        //{
        //    Debug.Log(QuestHolder.Instance.quests[i].GetDescription());
        //    QuestLog.questLog.Add(currentQuest = QuestHolder.Instance.quests[i]);
        //    QuestHolder.Instance.quests[i].StartQuest();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            wantedMode = CursorLockMode.Confined;
            Cursor.lockState = wantedMode;
            Cursor.visible = (CursorLockMode.Locked != wantedMode);
        }

        if (Input.GetKeyDown("space"))
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.up * 5;
        }
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * 3;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * Time.deltaTime * 3;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * Time.deltaTime * 3;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * Time.deltaTime * 3;
        }

        if (wantedMode == CursorLockMode.Locked)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        transform.GetChild(0).transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
