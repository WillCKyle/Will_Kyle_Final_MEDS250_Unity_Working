using UnityEngine;
using System.Collections;


using UnityEngine.UI;

public class PlayerControllerMove: MonoBehaviour {

	public float linearSpeed;	
	private Rigidbody rb;					

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}
		
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 worldMovement = transform.TransformVector (-movement);
		rb.AddForce (worldMovement * linearSpeed);
	}

}

