using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon {

    public override void Fire()
    {
        Debug.Log("Uzi Pew Pew");
        ammo += 1;
    }
}
