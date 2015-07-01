using UnityEngine;
using System.Collections;

public class KonduktööriOnTriggerEnterEnable : MonoBehaviour {

	GameObject receiver;
	// Use this for initialization
	void Start () {
		receiver = GameObject.FindGameObjectWithTag("Konduktööri");
	}

	/*
	// Update is called once per frame
	void Update () {
	
	}
	*/

	void OnTriggerEnter(Collider other){
		receiver.SendMessage("EnableKonduktööriTrigger");

	}

}
