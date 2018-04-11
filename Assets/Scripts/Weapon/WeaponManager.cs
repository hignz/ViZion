using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;
    public Weapon weaponScript;

    public float lastShotTime = 0;

    public TextMeshProUGUI ammoCount;

    public AudioSource weaponPickupSound;

    void Update()
    {
        lastShotTime += Time.deltaTime;

        if (weaponScript != null && currentWeapon != null && weaponScript.ammo > 0)
        {
            if (weaponScript.type == Weapon.WeaponType.SingleFire)
            {
                if (Input.GetButtonDown("Fire1") && lastShotTime > weaponScript.fireRate)
                {
                    lastShotTime = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        weaponScript.Fire();
                    }

                    weaponScript.Fire();
                    weaponScript.ammo--;
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && lastShotTime > weaponScript.fireRate)
                {
                    lastShotTime = 0;
                    weaponScript.Fire();

                    weaponScript.ammo--;
                }
            }

        }
        else
        {
            // Play empty mag sound or something 
        }

        if (Input.GetButtonUp("DropWeapon"))
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

        weaponPickupSound.Play();
        currentWeapon = pickup;
        weaponScript = pickup.GetComponent<Weapon>();

        currentWeapon.transform.parent = this.transform;
        currentWeapon.transform.localRotation = transform.localRotation;
        currentWeapon.transform.localPosition = new Vector3(0f, 0.02f, 0);
        //currentWeapon.SetActive(true);
        ammoCount.gameObject.SetActive(true);

        GetComponent<SpriteRenderer>().sprite = currentWeapon.GetComponent<SpriteRenderer>().sprite;

        Debug.Log("Picked up: " + currentWeapon);
    }

    void DropWeapon()
    {
        if (currentWeapon == null)
        {
            return;
        }

        Vector3 pos = new Vector3(transform.position.x, transform.position.y);
        currentWeapon.transform.parent = null;
        currentWeapon.transform.position = pos;
        currentWeapon.transform.localScale = new Vector3(1f, 1f, 1);
        currentWeapon.SetActive(true);
        //GameObject weaponDrop = Instantiate<GameObject>(currentWeapon, pos, transform.rotation);
        //Weapon script = weaponDrop.GetComponent<Weapon>();

        //script.ammo = weaponScript.ammo;
        //weaponDrop.name = currentWeapon.name;
        //weaponDrop.SetActive(true);
        ammoCount.gameObject.SetActive(false);

        //Destroy(currentWeapon);
        currentWeapon = null;
        weaponScript = null;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
