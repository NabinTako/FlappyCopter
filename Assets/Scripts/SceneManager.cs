using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

	[SerializeField] private GameObject? loadingImage;
	[SerializeField] private int loadingSceneInterval = 1;

	[SerializeField] private Text? highScore;
	private const string ScorePlayerPreFabName = "Score";
	private float startBtnClickedTime=0;

	private bool gameStart = false;

	private void Awake() {
		if(highScore != null) {

			loadingImage.SetActive(false);
			highScore.text = $"HighScore: {PlayerPrefs.GetInt(ScorePlayerPreFabName)}";
		}
	}

	private void Update() {

		if (gameStart) {

			loadingImage.SetActive(true);
			if (Time.time > startBtnClickedTime + loadingSceneInterval) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(1, LoadSceneMode.Single);
			}
		}
	}
	public void StartGame() {
		startBtnClickedTime = Time.time;
		gameStart = true;
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void GoToMainMenu() {
		UnityEngine.SceneManagement.SceneManager.LoadScene(0, LoadSceneMode.Single);
		Time.timeScale = 1;

	}
	public void PlayAgain() {
		UnityEngine.SceneManagement.SceneManager.LoadScene(1, LoadSceneMode.Single);
		Time.timeScale = 1;
	}
}
