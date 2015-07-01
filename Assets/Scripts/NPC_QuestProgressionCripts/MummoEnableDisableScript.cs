﻿using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class MummoEnableDisableScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(DialogueLua.GetVariable("QuestVariables.Tarjoilija2Done").AsBool && DialogueLua.GetVariable("QuestVariables.Mummo2Done").AsBool == false){
			gameObject.GetComponent<Usable>().enabled = true;
			gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
		}
		else{
			gameObject.GetComponentInChildren<Usable>().enabled = false;
			gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
		}
	}
}
