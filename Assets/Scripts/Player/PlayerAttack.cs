using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // The current weapon that the player is using.
    [SerializeField] protected Weapon currentWeapon = null;
    [SerializeField] private GameObject muzzleFlash = null;

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
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos -= transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        timeSinceLastFired += Time.deltaTime;

        if (currentWeapon.fireType == Weapon.FireType.Single)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (currentWeapon.Shoot(this.gameObject, timeSinceLastFired))
                {
                    timeSinceLastFired = 0;
                    StartCoroutine(MuzzleFlash());
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
                    StartCoroutine(MuzzleFlash());
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
    private IEnumerator MuzzleFlash()
    {
        if (muzzleFlash == null) { yield return null; }

        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        muzzleFlash.SetActive(false);
    }
}
