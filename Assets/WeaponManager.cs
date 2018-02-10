using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public GameObject currentWeapon;
    public Weapon weapon;

	void Start () {
        weapon = currentWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
	}

    public void PickupWeapon(GameObject weapon)
    {
        currentWeapon = weapon;
        weapon = currentWeapon.GetComponent<Weapon>().gameObject;
        GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;
    }
}
