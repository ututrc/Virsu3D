using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public float shakeDelay = 3.0f;
	float timeToShake = 3.0f;
//	float shakeTime = 1.0f;
//	bool shaking;
	float shakeIntensity = 0.0f;
	Vector3 originalPos;
	Quaternion originalRot;

	// Use this for initialization
	void Start () {
//		shaking = false;
		timeToShake = 3.0f;
	}

	
	// Update is called once per frame
	void Update () {

		timeToShake -= Time.deltaTime;
		if (timeToShake > 0.0f){
//			timeToShake = shakeDelay;
//			Debug.Log("timeToShake is: " + timeToShake);
			if(timeToShake <= Random.Range(1.0f, 0.251f) && timeToShake >= Random.Range(0.25f, 0.0f) ){
				//shakeTime -= Time.deltaTime;
				DoShake();
//				Debug.Log("shakeTime is: " + shakeTime);
			}
			//Debug.Log("set shake time to " + shakeTime);
		}
		else{
			timeToShake = 3.0f;
		}
//		Debug.Log("After if loops");



		/*
		shakeTime += Time.deltaTime;
		Debug.Log(shakeTime);
		if(shakeTime >= 1.0f){
			DoNotShake();
			shakeTime = 0.0f;
		}

		if(shakeIntensity > 0.0f && shaking){
			
			Shake ();

			Debug.Log("Reducing shakeIntensity to " + shakeIntensity);

			}
		else{
			shaking = false;
			//transform.position = originalPos;
			Debug.Log("Shaking is set to false");
		}
		*/



	}
	//Does the actual shaking
	public void Shake(){
		transform.position = originalPos + Random.insideUnitSphere * shakeIntensity;
		transform.rotation = new Quaternion(originalRot.x + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
		                                    originalRot.y + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
		                                    originalRot.z + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
		                                    originalRot.w + Random.Range(-shakeIntensity, shakeIntensity)*.1f);
		//		Debug.Log("Shaking");
	}

	//Sets up things for shaking and calls Shake routine
	public void DoShake(){
		originalPos = transform.position;
		originalRot = transform.rotation;

		shakeIntensity = 0.0025f;

//		shaking = true;
		Shake ();
	}



}
