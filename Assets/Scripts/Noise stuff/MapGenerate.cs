using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerate : MonoBehaviour
{   
    // Map display modes in the editor
    public enum DrawMode{Mesh};
    public DrawMode drawMode;

    // Variables
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    // Heightmap variables
    public float heightMulti;
    public AnimationCurve meshHeight;

    // Octaves, persistance, lacunarity
    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    // Checkbox in the editor to enable the noise to generate live without entering game mode  
    public bool autoUpdate;

    public void GenerateNoise() {
        // Map generation passed with all the parameters needed
        float[,] noiseMap = PerlinNoise.GenerateNoise(mapWidth, mapHeight, noiseScale, octaves, persistance, lacunarity);

        // Display mode selector function
        DisplayMap display = FindObjectOfType<DisplayMap>();
        if (drawMode == DrawMode.Mesh) {
            display.DrawMesh(MeshGen.GenerateTerrainMesh(noiseMap, heightMulti, meshHeight));
        }
    }

    // Anti-breaking stuff
    void Validate() {
        if(mapWidth < 1) {
            mapWidth = 1;
        }
        if(mapHeight < 1) {
            mapHeight = 1;
        }
        if(lacunarity < 1) {
            lacunarity = 1;
        }
        if(octaves < 0) {
            octaves = 0;
        }
    }
}
