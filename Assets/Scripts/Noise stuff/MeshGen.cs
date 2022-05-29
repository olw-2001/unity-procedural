using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGen
{
    // Generates the mesh with the heightmap, using the multiplier and the anim curve 
    public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMulti, AnimationCurve meshHeight) {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
        float topLeftX = (width - 1) / -2f;
        float topLeftZ = (height - 1) / 2f;

        MeshData meshData = new MeshData(width, height);
        int vertexIndex = 0;

        // Generating mesh triangles looping through to find the width and height
        for(int y = 0; y < height; y++) {
            for(int x = 0; x < width; x++) {
                meshData.vertices[vertexIndex] = new Vector3(topLeftX + x, meshHeight.Evaluate(heightMap[x,y]) * heightMulti, topLeftZ - y);
                meshData.uv[vertexIndex] = new Vector2(x/(float)width, y/(float)height);
                
                if(x < width - 1 && y < height - 1) {
                    meshData.AddTriangle(vertexIndex, vertexIndex + width + 1, vertexIndex + width);
                    meshData.AddTriangle(vertexIndex + width + 1, vertexIndex, vertexIndex + 1);
                }
                vertexIndex++;
            }
        }

        return meshData;
    }
}

// All the data needed to create a mesh (generating triangles etc)
// (UV maps might not be used in the project but they are included)

public class MeshData {
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uv;

    int triangleIndex;

    public MeshData(int meshWidth, int meshHeight) {
        vertices = new Vector3[meshWidth * meshHeight];
        triangles = new int[(meshWidth-1) * (meshHeight-1) * 6];
        uv = new Vector2[meshWidth * meshHeight];
    }
    public void AddTriangle(int a, int b, int c) {
        triangles [triangleIndex] = a;
        triangles [triangleIndex + 1] = b;
        triangles [triangleIndex + 2] = c;
        triangleIndex += 3;
    }

    public Mesh CreateMesh() {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
        return mesh;
    }
}
