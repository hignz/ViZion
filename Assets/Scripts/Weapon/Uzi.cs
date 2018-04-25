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
        GameObject bullet = Instantiate(BulletLine, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(0, 0, Random.Range(-1, 1));

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
        gunShotSFX.pitch = Random.Range(0.94f, 1.05f);
        gunShotSFX.Play();
    }

}
