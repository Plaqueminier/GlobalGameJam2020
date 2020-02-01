using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    PlayerManager playerManager;

    void Start() {
        playerManager = PlayerManager.instance;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel"))
            TogglePauseMenu();
    }

    public void TogglePauseMenu()
    {
        Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        playerManager.inputPaused = !playerManager.inputPaused;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
