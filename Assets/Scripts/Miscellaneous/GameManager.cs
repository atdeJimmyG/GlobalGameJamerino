using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int numberOfZombies = 10;
    [SerializeField] private GameManager zombiePrefab = null;

    private void Start()
    {
        // Spawn Zombies
        for (int i = 0; i < numberOfZombies; i++)
        {
            Instantiate(zombiePrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
