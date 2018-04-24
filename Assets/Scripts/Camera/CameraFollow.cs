using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera myCamera;
    GameObject[] ObjectList = null;
    int index = 0;

    public Vector3 destinationPos = new Vector3(-72.16f, 4.67f, 0f);

    [SerializeField]
    private Transform target;

    [SerializeField]
    public GameObject player;

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

    private void Start()
    {
        myCamera.orthographicSize = 12;
        player.gameObject.SetActive(false);
    }

    void Update()
    {
        if (target.position == destinationPos && myCamera != null)
        {
            findNext();
            myCamera.orthographicSize = 3.5f;
            player.gameObject.SetActive(true);
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

}
