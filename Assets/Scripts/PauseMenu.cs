using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameplayManager theGM;

	public GameObject pauseMenu;

	public GameObject pauseButton;

	public void PauseGame() {
	
		Time.timeScale = 0f;

		pauseMenu.SetActive (true);

		pauseButton.SetActive (false);
	
	}

	public void ContinueGame() {

		pauseMenu.SetActive (false);

		pauseButton.SetActive (true);

		Time.timeScale = 1f;
	
	}

	public void RestartGame() {

		pauseMenu.SetActive (false);

		theGM.ResetGame ();
						
	}

	public void QuitToModeMenu () {
		
		SceneManager.LoadScene ("ModeMenu");

		pauseMenu.SetActive (false);

		pauseButton.SetActive (true);

		Time.timeScale = 1f;
	
	}

}
