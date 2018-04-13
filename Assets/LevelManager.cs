using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public bool EnemiesAlive
    {
        get
        {
            return enemyCount > 0;
        }
    }

    GameObject[] enemies;

    public GameObject levelClearedUI;
    public TextMeshProUGUI scoreUI;

    public int score = 0;

    public int enemyCount = 0;

    void Start ()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void Update ()
    {
        if (score >= 100)
        {
            scoreUI.text = "" + score;
        }

        if (!EnemiesAlive) // Level complete
        {
            GetComponent<AudioSource>().Stop();
            levelClearedUI.SetActive(true);
            StartCoroutine(LateCall());
        }
    }

    public void RemoveEnemy()
    {
        enemyCount--;
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1.5f);

        levelClearedUI.gameObject.SetActive(false);
    }

}
