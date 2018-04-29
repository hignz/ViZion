using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;

    private Vector2 direction;

    public Animator myAnim;

    public bool restrictMovement = false;
    public int restrictMinX, restrictMaxX;
    public int restrictMinY, restrictMaxY;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();
        RestrictMovement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void RestrictMovement()
    {
        if (restrictMovement)
        {
            if (transform.position.x > restrictMaxX)
            {
                Vector3 pos = transform.position;
                pos.x = restrictMaxX;
                transform.position = pos;
            }

            if (transform.position.x < restrictMinY)
            {
                Vector3 pos = transform.position;
                pos.x = restrictMinY;
                transform.position = pos;
            }

            if (transform.position.y > restrictMaxY)
            {
                Vector3 pos = transform.position;
                pos.y = restrictMaxY;
                transform.position = pos;
            }

            if (transform.position.y < restrictMinY)
            {
                Vector3 pos = transform.position;
                pos.y = restrictMinY;
                transform.position = pos;
            } 
        }

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