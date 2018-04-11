using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeMachine : MonoBehaviour {

    private Sprite turnedOff;
    public Sprite turnedOn;

    SpriteRenderer spr;

    public bool isOn = false;

    public Object gameToLoad;

	void Start () {
        spr = GetComponent<SpriteRenderer>();
        turnedOff = spr.sprite;
	}

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOn = !isOn;

                if (isOn)
                {
                    spr.sprite = turnedOn;
                    StartCoroutine(LateCall());
                }
                else
                {
                    spr.sprite = turnedOff;
                } 
            }
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(gameToLoad.name);
    }

}
