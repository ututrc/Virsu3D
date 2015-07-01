using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class GenderLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(DialogueLua.GetVariable("QuestVariables.IsPlayerMale").AsBool){
		GameObject.FindGameObjectWithTag("GenderLabel").GetComponent<Text>().text = "Mies";
		}
		else
			GameObject.FindGameObjectWithTag("GenderLabel").GetComponent<Text>().text = "Nainen";

	}
}
