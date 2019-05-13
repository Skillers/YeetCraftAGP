using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GameObject block;
    public int worldSizeX = 10;
    public int worldSizeY = 2;
    public int worldSizeZ = 10;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(BuildWorld());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BuildWorld()
    {
        for (int z = 0; z < worldSizeZ; z++)
        {
            for (int y = 0; y < worldSizeY; y++)
            {
                for (int x = 0; x < worldSizeX; x++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    GameObject cube = GameObject.Instantiate(block, pos, Quaternion.identity);
                    cube.name = x + "_" + y + "_" + z;
                    cube.GetComponent<Renderer>().material = new Material(Shader.Find("Standard"));
                }
                yield return null;
            }
            
        }
    }

}
