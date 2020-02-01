using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    public PlayerHealth2 health;

    private void Start()
    {
        health = new PlayerHealth2(maxHealth);
    }
}
