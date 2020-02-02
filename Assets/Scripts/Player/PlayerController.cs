using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerHealth health;
    [SerializeField] private int maxHealth = 100;

    private void Start()
    {
        health = new PlayerHealth(maxHealth);
    }
}
