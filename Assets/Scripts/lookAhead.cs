using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAhead : MonoBehaviour {

    float speed = 10.0f;

    [SerializeField]
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        LookAhead();
    }

    void LookAhead()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }

        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }
    }
}
