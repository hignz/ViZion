using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipBehaviour : MonoBehaviour {


    void Start () {

    }
	
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // Enter planet

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
