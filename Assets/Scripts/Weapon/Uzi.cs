using UnityEngine;

public class Uzi : Weapon {

    void Start()
    {
        ammo = 26;
    }

    public override void Fire()
    {
        Debug.Log("Uzi Pew Pew");
    }
}
