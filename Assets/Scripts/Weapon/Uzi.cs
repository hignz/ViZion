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
        RaycastHit2D hit = Physics2D.Raycast(firePos, mousePos - firePos, 100, whatToHit);
        Debug.DrawLine(firePos, (mousePos - firePos) * 100, Color.cyan, 4);

        //// Show bullet trail
        Instantiate(LineRendererPrefab, firePoint.position, firePoint.rotation);
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
                //Destroy(hit.collider.gameObject);
                GameObject enemy = hit.collider.gameObject;
                enemy.GetComponent<Enemy>().DoDeath();
                break;
            default:
                break;
        }
    }

    public override void PlaySoundEffect()
    {
        soundEffect.pitch = Random.Range(0.95f, 1.05f);
        soundEffect.volume = UnityEngine.Random.Range(0.1f, soundEffect.volume);
        soundEffect.Play();
    }

}
