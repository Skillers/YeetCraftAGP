using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteraction : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 4))
            {
                Vector3 hitBlock = hit.point - hit.normal / 2.0f;
                Transform hitTransform = hit.collider.gameObject.transform;
                int x = (int)(Mathf.Round(hitBlock.x) - hitTransform.position.x);
                int y = (int)(Mathf.Round(hitBlock.y) - hitTransform.position.y);
                int z = (int)(Mathf.Round(hitBlock.z) - hitTransform.position.z);

                Chunk hitc;
                if (World.chunks.TryGetValue(hit.collider.gameObject.name, out hitc) && hitc.chunkData[x, y, z].HitBlock())
                {
                    List<string> updates = new List<string>();
                    float thisChunkx = hitTransform.position.x;
                    float thisChunky = hitTransform.position.y;
                    float thisChunkz = hitTransform.position.z;

                    if (x == 0)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx - World.chunkSize, thisChunky, thisChunkz)));
                    if (x == World.chunkSize - 1)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx + World.chunkSize, thisChunky, thisChunkz)));
                    if (y == 0)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx, thisChunky - World.chunkSize, thisChunkz)));
                    if (y == World.chunkSize - 1)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx, thisChunky + World.chunkSize, thisChunkz)));
                    if (z == 0)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx, thisChunky, thisChunkz - World.chunkSize)));
                    if (z == World.chunkSize - 1)
                        updates.Add(World.BuildChunkName(new Vector3(thisChunkx, thisChunky, thisChunkz + World.chunkSize)));

                    foreach (string cname in updates)
                    {
                        Chunk c;
                        if (World.chunks.TryGetValue(cname, out c))
                        {
                            c.Redraw();
                        }
                    }
                }
            }
        }
    }
}
