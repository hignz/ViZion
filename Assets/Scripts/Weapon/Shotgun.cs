using System;
using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject BulletLine;
    public float bulletSpreadMax = 10;

    public override void Fire()
    {
        var spread = UnityEngine.Random.Range(-bulletSpreadMax, bulletSpreadMax);

        GameObject bullet = Instantiate(BulletLine, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(0, 0, UnityEngine.Random.Range(-10, 10));

        PlaySoundEffect();
    }

    public override void PlaySoundEffect()
    {
        gunShotSFX.pitch = UnityEngine.Random.Range(0.96f, 1.05f);
        gunShotSFX.Play();
    }
}
