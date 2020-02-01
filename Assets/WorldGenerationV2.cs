using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerationV2 : MonoBehaviour
{

    [Header("WorldTiles")]

    [Space(35)]
    public GameObject[] FIELD_SmallBasicTiles;
    public GameObject[] FIELD_SmallDecorativeTiles;
    public GameObject[] FIELD_SmallFlowerTiles;

    [Space(30)]
    public GameObject[] HOUSES;

    [Space(50)]
    public GameObject WorldContainer;

    public int WorldXbyX;

    private GameObject[,] worldMap;


    [Range(0f, 1f)]
    public float BasicTileChance;
    [Range(0f, 1f)]
    public float DecorativeTileChance;
    [Range(0f, 1f)]
    public float FlowerTileChance;

    public bool useSeed;
    public int seed;
    [Space(50)]


    [Header("House Settings")]
    public int minDistHouses;
    private List<Vector2> existingHouses = new List<Vector2> { };

    [Range(0f,5f)]
    public float townChance;
    [Range(0f, 5f)]
    public float loneHouseChance;

    void Start()
    {
        if (useSeed)
        {
            Random.seed = seed;
        }
    }

#if UNITY_EDITOR
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Generate World"))
        {
            Debug.Log("Generating World");
            worldMap = new GameObject[WorldXbyX,WorldXbyX];
            DestroyCurrentWorld();
            GenerateWorld();
            GenerateBuildings();
            GenerateLoot();
        }
    }
#endif

    void DestroyCurrentWorld()
    {
        existingHouses.Clear();
        GameObject[] world = GameObject.FindGameObjectsWithTag("World");
        foreach(GameObject obj in world)
        {
            DestroyImmediate(obj);
        }
    }

    void GenerateWorld()
    {
        GameObject container = Instantiate(WorldContainer, Vector3.zero, Quaternion.identity);
        container.name = "WorldContainer";
        for (int i = 0; i < WorldXbyX; i++)
        {
            for (int j = 0; j < WorldXbyX; j++)
            {
                GameObject newTile;
                float randomChance = Random.Range(0f, BasicTileChance + DecorativeTileChance + FlowerTileChance);
                if (randomChance <= BasicTileChance)
                {
                    int tileIndex = Random.Range(0, FIELD_SmallBasicTiles.Length);
                    newTile = Instantiate(FIELD_SmallBasicTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                }
                else if(randomChance <= FlowerTileChance + BasicTileChance)
                {
                    int tileIndex = Random.Range(0, FIELD_SmallFlowerTiles.Length);
                    newTile = Instantiate(FIELD_SmallFlowerTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                }
                else
                {
                    int tileIndex = Random.Range(0, FIELD_SmallDecorativeTiles.Length);
                    newTile = Instantiate(FIELD_SmallDecorativeTiles[tileIndex], new Vector3(i, j, 0), Quaternion.identity);
                }
                newTile.transform.parent = container.transform;
                worldMap[i, j] = newTile;
            }
        }
    }

    void GenerateBuildings()
    {
        GameObject houseContainer = Instantiate(WorldContainer, Vector3.zero, Quaternion.identity);
        houseContainer.name = "HouseContainer";

        for (int x = 5; x < WorldXbyX-5; x++)
        {
            float spawnChance = Random.Range(0f, townChance + loneHouseChance + 15);
            float initialY = Random.Range(5, WorldXbyX-5);
            float initialX = x;
            bool spawnHouse = true;
            foreach(Vector2 location in existingHouses)
            {
                if (Vector2.Distance(location, new Vector2(initialX,initialY)) < minDistHouses)
                {
                    spawnHouse = false;
                }
            }
            if (spawnHouse)
            {
                if (spawnChance <= townChance)
                {
                    for(int i = 0; i < Random.Range(0, 12); i++)
                    {
                        int houseIndex = Random.Range(0, HOUSES.Length);
                        GameObject house = Instantiate(HOUSES[houseIndex], new Vector2(initialX, initialY), Quaternion.identity);

                        existingHouses.Add(new Vector2(initialX, initialY));

                        if(Random.Range(0, 2) == 0)
                        {
                            initialX += minDistHouses;
                        }
                        else
                        {
                            initialY += minDistHouses;
                        }

                        foreach (Vector2 location in existingHouses)
                        {
                            if (Vector2.Distance(location, new Vector2(initialX, initialY)) < minDistHouses)
                            {
                                break;
                            }
                        }

                        house.transform.parent = houseContainer.transform;

                        if (initialX > WorldXbyX-5 || initialY > WorldXbyX - 5)
                        {
                            break;
                        }
                    }
                }
                else if (spawnChance <= loneHouseChance)
                {
                    int houseIndex = Random.Range(0, HOUSES.Length);
                    GameObject house = Instantiate(HOUSES[houseIndex], new Vector2(initialX, initialY), Quaternion.identity);
                    existingHouses.Add(new Vector2(initialX, initialY));
                    house.transform.parent = houseContainer.transform;
                }
            } 
        }
    }

    void GenerateLoot()
    {
        GameObject[] lootSpawns = GameObject.FindGameObjectsWithTag("LootSpawn");
    }
}
