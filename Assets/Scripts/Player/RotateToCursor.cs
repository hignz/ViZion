using UnityEngine;
using System.Collections;

public class RotateToCursor : MonoBehaviour
{
    Vector3 mousePos;
    Camera cam;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        RotateToCamera();
    }

    void RotateToCamera()
    {
        //var mouse = Input.mousePosition;
        //var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        //var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        //var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        myRigidbody.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}
