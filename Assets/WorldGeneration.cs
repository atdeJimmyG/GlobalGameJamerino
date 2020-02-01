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

    [Header("WorldTiles")]
    public GameObject[] CITY_SmallBasicTiles;
    public GameObject[] CITY_SmallDecorativeTiles;
    /*public GameObject[] CITY_SmallBuildingTiles;
    public int[] CITY_BuildingXSize;
    public int[] CITY_BuildingYSize;
    public GameObject[] CITY_LargeBasicTiles;
    public GameObject[] CITY_LargeDecorativeTiles;
    public GameObject[] CITY_LargeBuildingTiles;*/

    [Space(35)]
    public GameObject[] FIELD_SmallBasicTiles;
    public GameObject[] FIELD_SmallDecorativeTiles;
    /*public GameObject[] FIELD_SmallBuildingTiles;
    public int[] FIELD_BuildingXSize;
    public int[] FIELD_BuildingYSize;
    public GameObject[] FIELD_LargeBasicTiles;
    public GameObject[] FIELD_LargeDecorativeTiles;
    public GameObject[] FIELD_LargeBuildingTiles;*/

    [Space(35)]
    public GameObject[] FARM_SmallBasicTiles;
    public GameObject[] FARM_SmallDecorativeTiles;
    /*public GameObject[] FARM_SmallBuildingTiles;
    public int[] FARM_BuildingXSize;
    public int[] FARM_BuildingYSize;
    public GameObject[] FARM_LargeBasicTiles;
    public GameObject[] FARM_LargeDecorativeTiles;
    public GameObject[] FARM_LargeBuildingTiles;*/

    [Space(50)]
    public GameObject WorldContainer;

    public int CellXbyX;
    public int AreaXbyX;

    private GameObject[][,] worldMap;
    private GameObject[,] areaMap;

    
    [Range(0f, 1f)]
    public float BasicTileChance;
    [Range(0f, 1f)]
    public float DecorativeTileChance;
    /*[Range(0f, 1f)]
    public float BuildingTileChance;*/

    public AreaTypes currentArea;


    public int seed;

    void Start()
    {
        Random.seed = seed;
    }

#if UNITY_EDITOR
    void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 150, 100), "Generate World"))
        {
            Debug.Log("Generating World");
            areaMap = new GameObject[CellXbyX,CellXbyX];
            worldMap = new GameObject[(int)Mathf.Pow(AreaXbyX,2)][,];
            DestroyCurrentWorld();
            GenerateWorld();
        }
    }
