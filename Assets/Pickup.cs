using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public int clipAmmo;
    public int pocketAmmo;
    public int type = 0;

	// Use this for initialization
	void Start ()
    {
        type = 2; //battlerifle corresponds to type 2
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
