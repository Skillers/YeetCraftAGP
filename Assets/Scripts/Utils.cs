using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Utils : MonoBehaviour {

    static int maxHeight = 265;
    static float smooth = 0.01f;
    static int octaves = 4;
    static float persistence = 0.5f;

    public static int GenerateHeight(float x, float z)
    {
        float height = Map(0, maxHeight, 0, 1, fBM(x * smooth, z * smooth, octaves, persistence));
        return (int)height;
    }


    public static int GenerateStoneHeight(float x, float z)
    {
        float height = Map(0, maxHeight, 0, 1, fBM(x * smooth, z * smooth, octaves+1, persistence))-4;
        if (height < 0)
        {
            height = 0;
        }
        return (int)height;
    }

    public static float fBM3D(float x, float y, float z, float sm, int oct)
    {
        float XY = fBM(x * sm, y * sm, oct, 0.5f);
        float YZ = fBM(y * sm, z * sm, oct, 0.5f);
        float XZ = fBM(x * sm, z * sm, oct, 0.5f);

        float YX = fBM(y * sm, x * sm, oct, 0.5f);
        float ZY = fBM(z * sm, y * sm, oct, 0.5f);
        float ZX = fBM(z * sm, x * sm, oct, 0.5f);

        return (XY + YZ + XZ + YX + ZY + ZX) / 6.0f;
    }

    static float Map(float newMin, float newMax, float oldMin, float oldMax, float value)
    {
        return Mathf.Lerp(newMin, newMax, Mathf.InverseLerp(oldMin, oldMax, value));
    }


    static float fBM(float x, float z, int octaves, float persistence)
    {
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;
        float offset = 32000f;
        for (int i = 0; i < octaves; i++)
        {
            total += Mathf.PerlinNoise(x+offset * frequency, z+offset * frequency) * amplitude;
            maxValue += amplitude;
            amplitude *= persistence;
            frequency *= 2;
        }
        return total / maxValue;
    }

}
