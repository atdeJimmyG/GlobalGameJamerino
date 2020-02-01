using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    public PlayerHealth health;

    private void Start()
    {
        health = new PlayerHealth(maxHealth);
    }
}
