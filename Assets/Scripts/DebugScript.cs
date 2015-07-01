using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour {

	bool konduktööri1Done;
	bool myyjä1Done;
	bool myyjä2Done;
	bool mummo1Done;
	bool nuoriNainen1Done;
	bool conversationActive;
	
	Text konduktööri1DebugText;
	Text myyjä1DebugText;
	Text myyjä2DebugText;
	Text mummo1DebugText;
	Text nuoriNainen1DebugText;
	Text conversationActiveDebugText;

	GameObject debugScreen;

	bool debugActive;

	// Use this for initialization
	void Start () {


		//Sets references for DebugScreen panel and textfields
		debugScreen = GameObject.Find("DebugScreen");

		konduktööri1DebugText = GameObject.Find("LipunTarkastus1Debug").GetComponent<Text>();
		myyjä1DebugText = GameObject.Find("Myyjä1Debug").GetComponent<Text>();
		myyjä2DebugText = GameObject.Find ("Myyjä2Debug").GetComponent<Text>();
		mummo1DebugText = GameObject.Find("Mummo1Debug").GetComponent<Text>();
		nuoriNainen1DebugText = GameObject.Find("NuoriNainenDebug").GetComponent<Text>();
		conversationActiveDebugText = GameObject.Find("ConversationActiveDebug").GetComponent<Text>();



		//Sets debug screen false
		debugScreen.GetComponent<Image>().enabled = false;
		GameObject.Find("LipunTarkastus1Debug").GetComponent<Text>().enabled = false;
		GameObject.Find("Myyjä1Debug").GetComponent<Text>().enabled = false;
		GameObject.Find ("Myyjä2Debug").GetComponent<Text>().enabled = false;
		GameObject.Find("Mummo1Debug").GetComponent<Text>().enabled = false;
		GameObject.Find("NuoriNainenDebug").GetComponent<Text>().enabled = false;
		conversationActiveDebugText.enabled = false;

		debugActive = false;

	}//End of Start


	// Update is called once per frame
	void Update () {


		//Toggles DebugPanel onscreen
		if(Input.GetKeyDown(KeyCode.F11)){
			debugActive =! debugActive;
			debugScreen.GetComponent<Image>().enabled =! this.GetComponent<Image>().enabled;
			konduktööri1DebugText.enabled =! konduktööri1DebugText.enabled;
			myyjä1DebugText.enabled =! myyjä1DebugText.enabled;
			myyjä2DebugText.enabled =! myyjä2DebugText.enabled;
			mummo1DebugText.enabled =! mummo1DebugText.enabled;
			nuoriNainen1DebugText.enabled =! nuoriNainen1DebugText.enabled;
			conversationActiveDebugText.enabled =! conversationActiveDebugText.enabled;
		}

		//Sets quest status to innitial.
		if(Input.GetKeyDown(KeyCode.F5)&&debugActive){
			DialogueLua.SetVariable("QuestVariables.LipunTarkastus1Done", true);
			DialogueLua.SetVariable("QuestVariables.Tarjoilija1Done", false);
			DialogueLua.SetVariable("QuestVariables.Tarjoilija2Done", false);
			DialogueLua.SetVariable("QuestVariables.Mummo1Done", false);
			DialogueLua.SetVariable("QuestVariables.NuoriNainen1Done", false);

		}

		//Sets quest status to after first talk with myyjä
		if(Input.GetKeyDown(KeyCode.F6)&&debugActive){
			DialogueLua.SetVariable("QuestVariables.LipunTarkastus1Done", true);
			DialogueLua.SetVariable("QuestVariables.Tarjoilija1Done", true);
			DialogueLua.SetVariable("QuestVariables.Tarjoilija2Done", false);
			DialogueLua.SetVariable("QuestVariables.Mummo1Done", false);
			DialogueLua.SetVariable("QuestVariables.NuoriNainen1Done", false);
		}

		//Sets quest status to after second talk with myyjä
		if(Input.GetKeyDown(KeyCode.F7)&&debugActive){
			DialogueLua.SetVariable("QuestVariables.LipunTarkastus1Done", true);
			DialogueLua.SetVariable("QuestVariables.Tarjoilija1Done", true);
			DialogueLua.SetVariable("QuestVariables.Tarjoilija2Done", true);
			DialogueLua.SetVariable("QuestVariables.Mummo1Done", false);
			DialogueLua.SetVariable("QuestVariables.NuoriNainen1Done", false);
		}

		//Sets quest status adter mummo keskustelu
		if(Input.GetKeyDown(KeyCode.F8)&&debugActive){
			DialogueLua.SetVariable("QuestVariables.LipunTarkastus1Done", true);
			DialogueLua.SetVariable("QuestVariables.Tarjoilija1Done", true);
			DialogueLua.SetVariable("QuestVariables.Tarjoilija2Done", true);
			DialogueLua.SetVariable("QuestVariables.Mummo1Done", true);
			DialogueLua.SetVariable("QuestVariables.NuoriNainen1Done", false);
		}

		//Updates debug text fields
		konduktööri1DebugText.text = "LipunTarkastus1Done: " + DialogueLua.GetVariable("QuestVariables.LipunTarkastus1Done").AsBool;
		myyjä1DebugText.text = "Myyjä1Done: " + DialogueLua.GetVariable("QuestVariables.Tarjoilija1Done").AsBool;
		myyjä2DebugText.text = "Myyjä2Done: " + DialogueLua.GetVariable("QuestVariables.Tarjoilija2Done").AsBool;
		mummo1DebugText.text = "Mummo1Done: " + DialogueLua.GetVariable("QuestVariables.Mummo1Done").AsBool;
		nuoriNainen1DebugText.text = "NuoriNainen1Done: " + DialogueLua.GetVariable("QuestVariables.NuoriNainen1Done").AsBool;
		conversationActiveDebugText.text = "ConversationActive: " + DialogueLua.GetVariable("QuestVariables.ConversationActive").AsBool;

	}//End of update




}
