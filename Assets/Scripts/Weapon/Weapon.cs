using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        SingleFire = 0,
        AutoFire = 1,
        Spread = 2
    }

    public int damage, ammo;

    public float fireRate = 0;

    public Transform firePoint;

    public WeaponType type;

    public LayerMask whatToHit;

    public AudioSource soundEffect;

    void Awake()
    {
        firePoint = transform.Find("Firepoint");

        if (firePoint == null)
        {
            Debug.LogError("Firepoint missing!");
        }
    }

    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
    }

    public virtual void Fire() { }

    public virtual void PlaySoundEffect() { }

}
