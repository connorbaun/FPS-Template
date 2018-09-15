using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {
    //this is the currently equipped weapons. maybe an array with 2 spaces?
    public List<Gun> theGuns = new List<Gun>();
    public Gun pistol = new Gun("pistol", 8, 60, 20, 50, 2000);
    public Gun smg = new Gun("smg", 60, 240, 8, 8, 1000);
    public Gun br = new Gun("battlerifle", 36, 360, 4, 7, 5000);

    public Gun[] equipment = new Gun[2];

    // Use this for initialization
    void Start ()
    {
        theGuns.Add(pistol);
        theGuns.Add(smg);
        theGuns.Add(br);

        equipment[0] = pistol;
        equipment[1] = smg;

        Debug.Log(equipment[0].name);
        Debug.Log("secondary weap is " + equipment[1].name);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
