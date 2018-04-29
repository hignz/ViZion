using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 100;

    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
    {
        HP -= amount;
    }

    public void Die()
    {
        GameObject deadBody = GameObject.Instantiate(FindObjectOfType<SpriteManager>().GetEnemyDead(), transform.position, transform.rotation);
        deadBody.GetComponent<SpriteRenderer>().sortingOrder = 4;
        FindObjectOfType<SpriteManager>().SpawnBloodSplatter(transform);
        Destroy(gameObject);
    }
}
