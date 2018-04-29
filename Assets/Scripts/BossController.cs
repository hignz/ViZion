using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {
    private int bossHealth = 100;
    public float bossHealthFloat;
    public Image healthBar;
    public int enemyCount = 0;

    [SerializeField]
    public GameObject enemyOne, enemyTwo;


    private void Start()
    {
        enemyOne.SetActive(false);
        enemyTwo.SetActive(false);
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemyCount);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
        
        if (tag.Equals("Bullet"))
        {
            bossHealth -= 5;
            bossHealthFloat = bossHealth / 100f;
            healthBar.fillAmount = bossHealthFloat;

            if (bossHealthFloat == 0.75)
            {
                gameObject.SetActive(false);
                enemyOne.SetActive(true);
                enemyTwo.SetActive(true);
                
                healthBar.fillAmount = bossHealthFloat;
            }


            else if (bossHealthFloat == 0.45)
            {

            }

            else if (bossHealthFloat == 0.15)
            {

            }

            else if (bossHealthFloat == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
