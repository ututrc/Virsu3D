using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class HUD_Script : MonoBehaviour {

	Subtitle oldLine;
	GameObject play;
	GameObject pause;
	bool pausePlayModeActive = false;
	bool audioPaused = false;
	string currentSpeaker;
	Subtitle subtitle;
	private Subtitle latestLine = null;
//	DialogueSystemController dsc;
	//DialogueManager dialogueManager;


	// Use this for initialization
	void Start () {
		play = GameObject.Find("PlayButton");
		pause = GameObject.Find("PauseButton");

		//Used by play/pause system
		//dsc = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueSystemController>();
		//dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager");
		//	dsc = DialogueSystemController;
	}


	
	// Update is called once per frame
	void Update () {

		//Used by pause and play buttons to refer correct speaker
		latestLine = subtitle;

		//currentSpeaker = DialogueManager.Instance.GetComponent<ConversationManager> ().GetCurrentSpeaker ();
		if (latestLine != null) {
			currentSpeaker = latestLine.speakerInfo.nameInDatabase;
		}



		//Activates play & pause buttons during conversations
		if(DialogueLua.GetVariable("QuestVariables.ConversationActive").AsBool){
			transform.GetComponent<Image>().enabled = false;

		}
		else{
			transform.GetComponent<Image>().enabled = true;
		}


	}

	/*
	public void OnConversationLine(Subtitle subtitle)
	{

		if (oldLine != null)
		{
			GameObject oldSpeaker = GameObject.Find(oldLine.speakerInfo.nameInDatabase);
			if(oldSpeaker.GetComponent<Animator>() != null)
				oldSpeaker.GetComponent<Animator>().SetBool("IsTalking", false);
		}
		GameObject speaker = GameObject.Find(subtitle.speakerInfo.nameInDatabase);
		
		if(speaker.GetComponent<Animator>() != null)
			speaker.GetComponent<Animator> ().SetBool ("IsTalking", true);
		
		oldLine = subtitle;
//		logConversation (subtitle);

		latestLine = subtitle;
	}
	*/



	//Used to continue conversations during conversation pause
	public void Play(){
		pausePlayModeActive = false;
		// Set conversations to autoplay -> Don't need to click continue to move forward
		DialogueSystemController dsc = GameObject.Find ("Dialogue Manager").GetComponent<DialogueSystemController> ();
		dsc.displaySettings.subtitleSettings.continueButton = DisplaySettings.SubtitleSettings.ContinueButtonMode.Never;
		
		Time.timeScale = 1;
		if (GameObject.Find ("Pelaaja").GetComponent<AudioSource> () != null) {
			//Debug.Log("Vaihe 1");
			if (GameObject.Find ("Pelaaja").GetComponent<AudioSource> ().isPlaying) {
			//	Debug.Log("Vaihe 2");
			} else {
				if (audioPaused) {
			//		Debug.Log("Vaihe 3");
					//GameObject.Find (currentSpeaker).GetComponent<AudioSource> ().Play ();
					GameObject.Find ("Pelaaja").GetComponent<AudioSource> ().Play ();
					audioPaused = false;
					simulateContinueButtonClick ();
				} 
				/*
				else {
					Debug.Log("Vaihe 4");
					simulateContinueButtonClick ();
				}
				*/
			}

		}
	}




	//Used to pause conversations during conversation. Now pauses at the next line.
	public void Pause(){
		pausePlayModeActive = false;
		// Set conversations to wait for continue button push
		DialogueSystemController dsc = GameObject.Find ("Dialogue Manager").GetComponent<DialogueSystemController> ();
		dsc.displaySettings.subtitleSettings.continueButton = DisplaySettings.SubtitleSettings.ContinueButtonMode.Always;
		
		Time.timeScale = 0;
		//Debug.Log("before pause");
		GameObject.Find("Pelaaja").GetComponent<AudioSource>().Pause();
		//Debug.Log("after pause");
		audioPaused = true;
	}


	//used by play and pause system
	private void simulateContinueButtonClick()
	{
		DialogueManager.Instance.SendMessage ("OnConversationContinue", SendMessageOptions.DontRequireReceiver);
	}


}
