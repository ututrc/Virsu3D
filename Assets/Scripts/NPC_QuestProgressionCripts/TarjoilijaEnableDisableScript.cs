using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class TarjoilijaEnableDisableScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//IF statement for enabling interaction for Tarjoilija for inbetween Konduktööri and Mummo
		if(DialogueLua.GetVariable("QuestVariables.LipunTarkastus1Done").AsBool && DialogueLua.GetVariable("QuestVariables.KuulutusDone").AsBool && DialogueLua.GetVariable("QuestVariables.Tarjoilija2Done").AsBool == false){
			gameObject.GetComponent<Usable>().enabled = true;
			gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
		}
		else{
			gameObject.GetComponentInChildren<Usable>().enabled = false;
			gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
		}
	}
}
