using UnityEngine;
using System.Collections;

public class EnableCylinderCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Disables capsulecollider from this gameobject when function is called
	public void EnableCollider(){
		this.GetComponent<CapsuleCollider>().enabled = true;
	}

}
