using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public enum FireType
    {
        Single,
        FullAuto,
        Melee
    }

    public FireType fireType = FireType.Single;
    public float fireRate = 1f; // Time between firing.
    public int magazineSize = 30; // How many bullets in each magazine.
    public int magazineCount = 3; // How many magazines to start with.
    public int range = 10; // How far the gun can shoot.
    public int damage = 10; // How much damage the weapon does.
    public string tagMask = "Zombie"; // Which tag the player can hit.
    public Sprite weaponSprite = null;

    private int currentBulletsInMagazine = 0;
    private int magazinesLeft = 0;

    public void Init(int bullets, int mags)
    {
        currentBulletsInMagazine = bullets;
        magazinesLeft = mags;
    }

    /// <summary>
    /// Called by the Shoot function to check whether the weapon can be fired.
    /// </summary>
    /// <returns>True if the weapon can be fire, false if it cannot.</returns>
    private bool CanFire(float time)
    {
        if (time >= fireRate)
        {
            if (fireType == FireType.Melee)
            {
                return true;
            }

            if (currentBulletsInMagazine > 0)
            {
                return true;
            }

            Debug.Log("No bullets left in magazine, dumbo.");
            return false;
        }

        Debug.Log("You can't fire that fast! Slow down, chuck.");
        return false;
    }

    /// <summary>
    /// Called by the player controller to fire the weapon.
    /// If the weapon hits a collider with the tag 'Zombie', within the weapon's
    /// range then the zombie will take damage.
    /// </summary>
    /// <param name="player"></param>
    /// <returns>True if the player shoot, false if they didn't.</returns>
    public bool Shoot(GameObject owner, float timeSinceFired)
    {
        if (CanFire(timeSinceFired))
        {
            Debug.Log("Shoot");
            
            if (fireType != FireType.Melee)
            {
                currentBulletsInMagazine--;
            }

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(owner.transform.position, mousePos, range);
            if (hit.collider != null)
            {
                GameObject player = hit.collider.gameObject;
                if (player.tag == tagMask)
                {
                    if (player.GetComponent<ZombieController>() != null)
                    { // The player hit a zombie.
                        player.GetComponent<ZombieController>().health.TakeDamage(damage);
                        Debug.Log("Hit zombie");
                        if (player.GetComponent<ZombieController>().health.currentHealth <= 0)
                        {
                            Destroy(player);
                        }
                    }
                    else // A zombie hit the player.
                    {
                        player.GetComponent<PlayerController>().health.TakeDamage(damage);
                        Debug.Log("Hit player");
                        if (player.GetComponent<PlayerController>().health.currentHealth <= 0)
                        {
                            Destroy(player);
                        }
                    }
                }
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Called by the player controller to reload the player's current weapon.
    /// </summary>
    public void Reload()
    {
        if (fireType != FireType.Melee)
        {
            if (magazinesLeft > 0)
            {
                Debug.Log("Reloading");
                magazinesLeft--;
                currentBulletsInMagazine = magazineSize;
            }
            Debug.Log("You're out of magazines.");
        }
    }
}