using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {    

    public float movementspeed;
    public float mouseSensitivity = 2.0f;
    public float verticalAngleLimit = 60.0f;
	float originalMovementSpeed;
	float runSpeed;

	public bool mainMenuActive;

//    public float jumpSpeed = 5f;  

    float verticalRotation = 0;    
    float verticalVelocity = 0;    

    Camera firstPersonCamera;

    CharacterController characterController;

	// Use this for initialization
	void Start () {
     
		firstPersonCamera = Camera.main.GetComponent<Camera>();        
        characterController = GetComponent<CharacterController>();       
		Screen.showCursor = false;
		originalMovementSpeed = movementspeed;
		runSpeed = movementspeed * 2;
		Screen.lockCursor = true;
		mainMenuActive = false;
	}
	
	// Update is called once per frame
    void Update()
    {
  /*


       if(Input.GetMouseButtonDown(0))
       {
           RaycastHit hit;
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if(Physics.Raycast(ray, out hit))
           {
               float distance = Vector3.Distance(hit.transform.position, this.transform.position);
           }

       }
*/

		//Opens main menu if conversation is not active and player presed "quit" button
		if(Input.GetButtonDown("Quit") == true && Camera.main.GetComponent<MainCameraFacingAndLocation>().startEnabled == false){
			//Application.Quit();
			Time.timeScale = 0;
			GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Canvas>().enabled = true;
			Screen.showCursor = true;
			Screen.lockCursor = false;
			mainMenuActive = true;

		}

		//Player runs if "run" button is pressed with forward movement speed
		//(Sets movement speed to run speed)
		if(Input.GetButton("Run") == true){
			movementspeed = runSpeed;
		}

		else{
			movementspeed = originalMovementSpeed;
		}

        //Rotation for mouse control
        float rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotationLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);
        firstPersonCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement for keyboard movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementspeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementspeed;
		//Apply gravity to player
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

		/*
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            verticalVelocity = jumpSpeed;
        }
		*/

		//Set up and implementation for forward movement
        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        characterController.Move(speed * Time.deltaTime);




    }
}
