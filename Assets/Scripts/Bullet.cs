using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float destroyTimer = 10.0f;

    void Start()
    {

    }

    void Update()
    {
        Destroy(this.gameObject, destroyTimer);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
