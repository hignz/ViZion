using UnityEngine;

public class Pistol : Weapon {

    void Start()
    {
        ammo = 16;
    }

    public override void Fire()
    {
        Debug.Log("Pistol Pew Pew");
    }
}
