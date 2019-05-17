using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour
{
    //Tracked data
    public static int minedBlockCount;
    public static Block.BlockType lastMinedblockType;

    public static Queue<Vector3> lastMinutePositions = new Queue<Vector3>();
    public static Queue<Vector3> lastTenMinutesPositions = new Queue<Vector3>();
    public static Vector3 lastPlayerPosition;

    private static int PositionCounter;
    
    //Inspector info
    public int MinedBlockCountLive;
    public Block.BlockType lastMinedblockTypeLive;

    public delegate void ChangedMinedCountEvent();
    public static event ChangedMinedCountEvent changedMinedCount;

    public delegate void ChangedLastMinedEvent(Block.BlockType blockType);
    public static event ChangedLastMinedEvent changedLastMinedBlockEvent;

    public delegate void ChangedPlayerPositionEvent(Vector3 position);
    public static event ChangedPlayerPositionEvent changedPlayerPositionEvent;

    //Event for Last mined block type
    public static void changeLastMinedBlock(Block.BlockType blockType)
    {
        lastMinedblockType = blockType;
        if (changedLastMinedBlockEvent != null)
        {
            changedLastMinedBlockEvent(blockType);
        }
    }


    //Event for block counter
    public static void changeMineCount()
    {
        minedBlockCount++;
        if (changedMinedCount != null)
        {
            changedMinedCount();
        }
    }

    public static void changedPlayerPosition(Vector3 position)
    {
        lastPlayerPosition = position;
        if (lastMinutePositions.Count > 9)
        {
            lastMinutePositions.Dequeue();
        }
            lastMinutePositions.Enqueue(position);
            PositionCounter++;
            if(PositionCounter >= 10)
            {
                PositionCounter = 0;
                if (lastTenMinutesPositions.Count > 9)
                {
                    lastTenMinutesPositions.Dequeue();
                }
                lastTenMinutesPositions.Enqueue(position); 
            }
            changedPlayerPositionEvent(position);
        
    }

    //This is just voor inspector info
    public void Update()
    {
        MinedBlockCountLive = minedBlockCount;
        lastMinedblockTypeLive = lastMinedblockType;
    }
}
