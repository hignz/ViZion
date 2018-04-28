using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Bullet : MonoBehaviour
{
    private bool gameOver = false;
    private Rigidbody2D rb;

    public int speed = 200;
    public TextMeshProUGUI restartPromt;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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

            //FindObjectOfType<LevelManager>().RemoveEnemy();

            LevelManager.AddScore(100);
        }
        else if (tag.Equals("Player"))
        {
            other.gameObject.GetComponent<Player>().Die();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

           // StartCoroutine(LateCall());
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}
