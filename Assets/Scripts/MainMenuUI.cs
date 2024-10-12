using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        //tell unit we need to change the scene to the game one
        SceneManager.LoadScene("Platformer");
    }

    public void Quit()
    {
        //close the game. it only works on standalone builds, such as ios, android, desktop...
        Application.Quit();
    }

    public void MainMenu()
    {
        //Go back to Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}
