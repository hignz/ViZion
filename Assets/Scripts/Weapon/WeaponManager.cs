using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;
    public Weapon weaponScript;

    public float lastShotTime = 0;

    public TextMeshProUGUI ammoCount;

    void Update()
    {
        lastShotTime += Time.deltaTime;

        if (weaponScript != null && currentWeapon != null && weaponScript.ammo > 0)
        {
            if (weaponScript.type == Weapon.WeaponType.SingleFire)
            {
                if (Input.GetButtonDown("Fire1") && lastShotTime > weaponScript.timeToFire)
                {
                    lastShotTime = 0;
                    weaponScript.Fire();
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && lastShotTime > weaponScript.timeToFire)
                {
                    lastShotTime = 0;
                    weaponScript.Fire();
                }
            }

        }
        else
        {
            // Play empty mag sound or something 
        }

        if (Input.GetButtonUp("Fire2"))
        {
            DropWeapon();
        }
    }

    private void LateUpdate()
    {
        if (ammoCount.IsActive())
        {
            ammoCount.text = "" + weaponScript.ammo;
        }
    }

    public void PickupWeapon(GameObject pickup)
    {
        if (currentWeapon != null)
        {
            DropWeapon();
        }

        currentWeapon = pickup;
        weaponScript = pickup.GetComponent<Weapon>();

        currentWeapon.transform.parent = this.transform;
        currentWeapon.transform.localRotation = transform.localRotation;
        currentWeapon.transform.localPosition = new Vector3(0f, 0.02f, 0);
        ammoCount.gameObject.SetActive(true);

        GetComponent<SpriteRenderer>().sprite = currentWeapon.GetComponent<SpriteRenderer>().sprite;

        Debug.Log("Picked up a " + currentWeapon);
    }

    void DropWeapon()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y);

        GameObject weaponDrop = Instantiate<GameObject>(currentWeapon, pos, transform.rotation);
        Weapon script = weaponDrop.GetComponent<Weapon>();

        script.ammo = weaponScript.ammo;
        weaponDrop.name = currentWeapon.name;
        weaponDrop.transform.localScale = new Vector3(1f, 1f, 1);
        weaponDrop.SetActive(true);
        ammoCount.gameObject.SetActive(false);

        Destroy(currentWeapon);
        currentWeapon = null;
        weaponScript = null;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
