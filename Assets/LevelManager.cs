using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject escapeVehicle;

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
    public GameObject goToShipUI;

    public int score = 0;

    public int enemyCount = 0;
    bool levelComplete = false;
    
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

        if (!EnemiesAlive && !levelComplete) // Level complete
        {
            EndLevel();
            levelComplete = true;
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

    void EndLevel()
    {
        GetComponent<AudioSource>().Stop();
        levelClearedUI.SetActive(true);
        StartCoroutine(LateCall());
        goToShipUI.SetActive(true);

        FindObjectOfType<GameManager>().AddPlayerPoints(10);
        escapeVehicle.GetComponent<PolygonCollider2D>().enabled = false;
        escapeVehicle.GetComponent<BoxCollider2D>().enabled = true;
    }

}
