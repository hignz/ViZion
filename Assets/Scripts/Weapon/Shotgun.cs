using UnityEngine;

public class Shotgun : Weapon {

    void Start()
    {
        ammo = 6;
    }

    public override void Fire()
    {
        Debug.Log("Shotgun Pew Pew");
    }
}
