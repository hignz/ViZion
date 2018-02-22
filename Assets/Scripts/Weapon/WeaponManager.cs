using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject currentWeapon;
    public Weapon weaponScript;

    void Start()
    {
        //weapon = currentWeapon.GetComponent<Weapon>();
        //GetComponent<SpriteRenderer>().sprite = weapon.sprite;
    }

    public void PickupWeapon(GameObject pickup)
    {
        //pickup = currentWeapon.GetComponent<Weapon>().gameObject;

        currentWeapon = pickup;
        weaponScript = currentWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = currentWeapon.GetComponent<SpriteRenderer>().sprite;

        Debug.Log("Picked up a " + currentWeapon);
    }

    private void Update()
    {
        if (weaponScript != null && currentWeapon != null)
        {
            Debug.Log("in");

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
                Debug.Log("in here");
                DropWeapon();
            }
        }

    }

    public void DropWeapon()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Transform parentTransform = GetComponentInParent<Transform>().transform;
        Vector3 rotation = parentTransform.eulerAngles;

        GameObject weaponDrop = Instantiate<GameObject>(currentWeapon, pos, Quaternion.Euler(rotation));
        weaponDrop.name = currentWeapon.name;
        weaponDrop.SetActive(true);

        Destroy(currentWeapon);
        currentWeapon = null;
        weaponScript = null;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
