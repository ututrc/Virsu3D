using UnityEngine;
using System.Collections;

public class MyyjäEnableSelectedInMyyjä : MonoBehaviour {

	public GameObject receiverM;

	// Use this for initialization
	void Start () {
		receiverM = GameObject.FindGameObjectWithTag("MyyjäKuulutusTrigger");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
//		Debug.Log("Before Activation");
		receiverM.gameObject.SetActive(true);
		receiverM.SendMessage("EnableMyyjäTrigger");
//		Debug.Log("After Activation");
	}
}
