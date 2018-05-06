using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject mainMenu;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PauseGame()
    {
        mainMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        mainMenu.SetActive(false);
    }

    public void RestartGame()
    {
        mainMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
