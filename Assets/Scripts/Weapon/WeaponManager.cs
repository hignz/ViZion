using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;
    public Weapon weaponScript;

    private float lastShotTime = 0;

    public TextMeshProUGUI ammoCountUI;

    public AudioSource weaponPickupSound;

    public AudioSource emptyClipSFX;

    void Update()
    {
        lastShotTime += Time.deltaTime;

        if (weaponScript != null && currentWeapon != null)
        {
            if (Input.GetButtonDown("Fire1") && weaponScript.type == Weapon.WeaponType.Spread && lastShotTime > weaponScript.fireRate)
            {
                //if (Input.GetButtonDown("Fire1") && lastShotTime > weaponScript.fireRate)
                //{
                if (weaponScript.ammo <= 0)
                {
                    emptyClipSFX.Play();
                    return;
                }

                lastShotTime = 0;

                for (int i = 0; i < 4; i++)
                {
                    weaponScript.Fire();
                }

                weaponScript.ammo--;
                // }
            }
            else if (Input.GetButton("Fire1") && weaponScript.type == Weapon.WeaponType.AutoFire && lastShotTime > weaponScript.fireRate)
            {
                //if (Input.GetButton("Fire1") && lastShotTime > weaponScript.fireRate)
                //{
                lastShotTime = 0;
                weaponScript.Fire();

                weaponScript.ammo--;
                // }
            }

        }
        else if (weaponScript.ammo <= 0)
        {
            //emptyClipSFX.Play();
        }

        if (Input.GetButtonUp("DropWeapon"))
        {
            DropWeapon();
        }
    }

    private void LateUpdate()
    {
        if (ammoCountUI.IsActive())
        {
            ammoCountUI.text = "" + weaponScript.ammo;
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
        ammoCountUI.gameObject.SetActive(true);

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
        ammoCountUI.gameObject.SetActive(false);

        //Destroy(currentWeapon);
        currentWeapon = null;
        weaponScript = null;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
