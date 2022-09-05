using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public static MeshData GenerateTerrainMesh(float[,] heightmap, float HeighMultiplaier, AnimationCurve HeightCurve)
    {
        int width = heightmap.GetLength(0);
        int height = heightmap.GetLength(1);

        float topleftX = (width - 1) / -2f;
        float topleftz = (height - 1) / 2f;

        MeshData meshdata = new MeshData(width, height);
        int vertexindex = 0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                meshdata.vertecies[vertexindex] = new Vector3(topleftX + x, HeightCurve.Evaluate(heightmap[x,y]) * HeighMultiplaier, topleftz - y);
                meshdata.UVs[vertexindex] = new Vector2(x / (float)width, y / (float)height);

                if (x < width - 1 && y < height - 1)
                { 
                    meshdata.AddTriangle(vertexindex, vertexindex + width +1, vertexindex + width);
                    meshdata.AddTriangle(vertexindex + width + 1, vertexindex, vertexindex + 1);
                }

                vertexindex++;
            }
        }
        return meshdata;
    }
}
public class MeshData
{
    public Vector3[] vertecies;
    public int[] triangles;

    public Vector2[] UVs;

    int triangleIndex;
    public MeshData(int meshWidth, int meshHeight)
    { 
        vertecies = new Vector3[meshWidth * meshHeight];
        UVs = new Vector2[meshWidth * meshHeight];
        triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];        
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex + 1] = b;
        triangles[triangleIndex + 2] = c;
        triangleIndex += 3;
    }

    public Mesh CreateMesh()
    { 
        Mesh mesh = new Mesh();
        mesh.vertices = vertecies;
        mesh.triangles = triangles;
        mesh.uv = UVs;
        mesh.RecalculateNormals();
        return mesh;
    }
}
