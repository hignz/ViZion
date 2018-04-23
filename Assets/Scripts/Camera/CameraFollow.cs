using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Camera chopperCamera;
    public Camera playerCamera;

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
    private Transform target;

    [SerializeField]
    public Vector3 offset;

    public Vector3 destinationPos = new Vector3(-70.26323f, 2.523464f, -0.1054688f);

    private void Start()
    {
        chopperCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);
    }

    private void Update()
    {  
        if (target.position == destinationPos)
        {
            playerCamera.gameObject.SetActive(true);
            chopperCamera.gameObject.SetActive(false);
        }
    }

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
}
