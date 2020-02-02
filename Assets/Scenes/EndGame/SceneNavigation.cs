using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour {
    public void selectScene () {
        Cursor.lockState = CursorLockMode.None;

        Debug.Log (this.gameObject.name);
        switch (this.gameObject.name) {
            case "Replay":
                SceneManager.LoadScene ("SampleScene");
                break;
            case "Quit":
                Application.Quit ();
                break;
            case "Credit":
                Debug.Log ("Crédits....");
                break;
            default:
                Debug.Log ("Autre....");
                break;
        }
    }
}