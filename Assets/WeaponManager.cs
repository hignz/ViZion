using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public GameObject currentWeapon, droppedWeapon;
    public Weapon weapon;

	void Start () {
        weapon = currentWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
	}

    public void PickupWeapon(GameObject pickup)
    {
        currentWeapon = pickup;
        pickup = currentWeapon.GetComponent<Weapon>().gameObject;
        GetComponent<SpriteRenderer>().sprite = pickup.GetComponent<SpriteRenderer>().sprite;
    }

    public void DropWeapon()
    {
        currentWeapon = null;
    }
}
