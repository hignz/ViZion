using UnityEngine;

public class Planet : MonoBehaviour {

    [SerializeField]
    public int requiredPoints;

    public GameObject lockedUI;
    public GameObject unlockedUI;

    public bool hasRotation = true;

    [SerializeField]
    private float rotationSpeed = 0.1f;

    void Update()
    {
        if (hasRotation)
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (FindObjectOfType<GameManager>().playerPoints >= requiredPoints)
            {
                unlockedUI.SetActive(true);
                lockedUI.SetActive(false);
            }
            else
            {
                lockedUI.SetActive(true);
                unlockedUI.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            unlockedUI.SetActive(false);
            lockedUI.SetActive(false);
        }
    }
}
