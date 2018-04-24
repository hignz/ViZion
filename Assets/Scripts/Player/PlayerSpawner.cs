using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{ 
    [SerializeField]
    public Transform chopper;

    public GameObject playerToSpawn;
    Vector2 startPos = new Vector2(-69.57f, -1.41f);
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "chopper")
        {
            GameObject newPlayerToSpawn = Instantiate(playerToSpawn);
            GameObject.Find("Player").transform.position = startPos;
        }
    }
}
