using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class NewsPaperEnabler : MonoBehaviour {
	
	bool showNewspaper;

	// Use this for initialization
	void Start () {
		transform.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Enables newpaper canvas when ShowNewspaper is true
		showNewspaper = DialogueLua.GetVariable("QuestVariables.ShowNewspaper").AsBool;
		if(showNewspaper){
			transform.GetComponent<Canvas>().enabled = true;
		}
		else{
			transform.GetComponent<Canvas>().enabled = false;
		}
	}
}
