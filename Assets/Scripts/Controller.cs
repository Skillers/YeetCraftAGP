using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject QuestLogHud;
    public GameObject QuestDiscriptionHud;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Quest currentQuest;

    public CursorLockMode wantedMode;

    public GameObject questHud;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);

        

        foreach (Quest quest in QuestHolder.Instance.quests)
        {
            quest.StartQuest();
            QuestLog.questLog.Add(quest);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (wantedMode == CursorLockMode.Locked)
            {
                QuestLogHud.SetActive(true);
                wantedMode = CursorLockMode.Confined;
                Cursor.lockState = wantedMode;
                Cursor.visible = true;

                //enable quest menu
                //dissable mining
            }
            else
            {
                QuestLogHud.SetActive(false);
                QuestDiscriptionHud.SetActive(false);
                wantedMode = CursorLockMode.Locked;
                Cursor.lockState = wantedMode;
                Cursor.visible = false;

                //diable quest menu

            }
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
