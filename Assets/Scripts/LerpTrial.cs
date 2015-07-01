using UnityEngine;
using System.Collections;

public class LerpTrial : MonoBehaviour {

	private Vector3 newPosition;

	void Awake(){
		newPosition = transform.position;
	}

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		PositionChanging();
	}

	void PositionChanging(){
	
		Vector3 positionA = new Vector3(-5, 3, 0);
		Vector3 positionB = new Vector3(5, 3, 0);

		if(Input.GetKeyDown(KeyCode.Q)){
			newPosition = positionA;
		}
		if(Input.GetKeyDown(KeyCode.E)){
			newPosition = positionB;
		}


		transform.position = Vector3.Lerp (transform.position, newPosition, Time.deltaTime);

	}
}
