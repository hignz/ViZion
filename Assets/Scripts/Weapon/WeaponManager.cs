using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;
    public Weapon weaponScript;

    public void PickupWeapon(GameObject pickup)
    {
        if (currentWeapon != null)
        {
            DropWeapon();
        }

        currentWeapon = pickup;
        currentWeapon.transform.parent = this.transform.parent;
        currentWeapon.transform.localRotation = transform.localRotation;
        weaponScript = currentWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = currentWeapon.GetComponent<SpriteRenderer>().sprite;

        Debug.Log("Picked up a " + currentWeapon);
    }

    void Update()
    {
        if (weaponScript != null && currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (weaponScript.ammo > 0)
                {
                    weaponScript.Fire();
                    weaponScript.ammo--;
                }
                else
                {
                    // Play empty mag sound effect or something
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                DropWeapon();
            }
        }
    }

    void DropWeapon()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y);

        GameObject weaponDrop = Instantiate<GameObject>(currentWeapon, pos, transform.rotation);
        weaponDrop.name = currentWeapon.name;
        weaponDrop.SetActive(true);

        Destroy(currentWeapon);
        currentWeapon = null;
        weaponScript = null;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
