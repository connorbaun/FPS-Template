using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {
    //this is the currently equipped weapons. maybe an array with 2 spaces?
    
    public List<Gun> theGuns = new List<Gun>(); //a new list of all weapons in the game. we will create instances of weapons below

    public Gun pistol = new Gun("Magnum", 8, 60, 8, 60, 20, 50, 30000); //new weapon
    public Gun smg = new Gun("M7 Carbine",  60, 300, 60, 240, 8, 8, 20000); //new weapon
    public Gun br = new Gun("BHR55 Battle Rifle",   36, 200, 36, 360, 4, 7, 30000); //new weapon
    public Gun empty = new Gun("Empty", 0, 0, 0, 0, 0, 0, 0);

    public Gun currentGun; //the gun that is onscreen right this instant
    public Gun nextGun; //the gun that we will cycle to if the cycle button is pressed

    public Gun[] equipped = new Gun[2]; //equipment refers to the guns we have equipped
    public int gunIndex = 0; //keeps track of which gun we are currently on; 0 or 1?


    // Use this for initialization
    void Start ()
    {
        theGuns.Add(pistol); //adds the newly-created gun to the list of all guns in the game
        theGuns.Add(smg); //adds the newly-created gun to the list of all guns in the game
        theGuns.Add(br); //adds the newly-created gun to the list of all guns in the game

        SetStartingEquipment(); //allows us to set starting equipment (which weapons will we spawn with?)
        
    }

    // Update is called once per frame
    void Update ()
    {
        ManageEquipment(); //every frame, makes sure that we are tracking which weapon is current and which is next
        //Debug.Log("Primary: " + currentGun.name + " || Secondary: " + nextGun.name);
    }

    public void CycleEquipment()
    {
        if (nextGun != empty)
        {
            if (gunIndex == 0)
            {
                gunIndex = 1;
            }
            else if (gunIndex == 1)
            {
                gunIndex = 0;
            }
        }
        
    }

    private void ManageEquipment()
    {
        if (gunIndex == 0)
        {
            currentGun = equipped[0];
            nextGun = equipped[1];
        }
        else if (gunIndex == 1)
        {
            currentGun = equipped[1];
            nextGun = equipped[0];
        }

    }

    private void SetStartingEquipment()
    {
        equipped[0] = pistol; //sets our currentGun
        equipped[1] = smg; //sets our nextGun

        currentGun = equipped[gunIndex]; //makes sure current gun starts as 0
    }
}
