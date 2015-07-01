using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class StartScreenToggle : MonoBehaviour {


	//-------------------------------------------------------
	// Use this for initialization
	void Start () {
		//GameObject.Find("Tehtävä M").GetComponent<UnityEngine.UI.Toggle>().isOn = false;
		//GameObject.Find ("Tehtävä merkit M").GetComponent<UnityEngine.UI.Toggle>().isOn = false;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesDuringLine = false;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesWithResponses = false;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showPCSubtitlesDuringLine = false;
	}

	//-------------------------------------------------------
	// Update is called once per frame
	void Update () {
	
	}

	//toggles subtitles on or off in start screen
	public void toggleSubtitles(){
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesDuringLine =! GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesDuringLine;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesWithResponses =! GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showNPCSubtitlesWithResponses;
		GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showPCSubtitlesDuringLine =! GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>().displaySettings.subtitleSettings.showPCSubtitlesDuringLine;
	}

	//toggles audio on or off in start screen
	public void toggleAudio(){
		Camera.main.GetComponent<AudioListener>().enabled =! Camera.main.GetComponent<AudioListener>().enabled;
	}
}
