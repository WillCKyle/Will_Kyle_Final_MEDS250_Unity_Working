using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxController : MonoBehaviour {

	public GameObject[] soundObjects;
	private int index = 0;

	void OnTriggerEnter(Collider collider) {
		soundObjects[index].GetComponent<AudioSource>().Play ();
		if (index < soundObjects.Length - 1) {
			index++;
		}
	}
}
