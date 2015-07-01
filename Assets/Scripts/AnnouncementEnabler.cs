using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class AnnouncementEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(DialogueLua.GetVariable("QuestVariables.AnnouncementActive").AsBool){
			this.GetComponent<Image>().enabled = true;
		}
		else{
			this.GetComponent<Image>().enabled = false;
		}

	}
}
