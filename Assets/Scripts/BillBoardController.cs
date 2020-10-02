using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardController : MonoBehaviour {

	private Camera theCamera;
	public bool lookAtCamera;

	void Start() {
		theCamera = FindObjectOfType<Camera> ();
	}

	void Update () {
		float thisX = gameObject.transform.position [0];
		float thisY = gameObject.transform.position [1];
		float thisZ = gameObject.transform.position [2];
		float cameraX = theCamera.transform.position [0];
		float cameraY = theCamera.transform.position [1];
		float cameraZ = theCamera.transform.position [2];
		theCamera.transform.position = new Vector3 (cameraX, thisY, cameraZ);
		if (theCamera!=null && lookAtCamera) {
			transform.LookAt(theCamera.transform);
		}
		theCamera.transform.position = new Vector3 (cameraX, cameraY, cameraZ);
	}
}
