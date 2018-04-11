using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcade : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;

    private Rigidbody2D myRigidBody;

    public Vector2 direction;

    private SpriteRenderer sr;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        GetInput();
        Move();
    }

    private void Move()
    {
        myRigidBody.velocity = direction.normalized * (walkSpeed);
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            direction = Vector2.up;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            direction += Vector2.down;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction += Vector2.right;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction += Vector2.left;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "Chicken":
                Die();
                break;
            default:

                break;
        }
    }

    private void Die()
    {
        Debug.Log("You dead!");
    }
}
