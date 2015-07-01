using UnityEngine;
using System.Collections;

public class EnableMeshRenderer : MonoBehaviour {

	// Use this for initialization
	//Enables meshrenderer from child object when script is enabled.
	void OnEnable() {
		gameObject.GetComponentInChildren<Renderer>().enabled = true;
	}

}
