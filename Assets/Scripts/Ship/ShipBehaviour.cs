using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipBehaviour : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Planet planetScript = collision.gameObject.GetComponent<Planet>();

                if (FindObjectOfType<GameManager>().playerPoints >= planetScript.requiredPoints)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
}
