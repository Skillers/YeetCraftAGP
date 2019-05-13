using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerMB : MonoBehaviour
{
    //The interval (in seconds) in which the tread will take the values
    private readonly float DATA_COLLECTION_INTERVAL = 5;

    //Timer value
    private float timer = 0;

    //Data class
    private ListenerData data = new ListenerData(4);

    //Player ref --- is set in inspector
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Interval())
        {
            GetData();
            Debug.Log("Joinkers");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Total distance traveled: " + Data.GetTotalTraveledDistance);
            Debug.Log("distance traveled: " + Data.GetDistanceTraveled);
        }
    }

    /// <summary>
    /// Used to call an interval loop
    /// </summary>
    /// <returns>true when there is one loop done</returns>
    private bool Interval()
    {
        timer += Time.deltaTime;
        if (timer > DATA_COLLECTION_INTERVAL)
        {
            timer = 0;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Get/update all data from the player.
    /// </summary>
    private void GetData()
    {
        Data.AddPlayerPosition(player.transform.position);

    }


    public ListenerData Data { get => data; }
}
