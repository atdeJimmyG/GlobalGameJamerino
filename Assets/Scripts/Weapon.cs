using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public enum FireType
    {
        Single,
        FullAuto
    }

    public FireType fireType;
    public int fireRate; // Time between firing.
    public int magazineSize; // How many bullets in each magazine.
    public int magazineCount; // How many magazines to start with.
    public int range; // How far the gun can shoot.
    public int damage; // How much damage the weapon does.

    private int currentBulletsInMagazine;
    private int magazinesLeft;
    private int currentTimeBetweenShots;

    private bool CanFire()
    {
        if (currentBulletsInMagazine > 0)
        {
            if (currentTimeBetweenShots < 0)
            {
                return true;
            }
            Debug.Log("You can't fire that fast! Slow down, chuck.");
        }

        Debug.Log("No bullets left in magazine, dumbo.");

        return false;
    }

    public void Shoot(GameObject player)
    {
        if (CanFire())
        {
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, player.transform.forward, range);
            if (hit.collider.gameObject.tag == "Zombie")
            {
                currentBulletsInMagazine--;
                currentTimeBetweenShots = fireRate;
                // Damage zombie.
            }
        }
    }

    private void Reload()
    {
        magazinesLeft--;
        currentBulletsInMagazine = magazineSize;
    }
}