using UnityEngine;

public class ZombieAttack : PlayerAttack
{
    private void Update()
    {
        timeSinceLastFired += Time.deltaTime;

        if (timeSinceLastFired >= currentWeapon.fireRate)
        {
            currentWeapon.Shoot(this.gameObject, timeSinceLastFired);
            timeSinceLastFired = 0;
        }
    }
}
