using UnityEngine;

public class Uzi : Weapon
{
    public Transform LineRendererPrefab;

    private void Awake()
    {
        
        type = WeaponType.AutoFire;
    }

    public override void Fire()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(firePoint.localPosition.x, firePoint.localPosition.y);
        RaycastHit2D hit = Physics2D.Raycast(firePos, mousePos - firePos, 100);
        Debug.DrawLine(firePos, (mousePos - firePos) * 100, Color.cyan);

        PlaySoundEffect();
        //// Show bullet trail
        Instantiate(LineRendererPrefab, firePoint.position, firePoint.rotation);
        ammo--;

        if (hit.collider != null)
        {
            Debug.DrawLine(firePos, hit.point, Color.red);
            Debug.Log("I hit " + hit.collider.name);
        }
    }

    public override void PlaySoundEffect()
    {
        soundEffect.pitch = Random.Range(0.95f, 1.05f);
        soundEffect.Play();
    }

}
