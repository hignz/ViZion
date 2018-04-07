using UnityEngine;

public class Uzi : Weapon
{
    public Transform LineRendererPrefab;

    private void Awake()
    {
        //fireRate = 0.2f;
        type = WeaponType.AutoFire;
    }

    public override void Fire()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePos, mousePos - firePos, 100, notToHit);
        Debug.DrawLine(firePos, (mousePos - firePos) * 100, Color.cyan, 4);

        //// Show bullet trail
        Instantiate(LineRendererPrefab, firePoint.position, firePoint.rotation);
        PlaySoundEffect();
        ammo--;

        if (hit.collider != null)
        {
            Debug.DrawLine(firePos, hit.point, Color.red, 6);
            Debug.Log("I hit " + hit.collider.name);
        }
    }

    public override void PlaySoundEffect()
    {
        soundEffect.pitch = Random.Range(0.95f, 1.05f);
        soundEffect.Play();
    }

}
