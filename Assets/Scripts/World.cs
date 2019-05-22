using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    
    public GameObject player;
	public Material textureAtlas;
	public static int columnHeight = 16;
	public static int chunkSize = 16;
    public static int radius = 2;

	public static Dictionary<string, Chunk> chunks;

	public static string BuildChunkName(Vector3 v)
	{
		return (int)v.x + "_" + 
			         (int)v.y + "_" + 
			         (int)v.z;
	}

    public static Block GetWorldBlock(Vector3 pos)
    {
        int cx, cy, cz;

        if (pos.x < 0)
            cx = (int)((Mathf.Round(pos.x - chunkSize) + 1) / (float)chunkSize) * chunkSize;
        else
            cx = (int)(Mathf.Round(pos.x) / (float)chunkSize) * chunkSize;

        if (pos.y < 0)
            cy = (int)((Mathf.Round(pos.y - chunkSize) + 1) / (float)chunkSize) * chunkSize;
        else
            cy = (int)(Mathf.Round(pos.y) / (float)chunkSize) * chunkSize;

        if (pos.z < 0)
            cz = (int)((Mathf.Round(pos.z - chunkSize) + 1) / (float)chunkSize) * chunkSize;
        else
            cz = (int)(Mathf.Round(pos.z) / (float)chunkSize) * chunkSize;

        int blx = (int)Mathf.Abs((float)Mathf.Round(pos.x) - cx);
        int bly = (int)Mathf.Abs((float)Mathf.Round(pos.y) - cy);
        int blz = (int)Mathf.Abs((float)Mathf.Round(pos.z) - cz);

        string cn = BuildChunkName(new Vector3(cx, cy, cz));
        Chunk c;
        if (chunks.TryGetValue(cn, out c))
        {

            return c.chunkData[blx, bly, blz];
        }
        else
            return null;
    }

    IEnumerator BuildWorld()
	{
        
        for (int z = -radius; z < radius; z++)
        {
            for (int x = -radius; x < radius; x++)
            {
                for (int y = 0; y < columnHeight; y++)
                {
                    Vector3 chunkPosition = new Vector3(x * chunkSize, y * chunkSize, z * chunkSize);
                    Chunk c = new Chunk(chunkPosition, textureAtlas);
                    c.BuildChunk();
                    // yield return StartCoroutine(c.BuildChunkT());
                    c.chunk.transform.parent = this.transform;
                    chunks.Add(c.chunk.name, c);
                }
            }
        }

        foreach (KeyValuePair<string, Chunk> c in chunks)
        {
            c.Value.DrawChunk();
            //yield return StartCoroutine(c.Value.DrawChunkT());
        }

        player.gameObject.SetActive(true);
        yield return null;

    }

    void Start () {
		chunks = new Dictionary<string, Chunk>();
		this.transform.position = Vector3.zero;
		this.transform.rotation = Quaternion.identity;
		StartCoroutine(BuildWorld());
	}

}
