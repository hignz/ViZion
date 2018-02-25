using UnityEngine;

public class Weapon : MonoBehaviour {

    public enum Type
    {
        SingleFire = 0,
        AutoFire = 1,
        Spread = 2
    }

    [SerializeField]
    private GameObject bullet;

    public int damage, ammo, fireRate, type;

    public Transform firePoint;

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

}
