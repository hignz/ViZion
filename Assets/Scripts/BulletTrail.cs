using UnityEngine;

public class BulletTrail : MonoBehaviour {

    public int speed = 200;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        //transform.Translate(Vector3.right * Time.deltaTime * speed);

        rb.AddForce(transform.right * speed);

        Destroy(gameObject, 1);
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag.Equals("Wall"))
        {
            Debug.Log("yo wallllll!!!1");
            Destroy(gameObject);
        }
        else if (tag.Equals("Enemy"))
        {

        }


    }
}
