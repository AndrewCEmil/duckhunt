using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenuController : MonoBehaviour {

	public Toggle gravityToggle;
	public Slider warpSlider;
	public Toggle inversionToggle;

	public void LoadMain() {
		SceneManager.LoadScene("Main");
	}

	public void LoadMainMenu() {
		SetVariables ();
		SceneManager.LoadScene ("menu");
	}


	void SetVariables() {
		VariableHolder variables = GameObject.FindWithTag ("VariableHolder").GetComponent<VariableHolder> ();
		variables.useGravity = gravityToggle.isOn;
		variables.phoneSpeed = (warpSlider.value + .1f) * .7f;
		variables.invertControl = inversionToggle.isOn;
	}

	void Awake() {
		VariableHolder variables = GameObject.FindWithTag ("VariableHolder").GetComponent<VariableHolder> ();
		gravityToggle.isOn = variables.useGravity;
		warpSlider.value = (variables.phoneSpeed / .7f) - .1f;
		inversionToggle.isOn = variables.invertControl;
	}
}