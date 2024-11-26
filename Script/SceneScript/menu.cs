using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject loadingScreen, menuObj, settingsObj, controlsObj;
    public string sceneName;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void playGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }

    public void showSettings()
    {
        menuObj.SetActive(false);
        settingsObj.SetActive(true);
    }

    public void showControls()
    {
        menuObj.SetActive(false);
        controlsObj.SetActive(true);
    }

    public void quitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void showMenu()
    {
        settingsObj.SetActive(false);
        controlsObj.SetActive(false);
        menuObj.SetActive(true);
    }
}
