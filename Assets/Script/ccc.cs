using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ccc : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!!");
    }
}
