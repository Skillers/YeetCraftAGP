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
