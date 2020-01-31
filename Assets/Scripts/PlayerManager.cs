using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        if (instance != null) {
            Debug.Log("Warning, multiple players");
            return;
        }
        instance = this;
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
