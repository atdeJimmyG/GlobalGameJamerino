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
        if (currentWeapon.weaponSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = currentWeapon.weaponSprite;
        }
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

        if (currentWeapon.fireType == Weapon.FireType.Single)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (currentWeapon.Shoot(this.gameObject, timeSinceLastFired))
                {
                    timeSinceLastFired = 0;
                    StartCoroutine(MuzzleFlash(transform.GetChild(0).gameObject));
                }
            }
        }
        else if (currentWeapon.fireType == Weapon.FireType.FullAuto)
        {
            if (Input.GetButton("Fire1"))
            {
                if (currentWeapon.Shoot(this.gameObject, timeSinceLastFired))
                {
                    timeSinceLastFired = 0;
                    StartCoroutine(MuzzleFlash(transform.GetChild(0).gameObject));
                }
            }
        }
        else if (currentWeapon.fireType == Weapon.FireType.Melee)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (currentWeapon.Shoot(this.gameObject, timeSinceLastFired))
                {
                    timeSinceLastFired = 0;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.Reload();
        }
    }

    public void EquipWeapon(Weapon wep)
    {
        currentWeapon = wep;
        currentWeapon.Init(currentWeapon.magazineSize, currentWeapon.magazineCount);
        if (currentWeapon.weaponSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = currentWeapon.weaponSprite;
        }
    }

    private IEnumerator MuzzleFlash(GameObject muzzleGO)
    {
        muzzleGO.GetComponent<SpriteRenderer>().sprite = muzzleFlash;
        yield return new WaitForSeconds(0.15f);
        muzzleGO.GetComponent<SpriteRenderer>().sprite = null;
    }
}
