using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;

    public AudioMixer audioMixer;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            Debug.Log(GameIsPaused);
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
