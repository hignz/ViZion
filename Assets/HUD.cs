using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour {

    public TextMeshProUGUI timer;
    private float timePassed;
	
	void Update () {
        timePassed += Time.deltaTime;

        timer.text = "Time: " + string.Format("{0:0:00}",timePassed);
	}

    void ResetTimer()
    {
        timePassed = 0f;
        timer.text = "Time: ";
    }
}
