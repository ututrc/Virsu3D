using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestStatusNumbetSet : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void SetQuestNumber(string number){
//		Debug.Log(number);
		Text txt = gameObject.GetComponent<Text>();
		txt.text = number;
	}
}
