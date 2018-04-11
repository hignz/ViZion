using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaponController : MonoBehaviour {

    public Transform player;
    public int speed = 3;

    // Use this for initialization
    void Start () {
        //player = FindObjectOfType<Player>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), player.position, speed * Time.deltaTime);
	}
}
