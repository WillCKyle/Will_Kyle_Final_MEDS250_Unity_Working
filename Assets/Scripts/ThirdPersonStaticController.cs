using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ThirdPersonStaticController : MonoBehaviour {

	private ThirdPersonStaticCharacter characterController;

	void Start () {
		characterController = GetComponent<ThirdPersonStaticCharacter>();
	}
	

	private void FixedUpdate() {
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");	
		Transform mainCameraTransform = Camera.main.transform;
		Vector3 mainCameraForward = Vector3.Scale(mainCameraTransform.forward, new Vector3(1, 0, 1)).normalized;
		Vector3 mainCameraRight = mainCameraTransform.right;
		Vector3 move =  v*mainCameraForward + h*mainCameraRight;
		characterController.Move (move);
	}
}
