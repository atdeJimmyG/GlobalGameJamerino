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

    public FireType fireType;
    public float fireRate; // Time between firing.
    public int magazineSize; // How many bullets in each magazine.
    public int magazineCount; // How many magazines to start with.
    public int range; // How far the gun can shoot.
    public int damage; // How much damage the weapon does.

    private int currentBulletsInMagazine = 0;
    private int magazinesLeft = 0;

    public void Init(int bullets, int mags)
    {
        Debug.Log("Weapon is setup");
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

        Debug.LogFormat("You can't fire that fast! Slow down, chuck. You can fire again in {0} seconds", fireRate - time);
        return false;
    }

    /// <summary>
    /// Called by the player controller to fire the weapon.
    /// If the weapon hits a collider with the tag 'Zombie', within the weapon's
    /// range then the zombie will take damage.
    /// </summary>
    /// <param name="player"></param>
    public void Shoot(GameObject player, float timeSinceFired)
    {
        if (CanFire(timeSinceFired))
        {
            Debug.Log("Shoot");
            if (fireType != FireType.Melee)
            {
                currentBulletsInMagazine--;
            }

            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, player.transform.right, range);
            Debug.DrawRay(player.transform.position, player.transform.right, Color.black);
            if (hit.collider != null)
            {
                GameObject zombie = hit.collider.gameObject;
                if (zombie.tag == "Zombie")
                {
                    zombie.GetComponent<ZombieController>().health.Damage(damage);
                    Debug.Log("Hit zombie");
                    if (zombie.GetComponent<ZombieController>().health.currentHealth <= 0)
                    {
                        Destroy(zombie);
                    }
                }
            }
        }
    }


    /// <summary>
    /// Called by the player controller to reload the player's current weapon.
    /// </summary>
    public void Reload()
    {
        if (fireType != FireType.Melee)
        {
            Debug.Log("Reloading");
            magazinesLeft--;
            currentBulletsInMagazine = magazineSize;
        }
    }
}