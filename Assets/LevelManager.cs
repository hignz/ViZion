using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public bool EnemiesAlive
    {
        get
        {
            return enemies.Length > 0;
        }

        set
        {
            EnemiesAlive = value;
        }
    }

    GameObject[] enemies;

    public GameObject levelClearedUI;
    public TextMeshProUGUI scoreUI;

    public int score = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (score >= 100)
        {
            scoreUI.text = "" + score;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (!EnemiesAlive) // Level complete
        {
            GetComponent<AudioSource>().Stop();
            levelClearedUI.SetActive(true);
            StartCoroutine(LateCall());
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1.5f);

        levelClearedUI.gameObject.SetActive(false);
    }

}
