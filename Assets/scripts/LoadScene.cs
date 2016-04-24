using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadMain() {
		SceneManager.LoadScene("Main");
	}

	public void LoadOptions() {
		SceneManager.LoadScene ("OptionsMenu");
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene ("menu");
	}
}
