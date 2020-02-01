using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // The current weapon that the player is using.
    [SerializeField] protected Weapon currentWeapon = null;

    // How long it has been since the player last fired their weapon.
    protected float timeSinceLastFired;

    /// <summary>
    /// Sets up the player's current weapon, assiging its bullet count and magazine count.
    /// </summary>
    protected void Start()
    {
        currentWeapon.Init(currentWeapon.magazineSize, currentWeapon.magazineCount);
    }

    /// <summary>
    /// Retreives the player's fire input and reload input.
    /// Calls the Shoot function in the Weapon.cs script if the player clicks,
    /// and calls the Reload function if the player presses 'R'.
    /// </summary>
    private void Update()
    {
        timeSinceLastFired += Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            currentWeapon.Shoot(this.gameObject, timeSinceLastFired);
            timeSinceLastFired = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.Reload();
        }
    }
}
