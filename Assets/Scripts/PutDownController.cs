using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownController : MonoBehaviour {


	public GameObject prototype;
	public int count = 3;
	public float timeBetweenPutDowns = 1.0f;
	float timer = 0f;

	void Update() {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire2") && count > 0 && timer >= timeBetweenPutDowns && Time.timeScale != 0) {
			Debug.Log ("Putting Down");
			GameObject pickUp = Instantiate (prototype, transform.position, transform.rotation);
			pickUp.SetActive (true);
			count--;
			timer = 0f;
		}
	}

}
