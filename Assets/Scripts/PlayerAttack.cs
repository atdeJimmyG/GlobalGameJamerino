using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon currentWeapon;
    private float timeSinceLastFired;

    private void Start()
    {
        currentWeapon.Init(currentWeapon.magazineSize, currentWeapon.magazineCount);
    }

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
