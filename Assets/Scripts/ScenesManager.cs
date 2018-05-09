using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

	public void StartScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}
   
}
