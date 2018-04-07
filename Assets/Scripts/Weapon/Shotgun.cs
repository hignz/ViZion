using System;
using UnityEngine;

public class Shotgun : Weapon {

    public Transform LineRendererPrefab;

    private void Awake()
    {
        //fireRate = 1f;
        type = WeaponType.SingleFire;
    }

    public override void Fire()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePos, (mousePos - firePos), 100);
        Debug.DrawLine(firePos, (mousePos - firePos) * 100, Color.cyan, 4);

        Instantiate(LineRendererPrefab, firePoint.position, firePoint.rotation);
        PlaySoundEffect();
        ammo--;

        if (hit.collider != null)
        {
            Debug.DrawLine(firePos, hit.point, Color.red, 6);
            Debug.Log("I hit " + hit.collider.name);

            if (hit.collider.tag.Equals("Enemy"))
            {
                Debug.Log("Hit enemy: " + hit.collider.tag);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    public override void PlaySoundEffect()
    {
        soundEffect.pitch = UnityEngine.Random.Range(0.96f, 1.05f);
        soundEffect.volume = UnityEngine.Random.Range(0.9f, soundEffect.volume);
        soundEffect.Play();
    }
}
