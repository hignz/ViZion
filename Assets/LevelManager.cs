using UnityEngine;
using TMPro;
using System.Collections;
using System.Timers;

public class LevelManager : MonoBehaviour {

    public bool EnemiesAlive
    {
        get
        {
            return enemyCount > 0;
        }
    }

    public GameObject escapeVehicle;

    public GameObject levelClearedUI;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI multiplierUI;
    public GameObject goToShipUI;

    public static float score = 0;
    private static float multiplier = 1f;

    public int enemyCount = 0;
    bool levelComplete = false;

    private static float comboTimer = 2.5f;
    private static bool comboActive = false;
    
    void Update ()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (!EnemiesAlive && !levelComplete) // Level complete
        {
            EndLevel();
            levelComplete = true;
        }

        if (comboActive)
        {
            comboTimer -= Time.deltaTime;
            print("timer "+comboTimer);
        }

        if (comboTimer <= 0f && comboActive)
        {
            comboActive = false;
            comboTimer = 2.5f;
            ResetMultiplier();
        }

        print("Mult: " + multiplier);
    }

    void LateUpdate()
    {
        if (LevelManager.score >= 100)
        {
            scoreUI.text = "" + (int)LevelManager.score;
            multiplierUI.text = LevelManager.multiplier + "x";
        }
    }

    public static void AddScore(float amount)
    {
        comboActive = true;
        comboTimer = 2.5f;
        multiplier += 0.25f;
        print(multiplier);
        LevelManager.score += amount * multiplier;
    }

    public static void SetMultiplier(float mult)
    {
        LevelManager.multiplier = mult;
    }

    public static void ResetMultiplier()
    {
        LevelManager.multiplier = 1f;
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

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1.5f);

        levelClearedUI.gameObject.SetActive(false);
    }


}
