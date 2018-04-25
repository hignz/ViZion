using UnityEngine;

public class Uzi : Weapon
{
    public GameObject BulletLine;

    private void Awake()
    {
        //fireRate = 0.2f;
        type = WeaponType.AutoFire;
    }

    public override void Fire()
    {
        //Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);
        //RaycastHit2D hit = Physics2D.Raycast(firePos, mousePos - firePos, 100, whatToHit);
        //Debug.DrawLine(firePos, (mousePos - firePos) * 100, Color.cyan, 4);

        ////// Show bullet trail
        //Instantiate(BulletLine, firePoint.position, firePoint.rotation);
        //PlaySoundEffect();

        //if (hit.collider != null)
        //{
        //    Debug.DrawLine(firePos, hit.point, Color.red, 6);
        //    Debug.Log("I hit " + hit.collider.name);

        //    CheckHit(hit);

        GameObject bullet = Instantiate(BulletLine, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(0, 0, Random.Range(-1, 1));

        PlaySoundEffect();

        //}
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
        gunShotSFX.pitch = Random.Range(0.94f, 1.05f);
        gunShotSFX.Play();
    }

}
