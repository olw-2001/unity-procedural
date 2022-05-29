using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise
{
    // Noise generator with all of the values passed in
    public static float[,] GenerateNoise(int mapWidth, int mapHeight, float scale, int octaves, float persistance, float lacunarity) {
        float[,] noiseMap = new float[mapWidth, mapHeight]; // 2D float array

        // Division by 0 error handling
        if(scale <= 0) {
            scale = 0.0001f;
        }

        float maxHeight = float.MinValue;
        float minHeight = float.MaxValue;

        //float halfW = mapWidth / 2f;
        //float halfH = mapHeight / 2f;

        // Creating a Perlin noisemap with a width and a height
        for (int y = 0; y < mapHeight; y++) {
            for(int x = 0; x < mapWidth; x++) {

                // Default values
                float amplitude = 1;
                float frequency = 1;
                float noiseHight = 0;

                for(int i = 0; i < octaves; i++) {
                    // Returns non-integer (float) values, more interesting noise
                    float sampleX = x / scale * frequency; 
                    float sampleY = y / scale * frequency;

                    float noiseValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1; // PerlinNoise range from 1 to -1 instead of 0 to 1
                    // The value of the noise multiplied by the amplitude is added to the height
                    noiseHight += noiseValue * amplitude;

                    // Calculations for persistance and lacunarity
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if(noiseHight > maxHeight) {
                    maxHeight = noiseHight;
                }
                else if(noiseHight < minHeight) {
                    minHeight = noiseHight;
                }
                noiseMap[x, y] = noiseHight;
            }
        }

        for (int y = 0; y < mapHeight; y++) {
            for(int x = 0; x < mapWidth; x++) {
                noiseMap[x,y] = Mathf.InverseLerp(minHeight, maxHeight, noiseMap[x,y]); // InverseLerp returns a value between 0 and 1
            }
        }
        return noiseMap;
    }
}
