using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;


public class DisableTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(DialogueLua.GetVariable("QuestVariables.LipunTarkastus1Done").AsBool){
			//gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
			//gameObject.GetComponentInChildren<Usable>().enabled = false;
			gameObject.GetComponent<BoxCollider>().enabled = false;
//			gameObject.GetComponent<Usable>().enabled = false;
		}
	}

	void EnableKonduktööriTrigger (){
		//gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
		//gameObject.GetComponentInChildren<Usable>().enabled = true;
		gameObject.GetComponent<BoxCollider>().enabled = true;
//		gameObject.GetComponent<Usable>().enabled = true;
	}


}
