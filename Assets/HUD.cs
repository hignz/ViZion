using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour {

    public TextMeshProUGUI timer;
    private float timePassed = 0;
	
	void Update () {
        timePassed += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timePassed / 60f);
        int seconds = Mathf.FloorToInt(timePassed - minutes * 60);

        timer.text = string.Format("{0}:{1:00}", minutes, seconds);
	}

    void ResetTimer()
    {
        timePassed = 0f;
        timer.text = "";
    }
}
