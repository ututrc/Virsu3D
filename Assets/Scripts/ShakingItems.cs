using UnityEngine;
using System.Collections;

public class ShakingItems : MonoBehaviour {

	//public float shakeDelay = 3.0f;
	float timeToShake = 3.0f;
//	float shakeTime = 1.0f;
//	bool shaking;
	float shakeIntensity = 0.0f;
	Vector3 originalPos;
	Quaternion originalRot;
	Vector3 startingPos;
	Quaternion startingRot;
	
	// Use this for initialization
	void Start () {
//		shaking = false;
		timeToShake = 3.0f;
		startingPos = transform.position;
		startingRot = transform.rotation;
	}
	
	
	// Update is called once per frame
	void Update () {


		timeToShake -= Time.deltaTime;

		if(timeToShake >= 0.0f){
			transform.position = startingPos;
			transform.rotation = startingRot;
		}

		if (timeToShake > 0.0f){
			if(timeToShake <= Random.Range(1.0f, 0.251f) && timeToShake >= Random.Range(0.25f, 0.0f) ){
				DoShake();
			}
		}

		else{
			timeToShake = 3.0f;
		}


	}

	//Does the actual shaking
	public void Shake(){
		transform.position = originalPos + Random.insideUnitSphere * shakeIntensity;
		transform.rotation = new Quaternion(originalRot.x + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
		                                    originalRot.y + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
		                                    originalRot.z + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
		                                    originalRot.w + Random.Range(-shakeIntensity, shakeIntensity)*.1f);
	}
	
	//Sets up things for shaking and calls Shake routine
	public void DoShake(){
		originalPos = transform.position;
		originalRot = transform.rotation;
		
		shakeIntensity = 0.005f;
		
//		shaking = true;
		Shake ();
	}
}
