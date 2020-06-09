using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //MAIN MENU

    public void LoadLevel(string name)
    {
        Debug.Log("New Level Load:" + name);
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }
    
}
