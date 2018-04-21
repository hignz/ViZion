using UnityEngine;
using TMPro;

public class PickupScript : MonoBehaviour {

    public GameObject pickupInRange = null;
    public TextMeshProUGUI pickupText;

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
            Debug.Log(collision.gameObject.name);
            pickupText.text = "RMB to pickup " + collision.gameObject.name;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            if (collision.gameObject == pickupInRange)
            {
                pickupInRange = null;
                pickupText.text = "";
            }
        }
    }
}
