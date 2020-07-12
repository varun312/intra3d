using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHEight : MonoBehaviour
{
    public Terrain terrain;

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


    }
}
