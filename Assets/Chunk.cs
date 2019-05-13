using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk {

	public Material cubeMaterial;
	public Block[,,] chunkData;
	public GameObject chunk;

    public IEnumerator BuildChunkT()
    {
        chunkData = new Block[World.chunkSize, World.chunkSize, World.chunkSize];

        for (int y = 0; y < World.chunkSize; y++)
        {
            for (int z = 0; z < World.chunkSize; z++)
            {
                for (int x = 0; x < World.chunkSize; x++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    int worldX = (int)(x + chunk.transform.position.x);
                    int worldY = (int)(y + chunk.transform.position.y);
                    int worldZ = (int)(z + chunk.transform.position.z);

                    if (Utils.fBM3D(worldX, worldY, worldZ, 0.075f, 4) < 0.3f)
                        chunkData[x, y, z] = new Block(Block.BlockType.AIR, pos,
                                        chunk.gameObject, this);
                    else if (worldY <= Utils.GenerateStoneHeight(worldX, worldZ))
                    {
                        if (Utils.fBM3D(worldX, worldY, worldZ, 0.3f, 3) > 0.7f && worldY <= 16)
                        {
                            chunkData[x, y, z] = new Block(Block.BlockType.DIAMOND, pos,
                                        chunk.gameObject, this);
                            // Debug.Log("Diamond");
                        }
                        else
                        {
                            chunkData[x, y, z] = new Block(Block.BlockType.STONE, pos,
                                        chunk.gameObject, this);
                        }
                    }
                    else if (worldY == Utils.GenerateHeight(worldX, worldZ))
                        chunkData[x, y, z] = new Block(Block.BlockType.GRASS, pos,
                                        chunk.gameObject, this);
                    else if (worldY < Utils.GenerateHeight(worldX, worldZ))
                        chunkData[x, y, z] = new Block(Block.BlockType.DIRT, pos,
                                        chunk.gameObject, this);
                    else
                        chunkData[x, y, z] = new Block(Block.BlockType.AIR, pos,
                                        chunk.gameObject, this);
                }
            }
            yield return null;
        }
	}

    public void BuildChunk()
    {
        chunkData = new Block[World.chunkSize, World.chunkSize, World.chunkSize];

        for (int y = 0; y < World.chunkSize; y++)
        {
            for (int z = 0; z < World.chunkSize; z++)
            {
                for (int x = 0; x < World.chunkSize; x++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    int worldX = (int)(x + chunk.transform.position.x);
                    int worldY = (int)(y + chunk.transform.position.y);
                    int worldZ = (int)(z + chunk.transform.position.z);

                    if (Utils.fBM3D(worldX, worldY, worldZ, 0.075f, 4) < 0.3f)
                        chunkData[x, y, z] = new Block(Block.BlockType.AIR, pos,
                                        chunk.gameObject, this);
                    else if (worldY <= Utils.GenerateStoneHeight(worldX, worldZ))
                    {
                        if (Utils.fBM3D(worldX, worldY, worldZ, 0.3f, 3) > 0.7f && worldY <= 16)
                        {
                            chunkData[x, y, z] = new Block(Block.BlockType.DIAMOND, pos,
                                        chunk.gameObject, this);
                            // Debug.Log("Diamond");
                        }
                        else
                        {
                            chunkData[x, y, z] = new Block(Block.BlockType.STONE, pos,
                                        chunk.gameObject, this);
                        }
                    }
                    else if (worldY == Utils.GenerateHeight(worldX, worldZ))
                        chunkData[x, y, z] = new Block(Block.BlockType.GRASS, pos,
                                        chunk.gameObject, this);
                    else if (worldY < Utils.GenerateHeight(worldX, worldZ))
                        chunkData[x, y, z] = new Block(Block.BlockType.DIRT, pos,
                                        chunk.gameObject, this);
                    else
                        chunkData[x, y, z] = new Block(Block.BlockType.AIR, pos,
                                        chunk.gameObject, this);
                }
            }
        }
    }

    public IEnumerator DrawChunkT()
	{
        for (int y = 0; y < World.chunkSize; y++)
        {
            for (int z = 0; z < World.chunkSize; z++)
            {
                for (int x = 0; x < World.chunkSize; x++)
                {
                    chunkData[x, y, z].Draw();
                }
            }
            yield return null;
        }
		CombineQuads();
        MeshCollider collider = chunk.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        collider.sharedMesh = chunk.transform.GetComponent<MeshFilter>().mesh;
	}

    public void DrawChunk()
    {
        for (int y = 0; y < World.chunkSize; y++)
        {
            for (int z = 0; z < World.chunkSize; z++)
            {
                for (int x = 0; x < World.chunkSize; x++)
                {
                    chunkData[x, y, z].Draw();
                }
            }
        }
        CombineQuads();
        MeshCollider collider = chunk.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        collider.sharedMesh = chunk.transform.GetComponent<MeshFilter>().mesh;
    }
    public Chunk (Vector3 position, Material c) {
		
		chunk = new GameObject(World.BuildChunkName(position));
		chunk.transform.position = position;
		cubeMaterial = c;
		
	}
	
	void CombineQuads()
	{
		MeshFilter[] meshFilters = chunk.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length) {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            i++;
        }
       
        MeshFilter mf = (MeshFilter) chunk.gameObject.AddComponent(typeof(MeshFilter));
        mf.mesh = new Mesh();

        mf.mesh.CombineMeshes(combine);

		MeshRenderer renderer = chunk.gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		renderer.material = cubeMaterial;

		foreach (Transform quad in chunk.transform) {
     		GameObject.Destroy(quad.gameObject);
 		}

	}

}
