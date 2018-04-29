using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickupTextClass : MonoBehaviour {

    public Text pickupText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            Debug.Log(collision.gameObject.name);
            pickupText.text = "Press RMB to pickup " + collision.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pickupText.text = "";
    }
}
