using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldListener : MonoBehaviour
{
    //The interval (in seconds) in which the tread will take the values
    private readonly float DATA_COLLECTION_INTERVAL_SHORT = 6;
    private readonly float DATA_COLLECTION_INTERVAL_LONG = 60;

    //Timer value
    private float timerShort;
    private float timerLong;


    //Player reference. Is set in inspector
    public GameObject player;
 
    void Start()
    {
        timerShort = 0;
        timerLong = 0;
    }

    void Update()
    {
        WorldData.changedLatestPlayerPosition(player.transform.position);

        if (Interval(DATA_COLLECTION_INTERVAL_SHORT, timerShort))
        {
            WorldData.changedPlayerPositionShort(player.transform.position);
        }
        if (Interval(DATA_COLLECTION_INTERVAL_LONG, timerLong))
        {
            WorldData.changedPlayerPositionLong(player.transform.position);
        }

    }

    /// <summary>
    /// Used to call an interval loop
    /// </summary>
    /// <returns>true when there is one loop done</returns>
    private bool Interval(float intervalAmount, float timer)
    {
        timer += Time.deltaTime;
        if (timer > intervalAmount)
        {
            timer = 0;
            return true;
        }
        return false;
    }
}
