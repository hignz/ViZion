using UnityEngine;

public class ShipMovement : MonoBehaviour {

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float acceleration = 100;

    [SerializeField]
    private float maxSpeed = 10;

    [SerializeField]
    private float rotateSpeed = 4;

    private float xAxis, yAxis;

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

        //ClampVel();
        RotateShip(xAxis);
    }

    void FixedUpdate()
    {
        Thrust(yAxis);

        if (Input.GetKey(KeyCode.S))
        {
            Thrust(yAxis);
        }
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
            Vector2 force = transform.right * (amount * acceleration * 2) * Time.deltaTime;

            myRigidBody.AddForce(force);

            ClampVel();
        }
    }

    private void RotateShip(float direction)
    {
        transform.Rotate(0, 0, -direction * (rotateSpeed * 2) * Time.deltaTime);
    }

}
