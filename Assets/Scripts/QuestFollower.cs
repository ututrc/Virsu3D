using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class QuestFollower : MonoBehaviour {
	
	//Quest variables for completed quests/conversations
	bool lipuntarkastus1Completed;
	bool mummo1Completed;
	bool tarjoilija1Completed;
	bool tarjoilija2Completed;
	bool nuoriNainen1Completed;

	public Transform questMarker;

	public Transform myyjäMarkerPos;
	public Transform mummoMarkerPos;
	public Transform nuoriNainenMarkerPos;
	

	//------------------------------------------------------------------------------------------//
	// Use this for initialization
	void Start () {

		this.GetComponent<Canvas>().enabled = false;
		this.GetComponentInChildren<Text>().text = "Mene konduktöörin luokse.";
		//GameObject.Find("QuestMarkerCanvas1").GetComponent<Canvas>().enabled = false;


	}

	//-----------------------------------------------------------------------------------------//
	// Update is called once per frame
	void Update () {

		//Sets questmarker and description for lipuntarkastus
		if(DialogueLua.GetVariable("QuestVariables.LipunTarkastus1Done").AsBool && DialogueLua.GetVariable("QuestVariables.Tarjoilija1Done").AsBool == false){
			this.GetComponentInChildren<Text>().text = "Mene myyntitiskille.";
			questMarker.parent = myyjäMarkerPos;
			questMarker.localPosition = new Vector3(0,0,0);
		}

		//Sets quest description for myyjä
		else if(DialogueLua.GetVariable("QuestVariables.Tarjoilija1Done").AsBool && DialogueLua.GetVariable("QuestVariables.Tarjoilija2Done").AsBool == false){
			this.GetComponentInChildren<Text>().text = "Katso, mitä haluaisit tilata ruokalistalta.";
		}

		//Sets questmarker and description for mummo
		else if(DialogueLua.GetVariable("QuestVariables.Tarjoilija2Done").AsBool && DialogueLua.GetVariable("QuestVariables.Mummo1Done").AsBool == false){
			this.GetComponentInChildren<Text>().text = "Mene mummon luokse.";
			questMarker.parent = mummoMarkerPos;
			questMarker.localPosition = new Vector3(0,0,0);

		}

		//Sets questmarker and description for nuori nainen
		else if(DialogueLua.GetVariable("QuestVariables.Mummo1Done").AsBool && DialogueLua.GetVariable("QuestVariables.NuoriNainen1Done").AsBool == false){
			this.GetComponentInChildren<Text>().text = "Mene nuoren naisen luokse.";
			questMarker.parent = nuoriNainenMarkerPos;
			questMarker.localPosition = new Vector3(0,0,0);

		}


		/* Old material from system trials
		GameObject.FindGameObjectWithTag("GuestProgressionInt").BroadcastMessage("GuestProgressionInt"); //Sends message to change on screen text
		int guestProgression = DialogueLua.GetVariable("GlobalVariables.DialogueProgression").AsInt;
		bool playerSexIsMale = DialogueLua.GetVariable("GlobalVariables.PlayerSexIsMale").AsBool;
		Debug.Log(guestProgression);
		Debug.Log(playerSexIsMale);
		*/
	}

	//Sets quest description canvas on/off
	public void ToggleCanvas(){
		this.GetComponent<Canvas>().enabled =! this.GetComponent<Canvas>().enabled;

	}

	//sets guest marker on/off
	public void ToggleMissionCanvas(){
		GameObject.Find("QuestMarkerCanvas1").GetComponent<Canvas>().enabled =! GameObject.Find("QuestMarkerCanvas1").GetComponent<Canvas>().enabled;
	}
	

}
