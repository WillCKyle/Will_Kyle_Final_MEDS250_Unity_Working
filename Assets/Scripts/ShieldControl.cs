using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour {

	public GameObject shield;

	void Start () {
		shield.SetActive (false);
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			Debug.Log ("Setting shield active: ");
			shield.SetActive (true);
		} else if (Input.GetKeyUp (KeyCode.H)) {
			Debug.Log ("Setting shield in-active");
			shield.SetActive (false);
		}
	}
}
