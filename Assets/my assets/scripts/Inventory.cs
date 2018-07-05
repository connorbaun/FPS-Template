using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public class Weapon
    {
        public float damage;
        public float headshotDamage;
        public int clipSize;
        public int pocketSize;


       public Weapon(float dam, float head, int clip, int pocket)
        {
            damage = dam;
            headshotDamage = head;
            clipSize = clip;
            pocketSize = pocket;
        }


    }

    public Weapon pistol = new Weapon(18, 30, 8, 250);
    public Weapon smg = new Weapon(12, 12, 60, 1000);
    public Weapon battleRifle = new Weapon(8, 10, 36, 360);

}
