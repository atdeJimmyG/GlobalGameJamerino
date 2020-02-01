using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // The current weapon that the player is using.
    [SerializeField] protected Weapon currentWeapon = null;
    [SerializeField] private Sprite muzzleFlash = null;

    // How long it has been since the player last fired their weapon.
    protected float timeSinceLastFired;

    /// <summary>
    /// Sets up the player's current weapon, assiging its bullet count and magazine count.
    /// </summary>
    protected void Start()
    {
        currentWeapon.Init(currentWeapon.magazineSize, currentWeapon.magazineCount);
        GetComponent<SpriteRenderer>().sprite = currentWeapon.weaponSprite;
    }

    /// <summary>
    /// Retreives the player's fire input and reload input.
    /// Calls the Shoot function in the Weapon.cs script if the player clicks,
    /// and calls the Reload function if the player presses 'R'.
    /// </summary>
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1;
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        timeSinceLastFired += Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            if (currentWeapon.Shoot(this.gameObject, timeSinceLastFired))
            {
                timeSinceLastFired = 0;
                StartCoroutine(MuzzleFlash(transform.GetChild(0).gameObject));
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.Reload();
        }
    }

    private IEnumerator MuzzleFlash(GameObject muzzleGO)
    {
        muzzleGO.GetComponent<SpriteRenderer>().sprite = muzzleFlash;
        yield return new WaitForSeconds(0.5f);
        muzzleGO.GetComponent<SpriteRenderer>().sprite = null;
    }
}
