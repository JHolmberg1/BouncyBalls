using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Bouncy Balls");
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
