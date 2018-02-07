using UnityEngine;

public class ShipMovement : MonoBehaviour {

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float maxSpeed = 10;

    [SerializeField]
    private float rotateSpeed = 4;

    private float xAxis, yAxis;

    [SerializeField]
    private TrailRenderer trail;

    [SerializeField]
    private float reverseSpeed = 2;

    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        ClampVel();
        RotateShip(xAxis);

        if (Input.GetKey(KeyCode.S))
        {
            Reverse(reverseSpeed);
        }
    }

    void FixedUpdate()
    {
        Thrust(yAxis);
    }

    private void ClampVel()
    {
        float xVel = Mathf.Clamp(myRigidBody.velocity.x, -maxSpeed, maxSpeed);
        float yVel = Mathf.Clamp(myRigidBody.velocity.y, -maxSpeed, maxSpeed);

        myRigidBody.velocity = new Vector2(xVel, yVel);
    }

    private void Thrust(float amount)
    {
        if (amount > 0)
        {
            Vector2 force = transform.right * amount * speed;

            myRigidBody.AddForce(force);
        }
    }

    private void Reverse(float amount)
    {
        Vector2 force = transform.right * amount;

        myRigidBody.AddForce(-force);

    }

    private void RotateShip(float direction)
    {
        transform.Rotate(0, 0, -direction * rotateSpeed);
    }

}
