using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponSystem
{
    public float spreadAmount;
    public float bulletAmount;

    public override void Fire()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject go = Instantiate(projectile, shotPoint.position, transform.rotation * Quaternion.Euler(0, 0, Random.Range(-spreadAmount, spreadAmount)));
            go.GetComponent<Projectile>().carriedDamage = weaponDamage + player.upgradeDamage;
            FindObjectOfType<AudioManager>().Play("Fire");
            baseForFiring = Time.time + fireRate;
        }
    }
}
