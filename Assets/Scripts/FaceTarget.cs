using UnityEngine;
using System.Collections;

public class FaceTarget : MonoBehaviour {

	Transform target;

	// Use this for initialization
	void Start () {
		//Set target as main camera
		target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

		//Makes object face at target (Main Camera).
		if(target != null)
		{
			transform.LookAt(target);
		}

	}
}
