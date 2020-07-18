using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHEight : MonoBehaviour
{
    public Terrain terrain;
    public Transform parent;

    private void Start()
    {
        terrain = gameObject.GetComponent<Terrain>();
    }
    /*

    private void OnGUI()
    {
        if (GUI.Button(new Rect(30, 30, 200, 30), "Change height")) 
        {
            int xres = terrain.terrainData.heightmapResolution;
            int yres = terrain.terrainData.heightmapResolution;

            float[,] heights = terrain.terrainData.GetHeights(0, 0, xres, yres);


            for (int i = 0; i < 513; i++)
            {
                for (int x = 0; x < 513; x++)
                {
                    heights[i, x] = 0;
                }
            }

            //heights[10, 10] = 1f;
            terrain.terrainData.SetHeights(0,0,heights);

        }


    }*/
    private void OnMouseDown()
    {
        int xres = terrain.terrainData.heightmapResolution;
        int yres = terrain.terrainData.heightmapResolution;

        float[,] heights = terrain.terrainData.GetHeights(0, 0, xres, yres);


        for (int i = 0; i < 513; i++)
        {
            for (int x = 0; x < 513; x++)
            {
                heights[i, x] = 0;
            }
        }

        //heights[10, 10] = 1f;
        terrain.terrainData.SetHeights(0, 0, heights);
        Vector3 rightpos = terrain.GetPosition();
        rightpos = new Vector3(rightpos.x - 10, rightpos.y, rightpos.z); 
        string right = "TerrainGroup_0/" + "Terrain_" + rightpos.ToString();
        GameObject rightobj = GameObject.Find(right);
        Terrain rightterrain = rightobj.GetComponent<Terrain>();
        int rightxres = rightterrain.terrainData.heightmapResolution;
        int rightyres = rightterrain.terrainData.heightmapResolution;

        float[,] rightheights = rightterrain.terrainData.GetHeights(0, 0, rightxres, rightyres);


        for (int i = 0; i < 513; i++)
        {
            rightheights[i, 0] = 0;
        }
        rightterrain.terrainData.SetHeights(0, 0, rightheights);

    }
}
