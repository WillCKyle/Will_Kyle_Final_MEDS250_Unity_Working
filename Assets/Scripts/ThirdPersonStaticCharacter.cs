using UnityEngine;
using System.Collections;

public class ThirdPersonStaticCharacter : MonoBehaviour {

	public float movePower;
	public float turnSpeed;
	private Rigidbody theRigidbody;

	void Start () {
		theRigidbody =  GetComponent<Rigidbody>();
	}

	public void Move(Vector3 move) {
		theRigidbody.AddForce (movePower * move);
		float turnStep = turnSpeed * Time.deltaTime;
		Vector3 newDirection = Vector3.RotateTowards (transform.forward, move, turnStep, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDirection);
	}

	void OnMouseDown() {
		ScreenCapture.CaptureScreenshot("Screenshot.png");
	}


}
