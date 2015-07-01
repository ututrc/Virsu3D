using UnityEngine;
using System.Collections;

public class DisableMeshRenderer : MonoBehaviour {

	// Use this for initialization
	//Disables meshrenderer in objecs child
	void OnEnable () {
		gameObject.GetComponentInChildren<Renderer>().enabled = false;
	}

}
