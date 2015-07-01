using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class SubBackGroundEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Enables dialogue subtitle background during conversations
		if(DialogueLua.GetVariable("QuestVariables.ConversationActive").AsBool){
			this.GetComponent<Image>().enabled = true;
		}
		else{
			this.GetComponent<Image>().enabled = false;
		}
	}
}
