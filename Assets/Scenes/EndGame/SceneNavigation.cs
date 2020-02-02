using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{

    public void navigateToGame()
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("Button_play"))
        {
            FindObjectOfType<AudioManager>().Play("Button_play");
        }
        SceneManager.LoadScene("Scene1");
    }

    public void navigateToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("Button_quit"))
        {
            FindObjectOfType<AudioManager>().Play("Button_quit");
        }
        Cursor.lockState = CursorLockMode.None;
        Application.Quit();
    }
    public void selectScene()
    {
        Cursor.lockState = CursorLockMode.None;

        Debug.Log(this.gameObject.name);
        switch (this.gameObject.name)
        {
            case "Replay":
                SceneManager.LoadScene("SampleScene");
                break;
            case "Quit":
                Application.Quit();
                break;
            case "Credit":
                Debug.Log("Crédits....");
                break;
            default:
                Debug.Log("Autre....");
                break;
        }
    }
}