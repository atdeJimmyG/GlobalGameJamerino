using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{

    public enum AreaTypes
    {
        FIELD,
        CITY,
        FARM
    }

    public GameObject[] CITY_SmallTiles;
    public GameObject[] CITY_LargeTiles;

    public GameObject[] FIELD_SmallTiles;
    public GameObject[] FIELD_LargeTiles;

    public GameObject[] FARM_SmallTiles;
    public GameObject[] FARM_LargeTiles;

    public GameObject WorldContainer;

    public int WorldWidth;
    public int WorldHeight;

    public AreaTypes currentArea;

    void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 150, 100), "Generate World"))
        {
            Debug.Log("Generating World");
            GenerateWorld();
        }
    }

    void GenerateWorld()
    {
        Destroy(GameObject.FindGameObjectWithTag("World"));
        GameObject container = Instantiate(WorldContainer, Vector3.zero, Quaternion.identity);
        for(int i = 0; i < WorldHeight; i++)
        {
            for(int j = 0; j < WorldWidth; j++)
            {
                if (currentArea == AreaTypes.FIELD)
                {
                    GameObject newTile = Instantiate(FIELD_SmallTiles[Random.Range(0,FIELD_SmallTiles.Length)], new Vector3(i, j, 0), Quaternion.identity);
                    newTile.transform.parent = container.transform;
                }
                else if(currentArea == AreaTypes.FARM)
                {
                    
                }
                else if(currentArea == AreaTypes.CITY)
                {
                    
                }
            }
        }
    }
}
