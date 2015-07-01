using UnityEngine;
using System;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
using System.Collections.Generic;

public class Virsu3D_UI : MonoBehaviour, IDialogueUI {

	public int originalYPos = 250;
	public int yAxisOffset = 50;
	GameObject dialogueManager = GameObject.Find("Dialogue Manager");
//	public GameObject dialogueChoiceButton;
//	public GameObject conversationUICanvas = GameObject.FindGameObjectWithTag("ConversationUI");
//	GameObject dialogueCanvas = GameObject.FindGameObjectWithTag("ConversationUI");


	public event EventHandler<SelectedResponseEventArgs> SelectedResponseHandler;
	
//	public GameObject buttonPrefab;
	
//	GameObject dialogueBoxPrefab = GameObject.FindGameObjectWithTag("ConversationUICanvas");

	GameObject choisesPanel = GameObject.FindGameObjectWithTag("ChoisesPanel");

	public Button itemPrefab;
	
	public int itemCount = 5, columCount = 1;

	//List<int> lista = new List<int>();

	GameObject pcSub = GameObject.FindGameObjectWithTag("PC_Subtitle");
	GameObject npcSub = GameObject.FindGameObjectWithTag("NPC_Subtitle");


	public void Open() {
		//dialogueBoxPrefab.SetActive(true);
		// Add your code here to do any setup at the beginning of a conversation -- for example,
		// activating or initializing GUI controls.
	}
	
	public void Close() {
		//dialogueBoxPrefab.SetActive(false);
		// Add your code here to do any cleanup at the end of a conversation -- for example,
		// deactivating GUI controls.
	}
	
	public void ShowSubtitle(Subtitle subtitle) {

		if ( subtitle.speakerInfo.Name.Equals("Pelaaja")){
			pcSub.GetComponent<Text>().text = subtitle.dialogueEntry.DialogueText;
			//pcSub.GetComponent<Text>().text = subtitle.formattedText.text;
		}

		else
		{
			npcSub.GetComponent<Text>().text = subtitle.dialogueEntry.DialogueText;
		}
		//GameObject.FindGameObjectWithTag("Subtitle").GetComponent<>().;
		// Add your code here to show a subtitle. Subtitles contain information such as the player 
		// type (PC or NPC), portrait texture, and the formatted text of the line.
	}
	
	public void HideSubtitle(Subtitle subtitle) {
	
		if ( subtitle.speakerInfo.Name.Equals("Pelaaja")){
			pcSub.GetComponent<Text>().text = "";
		}
		
		else
		{
			npcSub.GetComponent<Text>().text = "";
		}
		// Add your code here to hide a subtitle.
	}






	public void ShowResponses(Subtitle subtitle, Response[] responses, float timeout) {
	
		//int responsesLength = responses.Length;
		/*
		lista.Add(0);
		lista.Add(1);
		lista.Add(2);
		lista.Add(3);
		lista.Add(4);
		*/
		
		RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform>();
		RectTransform containerRectTransform = choisesPanel.GetComponent<RectTransform>();
		
		//Calculate the width and height of each child item.
		float width = containerRectTransform.rect.width / columCount;
		float ratio = width / rowRectTransform.rect.width;
		float height = rowRectTransform.rect.height*ratio;
		int rowCount = itemCount/columCount;
		if(itemCount % rowCount > 0)
			rowCount++;
		
		float scrollHeight = height * rowCount;
		containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
		containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);
		
		int j = 0;
		
		for(int i = 0; i < itemCount; i++){
			if(i % columCount == 0)
				j++;
			
			Button newItem = Instantiate(itemPrefab) as Button;
//			int index = i;
			Response response = responses[i];
			string choiseText = response.formattedText.text;
			newItem.GetComponentInChildren<Text>().text = choiseText;
			//newItem.GetComponentInChildren<Text>().text = "Valinta " + i;
			newItem.name = gameObject.name + " " + i;
			newItem.transform.parent = gameObject.transform;
			newItem.GetComponent<Button>().onClick.AddListener(() => {
				//string vastaus = "Valinta " + lista[index] + " valittu.";
				//Debug.Log(vastaus);
				SelectedResponseHandler(this, new SelectedResponseEventArgs(response));
				
			});
			
			RectTransform rectTransform = newItem.GetComponent<RectTransform>();
			
			//Move and size the new item
			float x = -containerRectTransform.rect.width / 2 + width * (i % columCount);
			float y = containerRectTransform.rect.height / 2 - height * j;
			rectTransform.offsetMin = new Vector2(x, y);
			
			x = rectTransform.offsetMin.x + width;
			y = rectTransform.offsetMin.y + height;
			rectTransform.offsetMax = new Vector2(x,y);
		


		//Creates buttons for responsen selection



			//Instantiate();
//			List<GameObject> responsesList = new List<GameObject>();
//			responsesList[i] = Instantiate(dialogueChoiceButton);
//			responsesList[i].transform.SetParent(conversationUICanvas);
			//Parent the instantiated button.
			//responsesList[] list instatiated responses for destroy(); function
			//(create button)
			//Add yAxisOffset


			//string temp;
			//temp = responses[i].formattedText.text;
			//Set text for response


		
		//when button clicked (SelectedResponseHandler(this, new SelectedResponseEventArgs(response));)


		// Add your code here to show the player response menu. Populate the menu with the contents
		// of the responses array. When the player selects a response, call:
		//    SelectedResponseHandler(this, new SelectedResponseEventArgs(response));
		// where the argument "response" is the response that the player selected.
		// If (timeout > 0), auto-select a response when timeout seconds have passed.
		}
	}





	//to be called when choise of conversation is selected
	public void OptionSelected(Response response){
		SelectedResponseHandler(this, new SelectedResponseEventArgs(response));
	}

	
	public void HideResponses() {
		//Destroy instantiated responces from responsesList[]
		// Add your code here to hide the player response menu.

	}
	
	public void ShowQTEIndicator(int index) {
		/// Add your code here to show the Quick Time Event (QTE) indicator specified by the given 
		/// index. If your project doesn't use QTEs, you can leave this method empty.
	}
	
	public void HideQTEIndicator(int index) {
		/// Add your code here to hide the Quick Time Event (QTE) indicator specified by the given 
		/// index. If your project doesn't use QTEs, you can leave this method empty.
	}
	
	public void ShowAlert(string message, float duration) {
		// Add your code here to show an alert message. Note that the dialogue system will not
		// call Open() or Close() for alerts, since alerts are meant to be shown outside of
		// conversations.
	}
	
	public void HideAlert() {
		// Add your code here to hide the alert message if it's showing.
	}

}
