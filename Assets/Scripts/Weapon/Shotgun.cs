using System;
using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject BulletLine;
    public float bulletSpread;

    private void Awake()
    {
        //fireRate = 1f;
        //type = WeaponType.Spread;
    }

    public void Start()
    {
        //AudioSource[] audios = GetComponents<AudioSource>();

        //gunShotSFX = audios[0];
        //reloadSFX = audios[1];
    }

    public override void Fire()
    {
        var spread = UnityEngine.Random.Range(-10f, 10f);

        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePos, (mousePos - firePos), 100, whatToHit);
        Debug.DrawLine(firePos, (mousePos - firePos) * 100, Color.cyan, 4);

        GameObject bullet = (GameObject)GameObject.Instantiate(BulletLine, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(0, 0, UnityEngine.Random.Range(-10, 10));

        PlaySoundEffect();

        if (hit.collider != null)
        {
            Debug.DrawLine(firePos, hit.point, Color.red, 6);
            Debug.Log("I hit " + hit.collider.name);

            CheckHit(hit);
        }
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
