using UnityEngine;
using System.Collections;


using UnityEngine.UI;

public class PlayerControllerMoveTurn: MonoBehaviour {

	public float linearSpeed;	
	public float angularSpeed;
	private Rigidbody rb;		
	protected float moveHorizontal;
	protected float moveVertical;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		//Get vertical, horizontal, and angular movements
		moveHorizontal = -Input.GetAxis("Horizontal");
		moveVertical = -Input.GetAxis("Vertical");
		float rotation = Input.GetAxis("Rotation");

		//Compute movement vectors
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		Vector3 rotationVector = new Vector3(0.0f, rotation, 0.0f);
		Vector3 worldMovement = transform.TransformVector(movement);

		//Apply forces based on vectors
		rb.AddForce(worldMovement * linearSpeed);
		rb.AddTorque(rotationVector * angularSpeed);		
	}

}

