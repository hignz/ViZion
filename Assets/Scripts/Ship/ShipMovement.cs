using System.Collections;
using System.Collections.Generic;
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

    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        ClampVel();
        //RotateShip(xAxis);
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

            trail.time = 0.5f;
        }
        else
        {
            trail.time = 0f;
        }
    }

    private void RotateShip(float direction)
    {
        transform.Rotate(0, 0, -direction * rotateSpeed);
    }

}
