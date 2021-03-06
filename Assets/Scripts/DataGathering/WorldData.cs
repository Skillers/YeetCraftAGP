﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour
{
    //Tracked data
    public static int minedBlockCount;
    public static int placedBlockCount;
    public static Block.BlockType lastMinedblockType;
    public static Block.BlockType lastPlacedblockType;

    public static Queue<Vector3> lastShortTimePositions = new Queue<Vector3>();
    public static Queue<Vector3> lastLongTimePositions = new Queue<Vector3>();
    public static Vector3 lastPlayerPosition;

    //All events on which a developer can subscribe;
    public delegate void ChangedMinedCountEvent();
    public static event ChangedMinedCountEvent changedMinedCount;

    public delegate void ChangedPlacedCountEvent();
    public static event ChangedPlacedCountEvent changedPlacedCount;

    public delegate void ChangedLastMinedEvent(Block.BlockType blockType);
    public static event ChangedLastMinedEvent changedLastMinedBlockEvent;

    public delegate void ChangedLastPlacedEvent(Block.BlockType blockType);
    public static event ChangedLastPlacedEvent changedLastPlacedBlockEvent;

    public delegate void ChangedPlayerPositionShortEvent(Vector3 position);
    public static event ChangedPlayerPositionShortEvent changedPlayerPositionShortEvent;

    public delegate void ChangedPlayerPositionLongEvent(Vector3 position);
    public static event ChangedPlayerPositionLongEvent changedPlayerPositionLongEvent;

    public delegate void ChangedLatestPlayerPositionEvent(Vector3 position);
    public static event ChangedLatestPlayerPositionEvent changedLatestPlayerPositionEvent;

    public delegate void ChangedTaskCompletedEvent();
    public static event ChangedTaskCompletedEvent changedTaskCompletedEvent;

    public delegate void ChangeQuestCompletedEvent(Quest completedQuest);
    public static event ChangeQuestCompletedEvent changedQuestCompletedEvent;

    public delegate void ChangeQuestStartedEvent(Quest startedQuest);
    public static event ChangeQuestStartedEvent changedQuestStartedEvent;

    //Event for block counter
    public static void changeMineCount()
    {
        minedBlockCount++;
        if (changedMinedCount != null)
        {
            changedMinedCount();
        }
    }

    public static void changePlacedCount()
    {
        placedBlockCount++;
        if (changedPlacedCount != null)
        {
            changedPlacedCount();
        }
    }

    //Event for Last mined block type
    public static void changeLastMinedBlock(Block.BlockType blockType)
    {
        lastMinedblockType = blockType;
        if (changedLastMinedBlockEvent != null)
        {
            changedLastMinedBlockEvent(blockType);
        }
    }

    //Event for Last mined block type
    public static void changeLastPlacedBlock(Block.BlockType blockType)
    {
        lastPlacedblockType = blockType;
        if (changedLastPlacedBlockEvent != null)
        {
            changedLastPlacedBlockEvent(blockType);
        }
    }

    //Event for playerPosition histroy short
    public static void changedPlayerPositionShort(Vector3 position)
    {
        if (lastShortTimePositions.Count > 9)
        {
            lastShortTimePositions.Dequeue();
        }
            lastShortTimePositions.Enqueue(position);
          
        changedPlayerPositionShortEvent(position); 
    }

    //Event for playerPosition histroy long
    public static void changedPlayerPositionLong(Vector3 position)
    {
        if (lastLongTimePositions.Count > 9)
        {
            lastLongTimePositions.Dequeue();
        }
        lastLongTimePositions.Enqueue(position);

        changedPlayerPositionLongEvent(position);
    }

    public static void changedLatestPlayerPosition(Vector3 _position)
    {
        lastPlayerPosition = _position;
        if (changedLatestPlayerPositionEvent != null)
        {
            changedLatestPlayerPositionEvent(_position);
        }
    }

    public static void changedTaskCompleted()
    {
        if (changedTaskCompletedEvent != null)
        {
            changedTaskCompletedEvent();
        }
    }

    public static void changedQuestCompleted(Quest completedQuest)
    {
        if (changedQuestCompletedEvent != null)
        {
            changedQuestCompletedEvent(completedQuest);
        }
    }

    public static void changedQuestStarted(Quest startedQuest)
    {
        if (changedQuestStartedEvent != null)
        {
            changedQuestStartedEvent(startedQuest);
        }
    }
}