#endif

    void DestroyCurrentWorld()
    {
        GameObject[] world = GameObject.FindGameObjectsWithTag("World");
        for (int i = 0; i < world.Length; i++)
        {
            DestroyImmediate(world[i]);
        }
    }

    void GenerateWorld()
    {
        for (int totalAreas = 0; totalAreas < Mathf.Pow(AreaXbyX,2); totalAreas++)
        {
            GameObject container = Instantiate(WorldContainer, Vector3.zero, Quaternion.identity);
            container.name = "WorldContainer" + totalAreas;
            int areaType = Random.Range(0, System.Enum.GetNames(typeof(AreaTypes)).Length);
            if (areaType == 0)
            {
                currentArea = AreaTypes.FIELD;
            }
            else if(areaType == 1)
            {
                currentArea = AreaTypes.FIELD;
            }
            else
            {
                currentArea = AreaTypes.FIELD;
                //currentArea = AreaTypes.CITY;
            }
            for (int i = 0; i < CellXbyX; i++)
            {
                for (int j = 0; j < CellXbyX; j++)
                {
                    if (currentArea == AreaTypes.FIELD)
                    {
                        GameObject newTile;
                        float randomChance = Random.Range(0f, BasicTileChance + DecorativeTileChance); //+ BuildingTileChance);
                        if (randomChance <= BasicTileChance)
                        {
                            int tileIndex = Random.Range(0, FIELD_SmallBasicTiles.Length);
                            newTile = Instantiate(FIELD_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                        }
                        else if (randomChance <= DecorativeTileChance + BasicTileChance)
                        {
                            int tileIndex = Random.Range(0, FIELD_SmallDecorativeTiles.Length);
                            newTile = Instantiate(FIELD_SmallDecorativeTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                        }
                        else
                        {
                            int tileIndex = Random.Range(0, FIELD_SmallBasicTiles.Length);
                            newTile = Instantiate(FIELD_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            /*int tileIndex = Random.Range(0, FIELD_SmallBuildingTiles.Length);
                            if (i-(FIELD_BuildingXSize[tileIndex]/2) > 0 && j-(FIELD_BuildingYSize[tileIndex]/2) > 0 && i + (FIELD_BuildingXSize[tileIndex] / 2) < CellXbyX && j - (FIELD_BuildingYSize[tileIndex] / 2) < CellXbyX)
                            {
                                newTile = Instantiate(FIELD_SmallBuildingTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            }
                            else
                            {
                                tileIndex = Random.Range(0, FIELD_SmallBasicTiles.Length);
                                newTile = Instantiate(FIELD_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            }*/
                        }
                        newTile.transform.parent = container.transform;
                        areaMap[i, j] = newTile;
                    }
                    else if (currentArea == AreaTypes.FARM)
                    {
                        GameObject newTile;
                        float randomChance = Random.Range(0f, BasicTileChance + DecorativeTileChance); //+ BuildingTileChance);
                        if (randomChance <= BasicTileChance)
                        {
                            int tileIndex = Random.Range(0, FARM_SmallBasicTiles.Length);
                            newTile = Instantiate(FARM_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                        }
                        else if (randomChance <= DecorativeTileChance + BasicTileChance)
                        {
                            int tileIndex = Random.Range(0, FARM_SmallDecorativeTiles.Length);
                            newTile = Instantiate(FARM_SmallDecorativeTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                        }
                        else
                        {
                            int tileIndex = Random.Range(0, FARM_SmallBasicTiles.Length);
                            newTile = Instantiate(FIELD_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            /*int tileIndex = Random.Range(0, FARM_SmallBuildingTiles.Length);
                            if (i - (FARM_BuildingXSize[tileIndex] / 2) > 0 && j - (FARM_BuildingYSize[tileIndex] / 2) > 0 && i + (FARM_BuildingXSize[tileIndex] / 2) < CellXbyX && j - (FARM_BuildingYSize[tileIndex] / 2) < CellXbyX)
                            {
                                newTile = Instantiate(FARM_SmallBuildingTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            }
                            else
                            {
                                tileIndex = Random.Range(0, FARM_SmallBasicTiles.Length);
                                newTile = Instantiate(FARM_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            }*/
                        }
                        newTile.transform.parent = container.transform;
                        areaMap[i, j] = newTile;
                    }
                    else if (currentArea == AreaTypes.CITY)
                    {
                        GameObject newTile;
                        float randomChance = Random.Range(0f, BasicTileChance + DecorativeTileChance); // + BuildingTileChance);
                        if (randomChance <= BasicTileChance)
                        {
                            int tileIndex = Random.Range(0, CITY_SmallBasicTiles.Length);
                            newTile = Instantiate(CITY_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                        }
                        else if (randomChance <= DecorativeTileChance + BasicTileChance)
                        {
                            int tileIndex = Random.Range(0, CITY_SmallDecorativeTiles.Length);
                            newTile = Instantiate(CITY_SmallDecorativeTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                        }
                        else
                        {
                            int tileIndex = Random.Range(0, CITY_SmallBasicTiles.Length);
                            newTile = Instantiate(CITY_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            /*int tileIndex = Random.Range(0, CITY_SmallBuildingTiles.Length);
                            if (i - (CITY_BuildingXSize[tileIndex] / 2) > 0 && j - (CITY_BuildingYSize[tileIndex] / 2) > 0 && i + (CITY_BuildingXSize[tileIndex] / 2) < CellXbyX && j - (CITY_BuildingYSize[tileIndex] / 2) < CellXbyX)
                            {
                                newTile = Instantiate(CITY_SmallBuildingTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            }
                            else
                            {
                                tileIndex = Random.Range(0, CITY_SmallBasicTiles.Length);
                                newTile = Instantiate(CITY_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                            }*/
                        }
                        newTile.transform.parent = container.transform;
                        areaMap[i, j] = newTile;
                    }
                    //Debug.Log("Tile Complete: " + (j * i));
                }
            }
            worldMap[totalAreas] = areaMap;
            //Debug.Log("Area Complete: " + (totalAreas + 1));
        }
        GameObject[] containers = GameObject.FindGameObjectsWithTag("World");
        int containerNum = 0;
        for (int x = 0; x < AreaXbyX; x++)
        {
            for (int y = 0; y < AreaXbyX; y++)
            {
                containers[containerNum].transform.position = new Vector2(x * CellXbyX, y * CellXbyX);
                containerNum++;
            }
        }
        foreach(GameObject[,] item in worldMap)
        {
            foreach(GameObject i in item)
            {
                Debug.Log(i.name);
            }
        }
    }
}
