using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {
	CharacterController cc;
	CharacterMotor cm;
	Rigidbody rb;
	GameObject player;
	Transform defaultParentTransform;
	public float boardingDistance = 10.0f;
	public float fwdThrustMag = 3.0f;
	public float trnThrustMag = 1.0f;
	public float maxVelocity = 5.0f;
	public float bobAmplitude = 0.05f;
	public float bobFrequency = 2.0f;
	bool isDriving = false; 
	float startY;


	void Start () {
		cc = GameObject.FindObjectOfType<CharacterController> ();
		cm = GameObject.FindObjectOfType<CharacterMotor> ();
		rb = gameObject.GetComponent<Rigidbody> ();
		player = cm.gameObject;
		defaultParentTransform = player.transform.parent;
		startY = gameObject.transform.position.y;
	}

	bool IsPlayerCloseToVehicle() {
		return Vector3.Distance (gameObject.transform.position, player.transform.position) < boardingDistance;
	}

	void SetDriving(bool isDriving) {
		this.isDriving = isDriving;
		cm.enabled = !isDriving;
		cc.enabled = !isDriving;
		if (isDriving) {
			player.transform.parent = gameObject.transform;
			player.transform.position = gameObject.transform.position;
			player.transform.rotation = gameObject.transform.rotation;
		} else {
			player.transform.parent = defaultParentTransform;
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && IsPlayerCloseToVehicle ()) {
			SetDriving (!isDriving);
			Debug.Log ("Toggle isDriving. Driving is: " + isDriving);
		}
		if (isDriving) {
			float forwardThrust = 0f;
			if (Input.GetKey (KeyCode.W)) {
				forwardThrust = fwdThrustMag;
			}
			if (Input.GetKey (KeyCode.S)) {
				forwardThrust = -fwdThrustMag;
			}
			if (forwardThrust > 0.0f) Debug.Log ("Forward Thrust: " + forwardThrust);
			if (forwardThrust > 0.0f) Debug.Log ("Adding Thrust: " + forwardThrust * gameObject.transform.forward);
			rb.AddForce (forwardThrust * gameObject.transform.forward);

			float turnThrust = 0f;
			if (Input.GetKey (KeyCode.A)) {
				turnThrust = trnThrustMag;
			}
			if (Input.GetKey (KeyCode.D)) {
				turnThrust = -trnThrustMag;
			}
			rb.AddRelativeTorque (-turnThrust * gameObject.transform.up);
		}
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxVelocity);
		Vector3 newPosition = gameObject.transform.position;
		newPosition.y = startY + bobAmplitude*Mathf.Sin (Time.timeSinceLevelLoad*bobFrequency);
		gameObject.transform.position = newPosition;
	}
}
