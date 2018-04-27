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

    public static float score = 0;
    private static float multiplier = 1f;

    public int enemyCount = 0;
    bool levelComplete = false;

    private float timeSinceHit = 0;
    
    void Start ()
    {
        Debug.Log(enemyCount);
    }

    void Update ()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Debug.Log(enemyCount);

        if (score >= 100)
        {
            scoreUI.text = "" + (int)LevelManager.score;
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

    public void AddScore(float amount)
    {
        LevelManager.score += amount * multiplier;
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
