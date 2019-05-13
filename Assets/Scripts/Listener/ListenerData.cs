using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerData
{
    //All tracked values
    private Vector3[] lastPlayerPositions;

    //Measure settings
    int positionCounter;

    /// <summary>
    /// Constructor for the listener class
    /// </summary>
    /// <param Length of the array that keeps track of the position="_trackedPositions"></param>
    public ListenerData(int _trackedPositions)
    {
        lastPlayerPositions = new Vector3[_trackedPositions];

        positionCounter = 0;
    }

    /// <summary>
    /// Add an value to the posiotion array
    /// </summary>
    /// <param The position of the player="_position"></param>
    public void AddPlayerPosition(Vector3 _position)
    {
        lastPlayerPositions[positionCounter] = _position;
        ++positionCounter;
        if (positionCounter >= lastPlayerPositions.Length)
        {
            positionCounter = 0;
        }
    }

    /// <summary>
    /// Returns the array of tracked positions of the player
    /// </summary>
    public Vector3[] GetPositionArray
    {
        get { return lastPlayerPositions; }
    }

    /// <summary>
    /// Get the value that the player has walked in total So not form all points to their next points (Alll positions to their next)
    /// </summary>
    public float GetTotalTraveledDistance
    {
        get
        {
            float distance = 0;

            for (int i = 0; i < lastPlayerPositions.Length - 1; i++)
            {
                //Get distance form 2 points
                float add = Vector3.Distance(lastPlayerPositions[i], lastPlayerPositions[i + 1]);
                distance += add;
            }

            return distance;
        }
    }

    /// <summary>
    /// Get the total distance traveld from begin of tracking to end (cur pos to begin pos)
    /// </summary>
    public float GetDistanceTraveled
    {
        get
        {
            if (positionCounter < lastPlayerPositions.Length - 1)
            {

                return Vector3.Distance(lastPlayerPositions[positionCounter], lastPlayerPositions[positionCounter + 1]);
            }
            else
            {
                return Vector3.Distance(lastPlayerPositions[positionCounter], lastPlayerPositions[0]);
            }
        }
    }

}
