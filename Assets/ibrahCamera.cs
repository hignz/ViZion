using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ibrahCamera : MonoBehaviour
{ 
    public Camera myCamera;
    GameObject[] ObjectList = null;
    int index = 0;

    [SerializeField]
    private Transform target;

    [SerializeField]
    public GameObject player;

    public Vector3 destinationPos = new Vector3(-72.16f, 4.67f, 0f);

    public int speed = 10;

    [SerializeField]
    private bool restrictCamera = false;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float yMin;

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMax;

    [SerializeField]
    public Vector3 offset;

    void LateUpdate()
    {
        if (restrictCamera)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x + offset.x, xMin, xMax), Mathf.Clamp(target.position.y + offset.y, yMin, yMax), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, transform.position.z);
        }
    }

    private void Start()
    {
        myCamera.orthographicSize = 12;
        player.gameObject.SetActive(false);
    }

    void Update()
    {
        if (target.position == destinationPos)
        {
            findNext();
            myCamera.orthographicSize = 3.5f;
            player.gameObject.SetActive(true);
        }

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    LookAhead();
        //}
        //else
        //{
        //    transform.LookAt(target);
        //}
    }

    void Awake()
    {
        ObjectList = GameObject.FindGameObjectsWithTag("Player");
    }

    void findNext()
    {
        index++;
        if (index >= ObjectList.Length)
        {
            index = 0;
        }
        target = ObjectList[index].transform;

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

