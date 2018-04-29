using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {
    private int bossHealth = 100;
    public float bossHealthFloat;
    public Image healthBar;
    public int enemyCount = 0;

    public GameObject[] enemyToSpawn;
    public GameObject[] enemyToSpawnClone;
    public Transform[] enemySpawnLocations;


    void SpawnEnemies()
    {
        enemyToSpawnClone[0] = Instantiate(enemyToSpawn[0], enemySpawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    private void Update()
    {
        Debug.Log(bossHealthFloat);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
        
        if (tag.Equals("Bullet"))
        {
            bossHealth -= 1;
            bossHealthFloat = bossHealth / 100f;
            healthBar.fillAmount = bossHealthFloat;

            if (bossHealthFloat == 0.75)
            {
                SpawnEnemies();
            }
          
            else if (bossHealthFloat == 0.45)
            {
                SpawnEnemies();
            }

            else if (bossHealthFloat == 0.15)
            {
                SpawnEnemies();
            }

            else if (bossHealthFloat == 0)
            {
                Destroy(gameObject);
            }
            healthBar.fillAmount = bossHealthFloat;
        }
    }
}
