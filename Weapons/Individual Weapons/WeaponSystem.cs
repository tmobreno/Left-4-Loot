using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;

    public PlayerControls player;

    public float baseForFiring = 0f; //don't change
    public float fireRate;

    public float weaponDamage;

    private void Start()
    {
        player = FindObjectOfType<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > baseForFiring)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }
    }

    public virtual void Fire()
    {
        GameObject go = Instantiate(projectile, shotPoint.position, transform.rotation);
        go.GetComponent<Projectile>().carriedDamage = weaponDamage + player.upgradeDamage;
        FindObjectOfType<AudioManager>().Play("Fire");
        baseForFiring = Time.time + fireRate;
    }    
}
