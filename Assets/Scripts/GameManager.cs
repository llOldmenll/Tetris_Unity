using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseGame(){
        mainMenu.SetActive(true);
    }

    public void ResumeGame(){
        mainMenu.SetActive(false);
    }

    public void RestartGame(){
        mainMenu.SetActive(false);
    }
}
