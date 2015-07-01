using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class MainCameraFacingAndLocation : MonoBehaviour {

	public float smooth = 1.5f;
	public Transform targetK;
	public Transform targetM;
	Vector3 mummoCamLoc;
	Vector3 originalCamLoc;
	Vector3 newPosition;
	public Transform mummoParent;
	public Transform originalParent;
	bool lipuntarkastus1Active;
	bool mummoActive;
	public GameObject mummoCam;
	public GameObject originalCam;
	GameObject newPos;
	Quaternion originalRot;
	GameObject pelaaja;
	public bool startEnabled;


	//-------------------------------------------------------
	// Use this for initialization
	void Start () {
		//lipuntarkastus1Active = DialogueLua.GetVariable("QuestVariables.LipunTarkastus1Active").AsBool;
		//mummoActive = DialogueLua.GetVariable("QuestVariables.MummoActive").AsBool;

		mummoCamLoc = mummoCam.transform.localPosition;
		originalCamLoc = originalCam.transform.localPosition;
		GameObject.FindGameObjectWithTag("StartScreen").GetComponent<Canvas>().enabled = true;
		startEnabled = true;
		Screen.lockCursor = false;
		Screen.showCursor = true;
		Time.timeScale = 0.0f;
		pelaaja = GameObject.FindGameObjectWithTag("Player");
		pelaaja.GetComponent<FirstPersonController>().enabled = false;
		//pelaaja.GetComponent<Selector>().enabled = false;
		/*
		mummoCamLoc = mummoCam.transform.position;
		originalCamLoc = originalCam.transform.position;
		*/
	}//END OF START



	//-------------------------------------------------------
	// Update is called once per frame
	void Update () {

		//Debug.Log("Tehtävämerkki on " + GameObject.Find("QuestMarkerCanvas1").GetComponent<Canvas>().enabled);

		//Makes Main Camera to lerp rotation to face targetK if LipunTarkastus1Active is true
		if(targetK != null && DialogueLua.GetVariable("QuestVariables.LipunTarkastus1Active").AsBool)
		{
			//transform.LookAt(targetK);
			SmoothLookAt(targetK);
		}

		//Makes Main Camera to lerp rotation to face tagetM if MummoIsSitting is true
		if(targetM != null && DialogueLua.GetVariable("QuestVariables.MummoIsSitting").AsBool)
		{
			//transform.LookAt(targetM);
			setParentToNew();
			PositionChange(newPosition);
			SmoothLookAt(targetM);
		}


		/*
		if(DialogueLua.GetVariable("QuestVariables.Lipuntarkastus1Done").AsBool ){
			float time = 0.0f;

			while(time < 1.0f){
				time += Time.deltaTime;
				SmoothReturnLook();
			}
		}*/

		/*
		if(DialogueLua.GetVariable("QuestVariables.ConversationOut").AsBool == true){
			//transform.parent = originalParent;
			//newPosition = new Vector3(0,0,0);
			//PositionChange(new Vector3(0,0,0));
			Debug.Log("before original pos set");
			PositionChange(originalCamLoc);
			Debug.Log(originalCamLoc.ToString());
		}
		*/

		//Atempt to make camera rotation lerp for end of the conversation
		if(DialogueLua.GetVariable("QuestVariables.ConversationOut").AsBool == true){
			//transform.parent = originalParent;
			//newPosition = new Vector3(0,0,0);
			//PositionChange(new Vector3(0,0,0));
//			Debug.Log("before original pos set");
			PositionChange(originalCamLoc);
//			Debug.Log(originalCamLoc.ToString());
		}

	}//END OF UPDATE

	//Parents main camera to conversation head location
	public void setParentToNew(){

		originalCamLoc = this.transform.position;
		transform.parent = mummoParent;
		newPosition = mummoCamLoc;

	}

	//Parents Main Camera to it's default parent and call SetPosition
	public void SetParentToDefault(){

		transform.parent = originalParent;
		newPosition = originalCamLoc;
//		Debug.Log("Before Set");
		SetPosition();

//		Debug.Log("After Set");
	}


	//Sets target to local origin. In this case the Main Camera is set to default parent's 0,0,0
	void SetPosition(){
		transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
		//transform.position = originalCamLoc;
	}


	void PositionChange(Vector3 position){
		//originalCamLoc = transform.position;
		transform.position = Vector3.Lerp (transform.position, position, Time.deltaTime);//Moves camera to desired location. Disable if no solution for return.
		//transform.position = Vector3.Lerp (transform.TransformPoint(transform.position), newPosition, Time.deltaTime);
	}

	//Smoothly rotates camera to target
	void SmoothLookAt(Transform target){
		originalRot = transform.rotation;
		Vector3 relCameraPosition = target.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation(relCameraPosition, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);

	}

	//Smoothly rotates camera to original rotation
	void SmoothReturnLook(){
		transform.rotation = Quaternion.Lerp(transform.rotation, originalRot, smooth * Time.deltaTime);
	}

	//Set player gender to choose correct audio files for player dialogue
	public void setPlayerGender(bool gender){
		DialogueLua.SetVariable("QuestVariables.IsPlayerMale", gender);
	}

	//locks and hides mouse cursor when starging screen is hidden
	public void MouseHideLock (){
		pelaaja.GetComponent<FirstPersonController>().enabled = true;
		//pelaaja.GetComponent<Selector>().enabled = true;
		startEnabled = false;
		Screen.showCursor = false;
		Screen.lockCursor = true;
		Time.timeScale = 1.0f;
	}


}
