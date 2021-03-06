using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PC_FSM_Animator : MonoBehaviour {

	private Animator animator;
	private float epsilon = 1.0f;
	private float linearSpeed;
	private float angularSpeed;
	public GameObject playerShape; 
	private Rigidbody rb;

    void Start () {
		animator = playerShape.GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	void Update() {
		Vector3 velocity = rb.velocity;
		if (velocity.magnitude > epsilon) {
			Vector3 localVelocity = transform.InverseTransformVector (velocity);
			float angle = Mathf.Atan2 (-localVelocity.z, -localVelocity.x) * Mathf.Rad2Deg;
			if (-135f < angle && angle <= -45f) {
				animator.SetTrigger ("Backward");
			} else if (-45f < angle && angle <= 45f) {
				animator.SetTrigger ("Right");
			} else if (45f < angle && angle <= 135f) {
				animator.SetTrigger ("Forward");
			} else {
				animator.SetTrigger ("Left");
			}
		}
//		else {
//			animator.SetTrigger ("Idle_FWD");
//		}
	}
		

}