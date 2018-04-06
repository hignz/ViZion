using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipBehaviour : MonoBehaviour {

    public int restrictMinX, restrictMaxX;
    public int restrictMinY, restrictMaxY;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Planet")
        //{
        //    if (Input.GetKeyUp(KeyCode.Space))
        //    {
        //        Planet planetScript = collision.gameObject.GetComponent<Planet>();

        //        if (FindObjectOfType<GameManager>().playerPoints >= planetScript.requiredPoints)
        //        {
        //            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //        }
        //    }
        //}
    }

    private void Update()
    {
        RestrictMovement();
    }

    void RestrictMovement()
    {
        if (transform.position.x > restrictMaxX)
        {
            Vector3 pos = transform.position;
            pos.x = restrictMaxX;
            transform.position = pos;
        }

        if (transform.position.x < restrictMinY)
        {
            Vector3 pos = transform.position;
            pos.x = restrictMinY;
            transform.position = pos;
        }

        if (transform.position.y > restrictMaxY)
        {
            Vector3 pos = transform.position;
            pos.y = restrictMaxY;
            transform.position = pos;
        }

        if (transform.position.y < restrictMinY)
        {
            Vector3 pos = transform.position;
            pos.y = restrictMinY;
            transform.position = pos;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Planet"))
        {
            transform.parent = other.transform.parent;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Planet"))
        {
            transform.parent = null;
        }
    }
}
