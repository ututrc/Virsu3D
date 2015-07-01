using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class ChoisesBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Enables background for dialogue choises when conversation is active. Othervice is disabled.
		if(DialogueLua.GetVariable("QuestVariables.ConversationActive").AsBool){
			this.gameObject.GetComponent<Canvas>().enabled = true;
		}

		else{
			this.gameObject.GetComponent<Canvas>().enabled = false;
		}
	}
}
