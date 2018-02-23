using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public GameObject mainMenuUI, splashScreenUI;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            splashScreenUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }
    }
}
