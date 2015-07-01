using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class QuestFollowerText : MonoBehaviour {

	int status;

	public void GuestProgressionInt (){
		int guestProgression = DialogueLua.GetVariable("GlobalVariables.DialogueProgression").AsInt;
		gameObject.GetComponent<Text>().text = guestProgression.ToString();
	}

	void Start () {
		gameObject.GetComponent<Text>().text = "0";
	}

	/*
	void update (){

	}
	*/

}
