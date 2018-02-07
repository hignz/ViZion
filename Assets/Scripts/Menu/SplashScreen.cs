using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public GameObject splashScreenUI;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
