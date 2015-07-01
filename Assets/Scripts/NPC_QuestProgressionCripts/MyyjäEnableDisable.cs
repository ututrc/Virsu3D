using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class MyyjäEnableDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<BoxCollider>().enabled = false;
//		this.GetComponent<Usable>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if( DialogueLua.GetVariable("QuestVariables.KuulutusDone").AsBool){
			this.GetComponent<BoxCollider>().enabled = false;
//			this.GetComponent<Usable>().enabled = false;
		}
		/*
		else{
			gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
			gameObject.GetComponentInChildren<Usable>().enabled = false;
		}
		*/
	}

	void EnableMyyjäTrigger (){
		this.GetComponent<BoxCollider>().enabled = true;
//		this.GetComponent<Usable>().enabled = true;
	}
}
