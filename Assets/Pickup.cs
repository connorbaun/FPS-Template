﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public int clipAmmo;
    public int pocketAmmo;
    public string gunName = null;
    [SerializeField]
    public Gun gunType;
    //public Equipment allEquip;

    // Use this for initialization
    void Start ()
    {


	}
	

    public void RemoveFromMap()
    {
        Destroy(gameObject);
    }
}
