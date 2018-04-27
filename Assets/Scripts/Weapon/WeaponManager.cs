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

        if (currentWeapon != null && weaponScript.ammo > 0)
        {
            switch (weaponScript.type)
            {
                case Weapon.WeaponType.Spread:
                    if (Input.GetButtonDown("Fire1") && lastShotTime > weaponScript.fireRate)
                    {
                        lastShotTime = 0;

                        for (int i = 0; i < 4; i++)
                        {
                            weaponScript.Fire();
                        }

                        weaponScript.ammo--;
                    }
                    break;
                case Weapon.WeaponType.AutoFire:
                    if (Input.GetButton("Fire1") && lastShotTime > weaponScript.fireRate)
                    {
                        lastShotTime = 0;
                        weaponScript.Fire();

                        weaponScript.ammo--;
                    }
                    break;
                case Weapon.WeaponType.SingleFire:

                    break;
                default:

                    break;
            }
        }
        else if(currentWeapon != null && weaponScript.ammo <= 0 && Input.GetButtonDown("Fire1"))
        {
            emptyClipSFX.Play();
        }
        else if (currentWeapon != null && Input.GetButtonDown("Pickup"))
        {
            ThrowWeapon();
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

    public void ThrowWeapon()
    {
        //currentWeapon.GetComponent<Rigidbody2D>().AddForce(, ForceMode2D.Force);
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
        ammoCountUI.gameObject.SetActive(true);
        GetComponentInParent<Player>().SwapToEquipSprite();

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
        currentWeapon.transform.localScale = new Vector3(3f, 3f, 1);
        currentWeapon.SetActive(true);
        ammoCountUI.gameObject.SetActive(false);
        GetComponentInParent<Player>().SwapToUnequippedSprite();


        currentWeapon = null;
        weaponScript = null;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
