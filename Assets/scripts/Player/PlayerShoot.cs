﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawner;

    private Equipment equip;

    private Gun myCurrentGun;
    private Gun myNextGun;
    private Gun[] myEquipped = new Gun[2];

    public Text ammoUI; // a ref to text onscreen that shows ammo amounts
    public ParticleSystem muzzleFlash;

    // Use this for initialization
    void Start()
    {
        equip = GetComponent<Equipment>();
    }

    // Update is called once per frame
    void Update()
    {
        myEquipped[0] = equip.equipped[0];
        myEquipped[1] = equip.equipped[1];

        myCurrentGun = equip.currentGun;
        myNextGun = equip.nextGun;

        if (myCurrentGun == myEquipped[0])
        {
            myNextGun = myEquipped[1];
        }
        else if (myCurrentGun == myEquipped[1])
        {
            myNextGun = myEquipped[0];
        }

        if (myNextGun != equip.empty)
        {
            ammoUI.text = " ( " + myCurrentGun.currentClip.ToString() + " | " + myCurrentGun.currentAmmo.ToString() + " )   " + myNextGun.currentClip.ToString() + " | " + myNextGun.currentAmmo.ToString();
        } else
        {
            ammoUI.text = " ( " + myCurrentGun.currentClip.ToString() + " | " + myCurrentGun.currentAmmo.ToString() + " ) ";
        }
        

        //Debug.Log("we have out " + myCurrentGun.name + " and " + myNextGun.name + " secondary");
    }

    public void Fire()
    {
        if (myCurrentGun.name == "M7 Carbine")
        {
            if (Input.GetButton("Shoot"))
            {
                Invoke("Fire", .1f);
            }
        }

        if (myCurrentGun.currentClip > 0)
        {
            
            GameObject newbullet = Instantiate(bulletPrefab);
            newbullet.transform.position = bulletSpawner.transform.position;
            newbullet.transform.up = bulletSpawner.transform.forward;
            Vector3 bulletDir = bulletSpawner.transform.forward;
            newbullet.GetComponent<Rigidbody>().AddForce(myCurrentGun.bulletVelocity * bulletDir);
            myCurrentGun.currentClip -= 1;
            muzzleFlash.Play();
        }
    }


    public void Reload()
    {
        if (myCurrentGun.currentAmmo >= (myCurrentGun.maxClip - myCurrentGun.currentClip)) //if my current ammo is bigger than the amount of ammo needed to refill my mag
        {
            myCurrentGun.currentAmmo -= (myCurrentGun.maxClip - myCurrentGun.currentClip); //subtract that amount from my pocket ammo
            myCurrentGun.currentClip += (myCurrentGun.maxClip - myCurrentGun.currentClip); //fill my clip back to max
        }
        else if (myCurrentGun.currentAmmo < (myCurrentGun.maxClip - myCurrentGun.currentClip)) //if my pocket ammo is not enough
        {
            myCurrentGun.currentClip += myCurrentGun.currentAmmo; // put whatever is left in my pcoket into my clip
            myCurrentGun.currentAmmo = 0; //make my pocket ammo = 0
        }
        
    }

}
