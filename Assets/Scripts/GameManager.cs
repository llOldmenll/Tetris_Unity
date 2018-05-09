using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public GameObject mainMenu;
	public GameObject ingameMenu;

	public void PauseGame()
	{
		Time.timeScale = 0F;
		if (!mainMenu.gameObject.activeSelf)
		{
			mainMenu.SetActive(true);
			ingameMenu.SetActive(false);
		}
	}

	public void ResumeGame()
	{
		Time.timeScale = 1F;
		ingameMenu.SetActive(true);
		mainMenu.SetActive(false); 
	}

	public void RestartGame()
	{
		Time.timeScale = 1F;
		ingameMenu.SetActive(true);
		mainMenu.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
