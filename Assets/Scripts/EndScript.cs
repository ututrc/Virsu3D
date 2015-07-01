using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class EndScript : MonoBehaviour {

	public GameObject endScreen;
//	float timer = 0.0f;

	// Use this for initialization
	void Start () {
		//endScreen = GameObject.FindGameObjectWithTag("EndScreen");
	}
	
	// Update is called once per frame
	void Update () {

		if(DialogueLua.GetVariable("QuestVariables.NuoriNainen1Done").AsBool){

			endScreen.GetComponent<Canvas>().enabled = true;
			//endScreen.animation.Play("CanvasFadeIn");
			//Debug.Log("Canvas Fade In");
			//timer = Time.deltaTime;

			//if(timer > 5.0f){
			//	Debug.Log("End of the line.");
			//	Application.Quit();
			//}
		}

		else{
			endScreen.GetComponent<Canvas>().enabled = false;
		}

	}

	public void EndGame(){
		Application.Quit();
	}




}
