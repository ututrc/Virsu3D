using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class PauseEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(DialogueLua.GetVariable("QuestVariables.PauseActive").AsBool){
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
