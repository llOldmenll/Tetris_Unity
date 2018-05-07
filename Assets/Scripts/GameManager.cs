using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject btnResume;

    public void PauseGame()
    {
        Time.timeScale = 0F;
        if (!mainMenu.gameObject.activeSelf)
        {
            btnResume.SetActive(true);
            mainMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1F;
        mainMenu.SetActive(false);
        btnResume.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1F;
        mainMenu.SetActive(false);
        btnResume.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
