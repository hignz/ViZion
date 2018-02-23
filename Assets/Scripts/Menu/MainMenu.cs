using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuUI, splashScreenUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenuUI.activeInHierarchy)
            {
                mainMenuUI.SetActive(false);
                splashScreenUI.SetActive(true);
            }
        }
    }

    public void NewGame()
    {
        mainMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        //mainMenuUI.SetActive(false);
        // TO DO - IMPLEMENT LOAD GAME SCREEN       
    }

    public void OpenOptions()
    {
        // TO DO - IMPLEMENT OPTIONS SCREEN 
        //SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
