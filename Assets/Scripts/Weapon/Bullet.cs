using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int speed = 200;
    private Rigidbody2D rb;

    public TextMeshProUGUI restartPromt;

    private bool gameOver = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GetComponent<SpriteRenderer>().transform.localScale.Set(1, 1 + Random.Range(-2f, 2f), 1);

        Destroy(gameObject, 1.2f);


    }

    void Update()
    {
        rb.AddForce(transform.right * speed);

        if (gameOver == true && Input.GetButtonDown("Restart"))
        {
            restartPromt.text = "";

            gameOver = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag.Equals("Wall") || tag.Equals("Door") || tag.Equals("Prop"))
        {
            Destroy(gameObject);
        }
        else if (tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Die();

            FindObjectOfType<LevelManager>().RemoveEnemy();
        }
        else if (tag.Equals("Player"))
        {
            other.gameObject.GetComponent<Player>().Die();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            StartCoroutine(LateCall());
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
