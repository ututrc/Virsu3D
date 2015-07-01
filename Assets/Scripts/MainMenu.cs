using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	GameObject quest;
	GameObject questMarkers;


	//--------------------------------------------------------------------
	// Use this for initialization
	void Start () {
		quest = GameObject.Find("Tehtävä M");
		questMarkers = GameObject.Find ("Tehtävä merkit M");
		GameObject.Find("QuestMarkerCanvas1").GetComponent<Canvas>().enabled = false;
		Debug.Log(GameObject.Find("QuestMarkerCanvas1").GetComponent<Canvas>().enabled);
		GameObject.Find ("Tehtävät").GetComponentInChildren<Canvas>().enabled = false;
	}


	//-------------------------------------------------------------------
	// Update is called once per frame
	void Update () {
		//Disables firstPersonController when main menu is active
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().mainMenuActive){
			GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
		}
	}


	//closes application when called
	public void Quit(){
		Application.Quit();
	}


	//Enables gameplay and closes main menu when called.
	public void ReturnToGame(){
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().mainMenuActive = false;
		Screen.showCursor = false;
		Screen.lockCursor = true;
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
		GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Canvas>().enabled = false;
		Time.timeScale = 1;

	}


	//Used to toggle whether to show or hide subtitles
	public void toggleSubtitles(){
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesDuringLine =! GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesDuringLine;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesWithResponses =! GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesWithResponses;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showPCSubtitlesDuringLine =! GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showPCSubtitlesDuringLine;
	}


	public void SetSubtitlesTo(bool onOff){
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesDuringLine = onOff;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesWithResponses = onOff;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showPCSubtitlesDuringLine = onOff;
	}

	//Used to toggle audio on or off
	public void toggleAudio(){
		Camera.main.GetComponent<AudioListener>().enabled =! Camera.main.GetComponent<AudioListener>().enabled;
	}


	//Sets questDescription to value of input
	public void SetTehtävä(bool input){
		quest.GetComponent<UnityEngine.UI.Toggle>().isOn = input;
		GameObject.Find("Tehtävät").GetComponent<Canvas>().enabled = input;
	}


	//Sets questMarkers to value of input
	public void SetTehtäväMerkit(bool input){
		questMarkers.GetComponent<UnityEngine.UI.Toggle>().isOn = input;
		GameObject.Find ("QuestMarkerCanvas1").GetComponentInChildren<Canvas>().enabled = input;
	}


	//Sets QuestDescriptions and QuestMarker to startScreen toggled values. Also sets main menu toggles for questDesciption and QuestMarker.
	public void SetQuestToggles(){
		quest.GetComponent<UnityEngine.UI.Toggle>().isOn = GameObject.Find("Tehtävä").GetComponent<UnityEngine.UI.Toggle>().isOn;
		GameObject.Find("Tehtävät").GetComponent<Canvas>().enabled = quest.GetComponent<UnityEngine.UI.Toggle>().isOn;
		questMarkers.GetComponent<UnityEngine.UI.Toggle>().isOn = GameObject.Find("Tehtävä merkit").GetComponent<UnityEngine.UI.Toggle>().isOn;
		GameObject.Find ("QuestMarkerCanvas1").GetComponentInChildren<Canvas>().enabled = questMarkers.GetComponent<UnityEngine.UI.Toggle>().isOn;
		GameObject.FindGameObjectWithTag("MainMenuSub").GetComponent<UnityEngine.UI.Toggle>().isOn = GameObject.FindGameObjectWithTag("StartScreenSub").GetComponent<UnityEngine.UI.Toggle>().isOn;
		SetSubtitlesTo(GameObject.FindGameObjectWithTag("StartScreenSub").GetComponent<UnityEngine.UI.Toggle>().isOn);

	}

}
