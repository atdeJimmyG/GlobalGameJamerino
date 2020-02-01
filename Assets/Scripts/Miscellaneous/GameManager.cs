using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int numberOfZombies = 10;
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject zombiePrefab = null;
    [SerializeField] private Transform playerSpawn = null;
    [SerializeField] private Transform zombieSpawn = null;

    private void Start()
    {
        // Spawn Player
        Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
        // Spawn Zombies
        for (int i = 0; i < numberOfZombies; i++)
        {
            Instantiate(zombiePrefab, zombieSpawn.position, Quaternion.identity);
        }
    }
}
