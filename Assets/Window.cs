using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public GameObject brokenWindow;

    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Bullet")
        {
            Destroy(gameObject);
            BreakWindow();
        }
    }

    void BreakWindow()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 randomPosition = transform.position;
            randomPosition.x += Random.Range(-1f, 1f);
            randomPosition.y += Random.Range(-1f, 1f);

            Instantiate(brokenWindow, randomPosition, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f))).SetActive(true);
        }
    }
}
