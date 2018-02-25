using UnityEngine;

public class PickupScript : MonoBehaviour {

    public GameObject pickupInRange = null;

    void Update()
    {
        if (Input.GetButtonDown("Pickup") && pickupInRange)
        {
            transform.Find("WeaponSlot").GetComponent<WeaponManager>().PickupWeapon(pickupInRange);
            pickupInRange.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            pickupInRange = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            if (collision.gameObject == pickupInRange)
            {
                pickupInRange = null;
            }
        }
    }
}
