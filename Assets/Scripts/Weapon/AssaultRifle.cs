using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    public GameObject BulletLine;

    private void Awake()
    {
        type = WeaponType.SingleFire;
    }

    public override void Fire()
    {
        GameObject bullet = Instantiate(BulletLine, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(0, 0, Random.Range(-1, 1));

        PlaySoundEffect();
    }

    public override void PlaySoundEffect()
    {
        gunShotSFX.pitch = Random.Range(0.94f, 1.05f);
        gunShotSFX.Play();
    }
}
