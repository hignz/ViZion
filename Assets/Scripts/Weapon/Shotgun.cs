using System;
using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject BulletLine;
    public float bulletSpread;

    public override void Fire()
    {
        var spread = UnityEngine.Random.Range(-10f, 10f);

        GameObject bullet = (GameObject)GameObject.Instantiate(BulletLine, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(0, 0, UnityEngine.Random.Range(-10, 10));

        PlaySoundEffect();
    }

    void CheckHit(RaycastHit2D hit)
    {
        string tag = hit.collider.tag;

        switch (tag)
        {
            case "Enemy":
                Debug.Log("Hit enemy: " + hit.collider.tag);

                hit.collider.gameObject.GetComponent<Enemy>().Die();

                FindObjectOfType<LevelManager>().RemoveEnemy();
                break;
            default:
                break;
        }
    }

    public override void PlaySoundEffect()
    {
        gunShotSFX.pitch = UnityEngine.Random.Range(0.96f, 1.05f);
        gunShotSFX.Play();
    }
}
