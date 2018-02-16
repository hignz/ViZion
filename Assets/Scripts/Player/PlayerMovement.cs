using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;

    private Vector2 direction;

    public Animator myAnim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
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
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        rb2d.velocity = direction.normalized * speed;
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