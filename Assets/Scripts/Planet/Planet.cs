using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Planet : MonoBehaviour {

    public string name;

    [SerializeField]
    public int requiredPoints;

    public TextMeshProUGUI lockedStatusUI;

    public bool hasRotation = true;

    public Transform orbitTarget;

    [SerializeField]
    private float rotationSpeed = 0.1f;

    public float orbitSpeed = 2;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    public Object level;

    void Update()
    {
        if (hasRotation)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (orbitTarget != null)
        {
            transform.RotateAround(orbitTarget.position, zAxis, orbitSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (FindObjectOfType<GameManager>().playerPoints >= requiredPoints)
            {
                lockedStatusUI.text = "Unlocked\n" 
                    + "Name: " + name +
                    "\nRequired points: " + requiredPoints;
            }
            else
            {
                lockedStatusUI.text = "Locked: " + name;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (FindObjectOfType<GameManager>().playerPoints >= requiredPoints && Input.GetKeyUp(KeyCode.E))
            {
                SceneManager.LoadScene(level.name);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lockedStatusUI.text = string.Empty;
        }
    }
}
