using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        string tag = other.gameObject.tag;
        Debug.Log("outside");

        if (tag.Equals("Enemy") && Vector2.Distance(transform.position, FindObjectOfType<Player>().transform.position) <= 1f)
        {
            Debug.Log("inside");
            Destroy(other.gameObject);
        }
    }
}
