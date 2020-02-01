using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public PlayerHealth health;
    [SerializeField] private int maxHealth = 50;

    private void Start()
    {
        health = new PlayerHealth(maxHealth);
    }
}
