using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public GameObject currentWeapon, droppedWeapon;
    public Weapon weapon;

	void Start () {
        //weapon = currentWeapon.GetComponent<Weapon>();
        //GetComponent<SpriteRenderer>().sprite = weapon.sprite;
	}

    public void PickupWeapon(GameObject pickup)
    {
        currentWeapon = pickup;
        //pickup = currentWeapon.GetComponent<Weapon>().gameObject;
        weapon = currentWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = currentWeapon.GetComponent<SpriteRenderer>().sprite;
    }

    private void Update()
    {
        if(weapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (weapon.ammo > 0)
                {
                    weapon.Fire();
                }
                else
                {
                    // Play no bullets SFX
                }            
            }
        }
              
    }

    public void DropWeapon()
    {
        droppedWeapon = currentWeapon;
        currentWeapon = null;
    }
}
