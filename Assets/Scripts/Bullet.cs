using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;

    float timer = 10.0f;

    void Start()
    {

    }

    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
