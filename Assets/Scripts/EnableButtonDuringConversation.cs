using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class EnableButtonDuringConversation : MonoBehaviour {

	//-------------------------------------------------------
	// Use this for initialization
	void Start () {
	
	}


	//-------------------------------------------------------
	// Update is called once per frame
	void Update () {
		//Enables buttons when conversation is active. Othervice is diabled. Used for Play and pause buttons.
		if(DialogueLua.GetVariable("QuestVariables.ConversationActive").AsBool){
			this.GetComponent<Image>().enabled = true;
			this.GetComponent<Button>().enabled = true;
			this.GetComponentInChildren<Text>().enabled = true;
		}

		else{
			this.GetComponent<Image>().enabled = false;
			this.GetComponent<Button>().enabled = false;
			this.GetComponentInChildren<Text>().enabled = false;
		}
	}
}
