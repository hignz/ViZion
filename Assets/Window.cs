using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public GameObject brokenWindow;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(brokenWindow, transform.position, transform.rotation).SetActive(true); ;
        }
    }
}
