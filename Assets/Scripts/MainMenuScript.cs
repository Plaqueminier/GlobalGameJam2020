using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void ExitGame()
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("Button_quit"))
        {
            FindObjectOfType<AudioManager>().Play("Button_quit");
        }
        Application.Quit();
    }

    public void Play()
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("Button_play"))
        {
            FindObjectOfType<AudioManager>().Play("Button_play");
        }
        SceneManager.LoadScene("Scene1");
    }
}
