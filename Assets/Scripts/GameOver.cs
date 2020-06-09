using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //GAME OVER BUTTON HANDLER

    public void LoadScene(string name)
    {
        Debug.Log("Scene Load:" + name);
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }
}

