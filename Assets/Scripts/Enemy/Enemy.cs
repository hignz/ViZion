using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public void Die()
    {

        GameObject deadBody = GameObject.Instantiate(FindObjectOfType<SpriteManager>().GetEnemyDead(), transform.position, transform.rotation);
        
        FindObjectOfType<SpriteManager>().SpawnBloodSplatter(transform);

        Destroy(gameObject);

    }
}
