using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Startgame()
    {
        SceneManager.LoadScene(0);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void Startlevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void Winner()
    {
        SceneManager.LoadScene(4);
    }
    public void Loses()
    {
        SceneManager.LoadScene(5);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
