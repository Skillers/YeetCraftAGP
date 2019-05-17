using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerMB : MonoBehaviour
{
    //The interval (in seconds) in which the tread will take the values
    private readonly float DATA_COLLECTION_INTERVAL = 6;

    //Timer value
    private float timer = 0;


    //Player reference. Is set in inspector
    public GameObject player;
 
    void Start()
    {
        timer = 0;
    }

    void Update()
    {

        if (Interval())
        {
            WorldData.changedPlayerPosition(player.transform.position);
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
}
