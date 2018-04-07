using System;
using UnityEngine;

public class Shotgun : Weapon {

    public Transform LineRendererPrefab;

    private void Awake()
    {
        
        type = WeaponType.SingleFire;
    }

    public override void Fire()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePos, (mousePos - firePos), 100);

        PlaySoundEffect();

        Instantiate(LineRendererPrefab, firePoint.position, firePoint.rotation);

        ammo--;

        Debug.DrawLine(firePos, (mousePos - firePos), Color.cyan);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePos, hit.point, Color.red);
            Debug.Log("I hit " + hit.collider.name);

            if (hit.collider.tag.Equals("Enemy"))
            {
                Debug.Log("Hit enemy: " + hit.collider.tag);
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
