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

    public float timeToFire = 0;

    public Transform firePoint;

    public WeaponType type;

    public LayerMask notToHit;

    public AudioSource soundEffect;

    void Awake()
    {
        firePoint = transform.Find("Firepoint");

        if (firePoint == null)
        {
            Debug.LogError("Firepoint missing!");
        }
    }

    public virtual void Fire()
    {
        Debug.Log("Weapon Pew Pew");
    }

    public virtual void PlaySoundEffect()
    {
        
    }

}
