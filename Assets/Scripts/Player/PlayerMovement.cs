using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D myRigidBody;

    private Vector2 direction;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        myRigidBody.velocity = direction.normalized * speed;
    }

    void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            direction += Vector2.up;
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
}