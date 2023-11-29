using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    static public float[,] GenerateNoiseMap(int height, int width, float scale)
    {
        float[,] noiseMap = new float[width, height];

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float sampleX = x / scale;
                float sampleY = y / scale;
                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }

        return noiseMap;
    }

    static public Texture2D GenerateNoiseTexture(int height, int width, float scale)
    {
        Texture2D text = new Texture2D(width, height);

        float[,] map = Noise.GenerateNoiseMap(height, width, scale);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                text.SetPixel(x, y, Color.Lerp(Color.black, Color.white, map[x, y]));
            }
        }

        text.Apply();

        return text;
    }
}
