using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    public int ammo, fireRate;

    public virtual void Fire()
    {
        Debug.Log("Weapon Pew Pew");
    }

}
