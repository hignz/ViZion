using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Camera chopperCamera;
    public Camera playerCamera;

    [SerializeField]
    public Transform chopper;

    public GameObject playerToSpawn;
    Vector2 startPos = new Vector2(-69.57f, -1.41f);

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



    private void Start()
    {
        chopperCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);
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
        playerCamera.gameObject.SetActive(true);
        chopperCamera.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "chopper")
        {
            GameObject newPlayerToSpawn = Instantiate(playerToSpawn);
            GameObject.Find("Player(Clone)").transform.position = startPos;
            
        }
    }
}
